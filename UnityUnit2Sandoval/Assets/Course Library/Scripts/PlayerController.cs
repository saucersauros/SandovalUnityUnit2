using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float vi;
    public float speed = 10.0f;
    public float xrange = 14f;
    public GameObject food;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vi = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * vi * Time.deltaTime * speed);
        if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, food.transform.rotation);

        }
    }
}
