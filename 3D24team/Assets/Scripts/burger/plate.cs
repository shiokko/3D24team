using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public int ingredientCount = 0;
    public bool isDone = false;
    private bool isDragging = false;
    private bool createPlate = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    public GameObject prefab_raw;
    public GameObject plateTopObject;
    private plateTop plateTop;

    void Start()
    {
        plateTop = plateTopObject.GetComponent<plateTop>();
        ingredientCount = 0;
        isDone = false;
        createPlate = false;
        plateTop.ResetSprite();
    }
    
    void OnMouseDown()
    {
        if (isDone)
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
            originalPosition = transform.position;
            if (!createPlate)
            {
                Instantiate(prefab_raw, transform.position, Quaternion.identity);
                createPlate = true;
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
        if (collision.CompareTag("bread") && ingredientCount == 0)
        {
            plateTop.ChangeSprite(ingredientCount);
            ingredientCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("cut_lettuce") && ingredientCount == 1)
        {
            plateTop.ChangeSprite(ingredientCount);
            ingredientCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("friedBeef") && ingredientCount == 2)
        {
            plateTop.ChangeSprite(ingredientCount);
            ingredientCount++;
            gameObject.tag = "BeefBurger";
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("friedPork") && ingredientCount == 2)
        {
            plateTop.ChangeSprite(7);
            ingredientCount++;
            gameObject.tag = "PorkBurger";
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("cut_tomato") && ingredientCount == 3)
        {
            plateTop.ChangeSprite(ingredientCount);
            ingredientCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("cut_cucumber") && ingredientCount == 4)
        {
            plateTop.ChangeSprite(ingredientCount);
            ingredientCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("friedEgg") && ingredientCount == 5)
        {
            plateTop.ChangeSprite(ingredientCount);
            ingredientCount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("bread") && ingredientCount == 6)
        {
            plateTop.ChangeSprite(ingredientCount);
            Destroy(collision.gameObject);
            isDone = true;
        }
    }
}
