using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private float moveSpeed = 100;
    [SerializeField] private float nitroSpeed;
    [SerializeField] private float sloughSpeed;
         
    private void Start()
    {
    }

    private void Update()
    {
        // transform.Translate(0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
        transform.Rotate(0, 0, rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * -1);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed * Input.GetAxis("Vertical"));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Nitro"))
        {
            moveSpeed += nitroSpeed;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Slough"))
        {
            moveSpeed -= sloughSpeed;
            Debug.Log("Speed is decreased down to" + moveSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Slough"))
        {
            moveSpeed += sloughSpeed;
        }
    }
}
