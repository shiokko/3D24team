using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class ChefInventory : MonoBehaviour
{
    private List<string> loots;

    public List<string> Loots()
    {
        return loots;
    }

    void Start()
    {
        loots = new List<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Print the collected loots

            var str = new StringBuilder("Loots: [");
            foreach (var loot in loots)
            {
                str.Append(loot);
                str.Append(", ");
            }
            if (loots.Count > 0)
            {
                str.Remove(str.Length - 2, 2);
            }
            str.Append("]");
            Debug.Log(str.ToString());
        }
    }

    public void AddLoot(string lootName)
    {
        // Add the loot name to the inventory
        loots.Add(lootName);
    }
}
