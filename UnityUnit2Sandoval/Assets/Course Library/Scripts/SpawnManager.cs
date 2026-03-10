using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    [SerializeField] private float spawnRangeZ = 20f;
    [SerializeField] private float spawnRangeX = 20f;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    void Start()
    {
        if (animalPrefabs == null || animalPrefabs.Length == 0)
        {
            Debug.LogWarning("AnimalSpawner: No prefabs assigned!");
            return;
        }

        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = GetRandomBorderPosition();

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    Vector3 GetRandomBorderPosition()
    {
        bool spawnLeft = Random.value < 0.5f;

        float x = spawnLeft ? -spawnRangeX : spawnRangeX;
        float z = Random.Range(-spawnRangeZ, spawnRangeZ);

        return new Vector3(x, 0, z);
    }

    void OnDestroy()
    {
        CancelInvoke(nameof(SpawnRandomAnimal));
    }
}