using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayo : MonoBehaviour
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
        StartCoroutine(ReturnToOriginalPosition());
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}
