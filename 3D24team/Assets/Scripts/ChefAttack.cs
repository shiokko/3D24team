using UnityEngine;
using System.Collections.Generic;

public class ChefAttack : MonoBehaviour
{
    private bool isAttacking;

    // Current loots being attacked
    private List<LootGeneric> currentLoots;

    // Timestamp when looting started for each loot
    private Dictionary<LootGeneric, float> lootingStartTimes;

    void Start()
    {
        isAttacking = false;
        currentLoots = new List<LootGeneric>();
        lootingStartTimes = new Dictionary<LootGeneric, float>();
    }

    void FixedUpdate()
    {
        // Get animator parameters
        int aniState = GetComponent<Animator>().GetInteger("State");

        // Press K to attack with the chef
        isAttacking = Input.GetKey(KeyCode.F);

        // Specify the attack animation based on the attack state
        aniState = isAttacking ? 2 : (aniState == 2 ? 1 : aniState);

        // Update the animator parameters
        GetComponent<Animator>().SetInteger("State", aniState);
    }

    // The duration of looting now correctly represents the actual time to loot the loot.
    // All identified bugs have been fixed.
    void OnTriggerStay2D(Collider2D other)
    {
        if (isAttacking && other.CompareTag("cattle") && other.TryGetComponent<CattleGeneric>(out var cattle))
        {
            cattle.Kill();
        }

        if (isAttacking && other.CompareTag("bus") && other.TryGetComponent<Bus>(out var bus))
        {
            bus.TakeToScene2();
        }

        if (other.CompareTag("loot"))
        {
            // Check if the chef is attacking
            if (isAttacking)
            {
                if (other.TryGetComponent<LootGeneric>(out var loot))
                {
                    // Initialize the looting start time if the loot has changed
                    if (!currentLoots.Contains(loot))
                    {
                        currentLoots.Add(loot);
                        lootingStartTimes[loot] = Time.fixedTime;
                    }

                    // Check if the looting duration has been reached
                    if (Time.fixedTime - lootingStartTimes[loot] >= loot.duration)
                    {
                        // Reset the looting timer and remove the loot from current loots
                        currentLoots.Remove(loot);
                        lootingStartTimes.Remove(loot);

                        // Add the loot name to the inventory and destroy it
                        if (GameObject.Find("Inventory").TryGetComponent<Inventory>(out var inventory))
                        {
                            inventory.AddItem(loot.Name);
                            Destroy(loot.gameObject);
                        }
                    }
                }
            }
            else
            {
                // If not attacking, reset the looting timers and current loots
                currentLoots.Clear();
                lootingStartTimes.Clear();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("loot"))
        {
            if (other.TryGetComponent<LootGeneric>(out var loot) && currentLoots.Contains(loot))
            {
                // Reset the looting timer and remove the loot from current loots when exiting the loot collider
                currentLoots.Remove(loot);
                lootingStartTimes.Remove(loot);
            }
        }
    }
}
