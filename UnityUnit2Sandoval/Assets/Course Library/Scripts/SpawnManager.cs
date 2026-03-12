using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    [SerializeField] private float spawnRangeZ = 20f;
    [SerializeField] private float spawnRangeX = 20f;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float animalSpeed = 8f;

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
        bool spawnLeft = Random.value < 0.5f;

        float x = spawnLeft ? -spawnRangeX : spawnRangeX;
        float z = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 spawnPos = new Vector3(x, 0, z);

        // Face inward toward the center
        Quaternion rotation = spawnLeft ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, -90, 0);

        GameObject animal = Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);

        // Apply speed to any MoveForward component on the animal
        MoveForward mf = animal.GetComponent<MoveForward>();
        if (mf != null)
            mf.speed = animalSpeed;

        // Tag the animal so the player can detect it
        animal.tag = "Animal";

        // Destroy after 10 seconds to avoid clutter
        Destroy(animal, 10f);
    }

    void OnDestroy()
    {
        CancelInvoke(nameof(SpawnRandomAnimal));
    }
}