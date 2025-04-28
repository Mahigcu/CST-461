using UnityEngine;

public class PlayerController : MonoBehaviour // Changed from PlayerMovement to PlayerController
{
    public float speed = 5f; // Movement speed
    private Vector2 moveInput;

    void HandleMovement()
    {
        // Get input from Arrow Keys or WASD
        moveInput.x = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        moveInput.y = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

        // Move the sprite
        transform.Translate(moveInput * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        HandleMovement(); // Call the movement function
    }
}



