using UnityEngine;

public class Driver : MonoBehaviour
{
    private float rotationSpeed = 100;
    private float moveSpeed = 100;
    [SerializeField] private float nitroSpeed;
         
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
        Debug.Log(other.CompareTag("Slough"));
        Debug.Log(other.tag);
        Debug.Log(other.CompareTag("Nitro"));;
        if (other.gameObject.CompareTag("Nitro"));
        {
            moveSpeed += nitroSpeed;
            Debug.Log("Speed is increased up to" + moveSpeed);
            Destroy(other.gameObject); 
        }
        
        if (other.gameObject.CompareTag("Slough"));
        {
            moveSpeed -= nitroSpeed;
            Debug.Log("Speed is decreased down to" + moveSpeed);
            Destroy(other.gameObject);
        }
    }
}
