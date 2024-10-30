using UnityEngine;

public class CattleGeneric : MonoBehaviour
{
    private bool isKilled = false;

    public void Kill()
    {
        if (isKilled)
        {
            return;
        }

        // Play the death animation
        var ani = GetComponent<Animator>();
        ani.SetInteger("State", 2);

        // Change the tag to "loot"
        gameObject.tag = "loot";

        // Disable the related components
        isKilled = true;
        GetComponent<CattleWandering>().isKilled = isKilled;
    }
}
