using System;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public int balance;

    void Start()
    {
        UpdateText();
    }

    public void Deposit(int amount)
    {
        balance += amount;
        UpdateText();
    }

    public void Withdraw(int amount)
    {
        balance = Math.Max(balance - amount, 0);
        UpdateText();
    }

    public bool IsAffordable(int price)
    {
        return balance >= price;
    }

    void UpdateText()
    {
        var balanceText = GetComponentInChildren<TextMeshProUGUI>();
        if (balanceText != null)
        {
            balanceText.text = $"${balance}";
        }
    }
}