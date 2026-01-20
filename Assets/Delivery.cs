using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            Debug.Log("Package picked up");
        }

        if (other.CompareTag("Customer"))
        {
            Debug.Log("Package delivered");
        }
    }
}
