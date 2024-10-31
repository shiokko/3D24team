using UnityEngine;

public class ChefAttack : MonoBehaviour
{
    private bool isAttacking;

    // Current loot being attacked
    private LootGeneric currentLoot;

    // Timestamp when looting started
    private float lootingStartTime;

    void Start()
    {
        isAttacking = false;
        currentLoot = null;
        lootingStartTime = 0f;
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

    // The duration of looting now correctly represents the actual time to loot the loot.
    // All identified bugs have been fixed.
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("cattle") && isAttacking)
        {
            if (other.TryGetComponent<CattleGeneric>(out var cattle))
            {
                cattle.Kill();
            }
        }

        if (other.CompareTag("loot"))
        {
            // Check if the chef is attacking
            if (isAttacking)
            {
                if (other.TryGetComponent<LootGeneric>(out var loot))
                {
                    // Initialize the looting start time if the loot has changed
                    if (currentLoot == null || currentLoot != loot)
                    {
                        currentLoot = loot;
                        lootingStartTime = Time.fixedTime;
                    }

                    // Check if the looting duration has been reached
                    if (Time.fixedTime - lootingStartTime >= loot.Duration())
                    {
                        // Extract the loot
                        if (TryGetComponent<ChefInventory>(out var inventory))
                        {
                            inventory.Collect(loot);
                            Destroy(other.gameObject);
                        }

                        // Reset the looting timer and current loot
                        currentLoot = null;
                        lootingStartTime = 0f;
                    }
                }
            }
            else
            {
                // If not attacking, reset the looting timer and current loot
                currentLoot = null;
                lootingStartTime = 0f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("loot"))
        {
            if (other.TryGetComponent<LootGeneric>(out var loot) && currentLoot == loot)
            {
                // Reset the looting timer and current loot when exiting the loot collider
                currentLoot = null;
                lootingStartTime = 0f;
            }
        }
    }
}
