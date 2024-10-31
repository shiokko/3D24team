using UnityEngine;
using System.Collections.Generic;

public class ChefInventory : MonoBehaviour
{
    private List<LootGeneric> lootList;

    public List<LootGeneric> LootList()
    {
        return lootList;
    }

    void Start()
    {
        lootList = new List<LootGeneric>();
    }

    public void Collect(LootGeneric loot)
    {
        lootList.Add(loot);
    }
}
