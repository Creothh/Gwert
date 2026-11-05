using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;

    void FixedUpdate()
    {
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            moveInput.x = 0;
            moveInput.y = 0;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveInput.x = -1;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveInput.x = 1;

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                moveInput.y = 1;

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                moveInput.y = -1;
        }

        rigidBody.linearVelocity = moveInput.normalized * speed;
    }
}
