using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] float steerSpeed = 0.5f;


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

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0,0,steerAmount);
    }
}
