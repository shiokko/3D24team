using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text moneyText;
    public int money = 0;
    public int totalCustomers = 10;
    public GameObject customerPrefab;
    public Transform spawnPoint;
    private List<string> menuItems = new List<string>();

    void UpdateMoneyText()
    {
        moneyText.text = "$ " + money;
    }

    void Start()
    {
        InitializeMenu();
        UpdateMoneyText();
        StartRound();
    }

    void InitializeMenu()
    {
        menuItems.Add("BeefBurger");
        menuItems.Add("PorkBurger");
        menuItems.Add("Salad");
    }

    void StartRound()
    {
        StartCoroutine(SpawnCustomers());
    }

    IEnumerator SpawnCustomers()
    {
        int customersToSpawn = Mathf.Min(totalCustomers, 2);
        for (int i = 0; i < customersToSpawn; i++)
        {
            GameObject customer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
            customer.GetComponent<customer>().orderedItem = menuItems[Random.Range(0, menuItems.Count)];
            yield return new WaitForSeconds(2f);
        }
        totalCustomers -= customersToSpawn;
        if (totalCustomers > 0)
        {
            EndRound();
        }
        else
        {
            EndGame();
        }
    }

    void EndRound()
    {
        StartRound();
    }

    void EndGame()
    {
        moneyText.text = "Earn $ " + money + "today!";
    }

    public void UpdateMoney(string orderedItem)
    {
        int earnings = 0;

        if (orderedItem == "Beef Burger")
        {
            earnings += 70;
        }
        else if (orderedItem == "Pork Burger")
        {
            earnings += 70;
        }
        else if (orderedItem == "Salad")
        {
            earnings += 40; 
        }
        money += earnings;
        UpdateMoneyText();
    }
}
