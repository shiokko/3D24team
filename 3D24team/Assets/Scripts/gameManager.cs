using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    // public float timer = 180f;
    // private float timeLeft;
    // public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Image gameOverImage;

    public GameObject customerPrefab;
    private List<string> menuItems = new List<string>();
    public Transform[] spawnPoints;
    private string orderedItem = "";

    public TextMeshProUGUI moneyText;
    public int money = 0;

    void Start()
    {
        // Debug.Log("Start() called.");
        // timeLeft = timer;
        // timerText.text = "Time Left: " + Mathf.Round(timeLeft) + "s";
        gameOverText.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(false);
        menuItems = new List<string> { "BeefBurger", "PorkBurger", "salad"};
        StartCoroutine(SpawnCustomers());
        UpdateMoneyText();
    }

    void Update()
    {
        // timeLeft -= Time.deltaTime;
        // timerText.text = "Time Left: " + Mathf.Round(timeLeft) + "s";

        // if (timeLeft <= 0)
        // {
        //     timerText.text = "Time Left: " + Mathf.Round(timeLeft);
        //     gameOverImage.gameObject.SetActive(true);
        //     gameOverText.gameObject.SetActive(true);
        //     gameOverText.text = "The day is over!\n You earned $" + money + " a day!";
        //     Time.timeScale = 0;
        // }
    }

    private int GetAvailableSpawnPointIndex()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].childCount == 0) 
            {
                return i;
            }
        }
        return -1;
    }

    private IEnumerator SpawnCustomers()
    {
        // Debug.Log("SpawnCustomers() called.");
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                int SP = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[SP];

                if (spawnPoint.childCount > 0)
                {
                    continue;
                }

                SpawnCustomer(spawnPoint, SP);
            }
            yield return new WaitForSeconds(10f);
        }
    }

    private void SpawnCustomer(Transform spawnPoint, int SP)
    {
        GameObject newCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        newCustomer.transform.SetParent(spawnPoint);
        customer customerScript = newCustomer.GetComponent<customer>();
        
        orderedItem = menuItems[Random.Range(0, menuItems.Count)];
        // Debug.Log("SP: " + SP);
        // Debug.Log("randMenuItem: " + orderedItem + " and it's " + orderedItem);
        Debug.Log("Customer spawned at: " + spawnPoint.position);
        Debug.Log("Customer active: " + newCustomer.activeSelf);
        customerScript.SetOrder(orderedItem, SP);
    }

    public void CustomerServed()
    {
        UpdateMoney(orderedItem);
        StartCoroutine(HandleCustomerServed());
    }

    private IEnumerator HandleCustomerServed()
    {
        yield return new WaitForSeconds(2f);
        int spawnIndex = GetAvailableSpawnPointIndex();
        if (spawnIndex != -1)
        {
            SpawnCustomer(spawnPoints[spawnIndex], spawnIndex);
        }
    }

    public void CustomerRejected()
    {
        StartCoroutine(HandleCustomerRejected());
    }

    private IEnumerator HandleCustomerRejected()
    {
        yield return new WaitForSeconds(10f);
        int spawnIndex = GetAvailableSpawnPointIndex();
        if (spawnIndex != -1)
        {
            SpawnCustomer(spawnPoints[spawnIndex], spawnIndex);
        }
    }

    void UpdateMoneyText()
    {
        moneyText.text = "$ " + money;
    }

    public void UpdateMoney(string orderedItem)
    {
        int earnings = 0;

        if (orderedItem == "BeefBurger")
        {
            earnings = 70;
        }
        else if (orderedItem == "PorkBurger")
        {
            earnings = 70;
        }
        else if (orderedItem == "salad")
        {
            earnings = 40; 
        }
        money += earnings;
        UpdateMoneyText();
    }
}
