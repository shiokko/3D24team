using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
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
            CheckForIngredient();
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private void CheckForIngredient()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("vege"))
            {
                ReplaceIngredient(hitCollider);
                break;
            }
        }
    }

    private void ReplaceIngredient(Collider2D vege)
    {
        var vegeScript = vege.GetComponent<raw_vege>();
        if (vegeScript != null && !vegeScript.isInBasket)
        {
            GameObject cutvege = Instantiate(vegeScript.cutVersion, vege.transform.position, Quaternion.identity);
            Destroy(vege.gameObject);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
