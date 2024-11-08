using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        TextMeshProUGUI countText = GetComponentInChildren<TextMeshProUGUI>();
        if (countText != null)
        {
            countText.text = count.ToString();
        }
    }
}
