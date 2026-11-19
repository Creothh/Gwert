using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 5f;
    public GameObject projectile;
    Transform position;

    public float ammunition;
    public float reloading;
    public float maxammo;
    public Image ammunitionbar;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (ammunition < maxammo)
        {
            ammunition += reloading * Time.deltaTime;
        }
       
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            moveInput.x = 0;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveInput.x = -1;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveInput.x = 1;
        }

        rigidBody.linearVelocity = moveInput.normalized * speed;

        if (Input.GetKeyDown(KeyCode.Space) && ammunition > 1f)
        {
            Instantiate (projectile, position);
            ammunition -= 1f;
        }

        ammunitionbar.fillAmount = ammunition / maxammo;
    }
}
