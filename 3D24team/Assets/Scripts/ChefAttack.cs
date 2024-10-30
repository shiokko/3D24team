using UnityEngine;

public class ChefAttack : MonoBehaviour
{
    private bool isAttacking;

    void Start()
    {
        isAttacking = false;
    }

    void FixedUpdate()
    {
        // Get animator parameters
        int aniState = GetComponent<Animator>().GetInteger("State");

        // Press K to attack with the chef
        isAttacking = Input.GetKey(KeyCode.K);

        // Specify the attack animation based on the attack state
        aniState = isAttacking ? 2 : (aniState == 2 ? 1 : aniState);

        // Update the animator parameters
        GetComponent<Animator>().SetInteger("State", aniState);
    }

    // Make placeholders for trigger collision events (attack hit-area)
    // NOTE: The target to attack has collider components, and with IsTrigger enabled
    // TODO: Implement the attack hit detection logic

    void OnTriggerEnter2D(Collider2D other)
    {
        // Placeholder for handling attack hit detection
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isAttacking && other.CompareTag("cattle"))
        {
            other.GetComponent<Rigidbody2D>().MoveRotation(other.GetComponent<Rigidbody2D>().rotation + 90f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Placeholder for handling end of attack hit detection
    }
}
