using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut_vege : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    
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
