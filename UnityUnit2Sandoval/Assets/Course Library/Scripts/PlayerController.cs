using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float vi;
    public float speed = 10.0f;
    public float xrange = 14f;
    public GameObject food;
    public int poop;
    public int lives;
    public TMPro.TMP_Text text;
    public TMPro.TMP_Text texts;

    void Update()
    {
        // Added quotes around "Horizontal" and "Vertical"
        horizontalInput = Input.GetAxis("Horizontal");
        vi = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * vi * Time.deltaTime * speed);

        if (transform.position.x < -xrange) transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        if (transform.position.x > xrange) transform.position = new Vector3(xrange, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, food.transform.rotation);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        // Added quotes around "Food" and fixed the text string logic
        if (collision.gameObject.CompareTag("Food"))
        {
            poop = poop + 1;
            // "score" wasn't defined, so we use a string "Score: " instead
            text.text = "Score: " + poop;
            Debug.Log("Hola");
        }
        
    }

}