using TMPro;
using UnityEngine;

public class StoreSlot : MonoBehaviour
{
    public int price;

    void Start()
    {
        UpdatePriceText();
    }

    public void Buy()
    {
        var bank = GameObject.Find("Bank").GetComponent<Bank>();
        var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        if (bank.IsAffordable(price))
        {
            bank.Withdraw(price);
            inventory.AddItem(tag);
            Debug.Log($"Bought {tag} for ${price}.");
        }
        else
        {
            Debug.Log("Not affordable.");
        }
    }

    void UpdatePriceText() {
        var priceText = transform.Find("Price");
        if (priceText != null && priceText.TryGetComponent(out TextMeshProUGUI text)) {
            text.text = $"${price}";
        }
    }
}
