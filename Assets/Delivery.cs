using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private bool _hasPackage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            Debug.Log("Package picked up");
            _hasPackage = true;
        }

        if (other.CompareTag("Customer") && _hasPackage)
        {
            Debug.Log("Package delivered");
            _hasPackage = false;
        }
    }
}
