using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component
    }

    void Update()
    {
        // Get input for horizontal (side to side) and vertical (forward/backward) movement
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Apply movement
        Vector3 movement = new Vector3(moveX, rb.velocity.y, moveZ);  // Keep vertical velocity
        rb.velocity = movement;  // Apply movement to Rigidbody, preserving vertical velocity

        // Optionally, you can add jump functionality or any other behavior
    }
}

