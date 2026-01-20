using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 5f;
    [SerializeField] private float steerSpeed = 200f;
    [SerializeField] private float regularSpeed = 5f;
    [SerializeField] private float boostSpeed = 10f;
    private bool _isBoosted;
    


    public void Update()
    {
        float move = 0.0f;
        float steer = 0.0f;

        if (Keyboard.current.upArrowKey.isPressed|| Keyboard.current.wKey.isPressed)
        {
            // Debug.Log("We are pushing forward");
            move = 1.0f;
        }
        
        else if (Keyboard.current.downArrowKey.isPressed|| Keyboard.current.sKey.isPressed)
        {
            // Debug.Log("We are pushing backwards");
            move = -1.0f;
        }

        if (Keyboard.current.leftArrowKey.isPressed|| Keyboard.current.aKey.isPressed)
        {
            // Debug.Log("We are pushing left");
            steer = 1.0f;

        }

        else if (Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.dKey.isPressed)
        {
            // Debug.Log("We are pushing right");
            steer = -1.0f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0,0,steerAmount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost") && !_isBoosted)
        {
            currentSpeed = boostSpeed;
            _isBoosted = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isBoosted)
        {
            currentSpeed = regularSpeed;
            _isBoosted = false;
        }
    }
}
