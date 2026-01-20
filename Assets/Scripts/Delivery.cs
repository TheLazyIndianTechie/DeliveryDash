using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool _hasPackage;
    [SerializeField] private float pickupDuration = 0.5f;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            if (!_hasPackage)
            {
                Debug.Log("Package picked up");
                _hasPackage = true;
                Destroy(other.gameObject, pickupDuration);
            }
            else if (_hasPackage)
            {
                Debug.Log("Package already picked up. Deliver this first");
            }
        }
        
        if (other.CompareTag("Customer") && _hasPackage)
        {
            Debug.Log("Package delivered");
            _hasPackage = false;
        }
    }
}
