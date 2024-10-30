using Unity.VisualScripting;
using UnityEngine;

public class ChefMovementScene1 : MonoBehaviour
{
    // Movement speed of the chef
    [SerializeField]
    private float moveSpeed;

    // Movement input vector
    private Vector2 movement = Vector3.zero;

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        // Press WASD to move the chef using the Rigidbody2D with collision detection

        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrows

        // Get animator parameters
        int state = GetComponent<Animator>().GetInteger("State");

        // Get sprite renderer
        var sprite = GetComponent<SpriteRenderer>();

        // Create a movement vector based on input
        movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize the movement vector to ensure consistent speed in all directions
        if (movement.magnitude > 1f)
        {
            movement = movement.normalized;
        }

        // Flip the sprite based on the movement direction
        sprite.flipX = movement.x == 0 ? sprite.flipX : movement.x < 0;

        // Specify the movement animation based on the velocity
        state = movement.magnitude > 0f ? (state == 0 ? 1 : state) : 0;

        // Calculate the new position
        Vector3 newPosition = GetComponent<Rigidbody2D>().position + moveSpeed * Time.fixedDeltaTime * movement;

        // Move the Rigidbody2D to the new position while respecting collisions
        GetComponent<Rigidbody2D>().MovePosition(newPosition);

        // Update the animator parameters
        GetComponent<Animator>().SetInteger("State", state);
    }
}
