using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool isHavingPackage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !isHavingPackage)
        {
            isHavingPackage = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Customer") && isHavingPackage)
        {
            isHavingPackage = false;
            Destroy(other.gameObject);
        }
    }
}