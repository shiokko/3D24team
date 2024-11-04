using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class customer : MonoBehaviour
{
    public string orderedItem;
    public TextMeshProUGUI orderText;
    public Image orderImage;
    public Button rejectButton;

    void Start()
    {
        orderText.gameObject.SetActive(true);
        rejectButton.gameObject.SetActive(true);
        orderImage.gameObject.SetActive(true);
    }

    public void SetOrder(string newOrder, int SP)
    {
        orderedItem = newOrder;
        RectTransform orderTextRect = orderText.GetComponent<RectTransform>();
        RectTransform rejectButtonRect = rejectButton.GetComponent<RectTransform>();
        RectTransform orderImageRect = orderImage.GetComponent<RectTransform>();

        Debug.Log("SP: " + SP);
        if (SP == 0)
        {
            orderTextRect.anchoredPosition = new Vector3(-231.8f, 193.49f, 0);
            rejectButtonRect.anchoredPosition = new Vector3(-231.8f, 162.55f, 0);
            orderImageRect.anchoredPosition = new Vector3(-231.8f, 193.49f, 0);
            Debug.Log("txt1: " + orderTextRect.anchoredPosition);
        }

        if (SP == 1)
        {
            orderTextRect.anchoredPosition = new Vector3(57.3f, 193.49f, 0);
            rejectButtonRect.anchoredPosition = new Vector3(57.3f, 162.55f, 0);
            orderImageRect.anchoredPosition = new Vector3(57.3f, 193.49f, 0);
            Debug.Log("txt2: " + orderTextRect.anchoredPosition);
        }

        orderText.text = "I want \n" + orderedItem + "!";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Customer collided with " + other.tag + ", and order is " + orderedItem);
        if (other.CompareTag(orderedItem))
        {
            Serve();
            Destroy(other.gameObject);
        }
    }

    public void Serve()
    {
        FindObjectOfType<gameManager>().CustomerServed();
        HideUI();
        Destroy(gameObject);
    }

    public void Reject()
    {
        FindObjectOfType<gameManager>().CustomerRejected();
        HideUI();
        Destroy(gameObject);
    }

    private void HideUI()
    {
        orderText.gameObject.SetActive(false);
        rejectButton.gameObject.SetActive(false);
        orderImage.gameObject.SetActive(false);
    }
}
