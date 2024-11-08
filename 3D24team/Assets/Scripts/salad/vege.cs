using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raw_vege : MonoBehaviour
{
    public GameObject cutVersion;
    public GameObject prefab_raw;
    private bool isDragging = false;
    public bool isInBasket = true;
    public bool isWashed = false;
    private Vector3 offset;
    private Vector3 originalPosition;

    void Start()
    {
        isInBasket = true;
        isWashed = false;
        gameObject.SetActive(GameObject.Find("Inventory").GetComponent<Inventory>().HasItem(tag));
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        originalPosition = transform.position;
        if (isInBasket && GameObject.Find("Inventory").GetComponent<Inventory>().PopOldestItem(tag))
        {
            Instantiate(prefab_raw, transform.position, Quaternion.identity);
            isInBasket = false;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            isWashed = true;
        }
    }
}
