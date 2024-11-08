using System;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public int balance;

    public bool Bankrupted => balance <= 0;

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

    public bool TryLiquidate(int rent)
    {
        // Pay the rent to the bank
        var bank = GameObject.Find("Bank").GetComponent<Bank>();
        bank.Withdraw(rent);
        return bank.Bankrupted;
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
