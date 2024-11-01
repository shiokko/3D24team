using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raw_vege : MonoBehaviour
{
    public GameObject cutVersion;
    private bool isDragging = false;
    public bool isInBasket = true;
    private Vector3 offset;
    private Vector3 originalPosition;

    public void MoveOutOfBasket()
    {
        isInBasket = false;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        originalPosition = transform.position;
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
}
