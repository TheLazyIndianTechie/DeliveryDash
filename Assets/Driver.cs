using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] private float moveSpeed = 0.01f;

    
    public void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed|| Keyboard.current.wKey.isPressed)
        {
            Debug.Log("We are pushing forward");
        }
        
        else if (Keyboard.current.downArrowKey.isPressed|| Keyboard.current.sKey.isPressed)
        {
            Debug.Log("We are pushing backwards");
        }

        if (Keyboard.current.leftArrowKey.isPressed|| Keyboard.current.aKey.isPressed)
        {
            Debug.Log("We are pushing left");
            
        }

        else if (Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.dKey.isPressed)
        {
            Debug.Log("We are pushing right");
        }
        
        transform.Rotate(0,0,steerSpeed);
        transform.Translate(0, moveSpeed, 0);
    }
}
