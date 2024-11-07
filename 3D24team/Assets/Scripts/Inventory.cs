using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new();
    public int Count
    {
        get { return items.Count; }
    }

    private static int nextId = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle visibility of the intermediate object
            var panel = transform.Find("InventoryPanel");
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);

#if UNITY_EDITOR
            // Print the collected items
            var str = new System.Text.StringBuilder("Items: [");
            foreach (var item in items)
            {
                str.Append(item.Name);
                str.Append(", ");
            }
            if (items.Count > 0)
            {
                str.Remove(str.Length - 2, 2);
            }
            str.Append("]");
            Debug.Log(str.ToString());
#endif
        }
    }

    public void AddItem(string itemName)
    {
        var newItem = new Item(itemName, nextId++);
        items.Add(newItem);
        UpdatePanel();
        Debug.Log($"Added {itemName} to inventory.");
    }

    public bool PopOldestItem(string itemName)
    {
        Item oldestItem = null;
        foreach (var item in items)
        {
            if (item.Name == itemName)
            {
                if (oldestItem == null || item.Lives < oldestItem.Lives)
                {
                    oldestItem = item;
                }
            }
        }

        if (oldestItem != null && !oldestItem.IsExpired())
        {
            items.Remove(oldestItem);
            UpdatePanel();
            Debug.Log($"Popped {itemName} from inventory.");
            return true;
        }
        return false;
    }

    public void ClearExpiredItems()
    {
        items.RemoveAll(item => item.IsExpired());
        UpdatePanel();
    }

    public void DecreaseItemLives()
    {
        foreach (var item in items)
        {
            item.Lives -= 1;
        }
        UpdatePanel();
    }

    void UpdatePanel()
    {
        var panel = transform.Find("InventoryPanel");

        InventorySlot[] slots = panel.GetComponentsInChildren<InventorySlot>();
        foreach (var slot in slots)
        {
            var count = items.Count(i => slot.CompareTag(i.Name));
            slot.UpdateCount(count);
        }
    }
}

public class Item
{
    public string Name { get; private set; }
    public int Lives { get; set; }
    public int Id { get; private set; }

    private static readonly Dictionary<string, int> initialLivesTable = new()
    {
        { "lettuce", 1 },
        { "tomato", 3 },
        { "cucumber", 2 },
        { "rawBeef", 3 },
        { "rawPork", 2 },
        { "rawEgg", 3 },
        { "bread", 5 },
        { "mayo", 5 }
    };

    public Item(string name, int id)
    {
        Name = name;
        Lives = initialLivesTable.TryGetValue(name, out int lives) ? lives : 1;
        Id = id;

        if (!initialLivesTable.ContainsKey(name))
        {
            Debug.LogWarning($"Item {name} does not have an initial life value.");
        }
    }

    public bool IsExpired()
    {
        return Lives <= 0;
    }
}
