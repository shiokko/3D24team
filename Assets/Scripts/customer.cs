using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer : MonoBehaviour
{
    public string orderedItem;
    private gameManager gameManager; 

    void Start()
    {
        gameManager = FindObjectOfType<gameManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(orderedItem))
        {
            gameManager.UpdateMoney(orderedItem);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
