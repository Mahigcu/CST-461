using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float backAndForthSpeed = 2f;  // Speed for back and forth movement
    public float rotationSpeed = 5f;      // Speed for body rotation when turning
    public Transform leftLeg, rightLeg, leftArm, rightArm, body, head;
    public float swingSpeed = 5f;
    public float swingAmount = 30f;
    private float swingTimer = 0f;

    private CharacterController controller;  // For smoother movement
    private bool isArmLifted = false;  // To check if the right arm is lifted

    // Renamed Start to Initialize
    void Initialize()
    {
        // Ensure CharacterController is attached
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController not found on Player object! Please add it.");
        }
    }

    // Renamed Update to PerformMovement
    void PerformMovement()
    {
        if (controller == null) return; // If the controller is missing, skip the movement logic

        // Get Input for movement
        float moveX = Input.GetAxis("Horizontal");  // Left/Right movement (side-to-side)
        float moveZ = Input.GetAxis("Vertical");    // Forward/Backward movement (W/S, Up/Down)

        // Back and forth movement
        float moveBackAndForth = Mathf.Sin(Time.time * backAndForthSpeed) * 0.5f; // Smooth back and forth movement

        // Calculate final movement vector
        Vector3 move = new Vector3(moveX, 0, moveZ + moveBackAndForth) * speed * Time.deltaTime;
        controller.Move(move);

        // Animate arms, legs, body, and head when moving
        if (moveX != 0 || moveZ != 0 || moveBackAndForth != 0)
        {
            swingTimer += Time.deltaTime * swingSpeed; // Increase the timer for smooth swinging
            float swingRotation = Mathf.Sin(swingTimer) * swingAmount; // Create swinging motion

            // Apply rotation to legs
            leftLeg.localRotation = Quaternion.Euler(swingRotation, 0, 0);
            rightLeg.localRotation = Quaternion.Euler(-swingRotation, 0, 0);

            // Apply rotation to arms
            leftArm.localRotation = Quaternion.Euler(-swingRotation, 0, 0);
            rightArm.localRotation = Quaternion.Euler(swingRotation, 0, 0);

            // Apply slight tilt to the body to follow leg movements
            body.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(swingTimer) * 5f);  // Body tilt

            // Apply head rotation with smooth follow effect
            float headRotation = Mathf.Sin(swingTimer * 0.5f) * 5f;  // Head follows body with a delay
            head.localRotation = Quaternion.Euler(headRotation, 0, 0);
        }
        else
        {
            // If there's no movement, reset body, arms, and legs to their default position
            leftLeg.localRotation = Quaternion.identity;
            rightLeg.localRotation = Quaternion.identity;
            leftArm.localRotation = Quaternion.identity;
            rightArm.localRotation = Quaternion.identity;
            body.localRotation = Quaternion.identity;
            head.localRotation = Quaternion.identity;
        }

        // Apply rotation of the whole body based on movement direction
        if (moveX > 0) // Move to the right
        {
            body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * rotationSpeed);
        }
        else if (moveX < 0) // Move to the left
        {
            body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * rotationSpeed);
        }

        if (moveZ > 0) // Move forward (W key or Up arrow)
        {
            body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
        }
        else if (moveZ < 0) // Move backward (S key or Down arrow)
        {
            body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotationSpeed);
        }

        // Lift the right arm when the T key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            isArmLifted = !isArmLifted;  // Toggle arm lifting on T press
            if (isArmLifted)
            {
                // Lift the right arm
                rightArm.localRotation = Quaternion.Euler(90f, 0, 0);  // Right arm lifted
            }
            else
            {
                // Lower the right arm
                rightArm.localRotation = Quaternion.identity;  // Reset to default position
            }
        }
    }

    // Use a different Unity method to call the initialization and movement
    void Awake()
    {
        Initialize();
    }

    void FixedUpdate()
    {
        PerformMovement();
    }
}






