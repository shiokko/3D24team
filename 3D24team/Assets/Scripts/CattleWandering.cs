using UnityEngine;

public class CattleWandering : MonoBehaviour
{
    // Movement speed of the cattle
    [SerializeField]
    private float moveSpeed;

    // Duration of wandering in seconds
    [SerializeField]
    private float wanderingDuration;

    // Probability to decide to wander after duration
    [SerializeField]
    [Range(0f, 1f)]
    private float wanderProbability;

    // Current timer for wandering duration
    private float wanderTimer;

    // Current movement direction
    private Vector2 movementDirection;

    // Flag to indicate if the cattle is wandering
    private bool isWandering;

    // Flag to indicate if the cattle is killed
    public bool isKilled;

    void Start()
    {
        isKilled = false;
        isWandering = false;
        movementDirection = Vector2.zero;
        wanderTimer = 0f;
    }

    void FixedUpdate()
    {
        if (isKilled)
        {
            return;
        }

        // Update the wandering timer
        wanderTimer += Time.fixedDeltaTime;

        if (wanderTimer >= wanderingDuration)
        {
            // Attempt to wander based on probability
            isWandering = Random.value < wanderProbability;

            // Randomize the movement direction
            movementDirection = isWandering ? Random.insideUnitCircle.normalized : Vector2.zero;

            // Flip the sprite based on the movement direction
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = movementDirection.x == 0 ? sprite.flipX : movementDirection.x > 0;

            // Reset the timer
            wanderTimer = 0f;
        }

        // Move the cattle in the current direction if wandering
        if (isWandering)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 newPosition = rb.position + moveSpeed * Time.fixedDeltaTime * movementDirection;
            rb.MovePosition(newPosition);
        }

        // Get animator parameters
        int aniState = GetComponent<Animator>().GetInteger("State");

        // Specify the movement animation based on the wandering state
        aniState = isWandering ? (aniState == 0 ? 1 : aniState) : (aniState == 1 ? 0 : aniState);

        // Update the animator parameters
        GetComponent<Animator>().SetInteger("State", aniState);
    }
}
