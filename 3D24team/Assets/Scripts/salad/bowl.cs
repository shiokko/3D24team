using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl : MonoBehaviour
{
    public int vegetableCount = 0;
    public bool isDone = false;
    private bool isDragging = false;
    private bool createBowl = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    public GameObject prefab_raw;
    public GameObject bowlTopObject;
    private bowlTop bowlTop;

    void Start()
    {
        bowlTop = bowlTopObject.GetComponent<bowlTop>();
        vegetableCount = 0;
        isDone = false;
        createBowl = false;
        bowlTop.ResetSprite();
    }
    
    void OnMouseDown()
    {
        if (isDone)
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
            originalPosition = transform.position;
            if (!createBowl)
            {
                Instantiate(prefab_raw, transform.position, Quaternion.identity);
                createBowl = true;
            }
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
        if (collision.CompareTag("cut_lettuce") && vegetableCount == 0)
        {
            bowlTop.ChangeSprite(vegetableCount);
            vegetableCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("cut_tomato") && vegetableCount == 1)
        {
            bowlTop.ChangeSprite(vegetableCount);
            vegetableCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("cut_cucumber") && vegetableCount == 2)
        {
            bowlTop.ChangeSprite(vegetableCount);
            vegetableCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("mayo") && vegetableCount == 3)
        {
            bowlTop.ChangeSprite(vegetableCount);
            isDone = true;
        }
    }
}
