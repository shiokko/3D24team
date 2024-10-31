using UnityEngine;

public class CattleGeneric : MonoBehaviour
{
    public bool isKilled;
    public string lootName;

    void Start()
    {
        if (isKilled)
        {
            KillUnchecked();
        }
    }

    public void Kill()
    {
        if (!isKilled)
        {
            KillUnchecked();
            isKilled = true;
        }
    }

    void KillUnchecked()
    {
        // Play the death animation
        var ani = GetComponent<Animator>();
        ani.SetInteger("State", 2);

        // Change the tag to "loot"
        gameObject.tag = "loot";
        name = lootName;

        // Make rigidbody static
        var rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }
}
