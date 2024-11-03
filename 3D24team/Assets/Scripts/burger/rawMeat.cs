using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rawMeat : MonoBehaviour
{
    public GameObject friedVersion;
    public GameObject prefab_raw;
    private bool isDragging = false;
    public bool isInBowl = true;
    private Vector3 offset;
    private Vector3 originalPosition;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        originalPosition = transform.position;
        if (isInBowl)
        {
            Instantiate(prefab_raw, transform.position, Quaternion.identity);
            isInBowl = false;
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
}
