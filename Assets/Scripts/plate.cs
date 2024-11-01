using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Sprite[] sprites; 
    private int ingredientCount = 0;
    private string burgerType = "";
    private SpriteRenderer spriteRenderer;
    public bool isDone = false;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    public GameObject prefab_raw;
    
    void OnMouseDown()
    {
        if (isDone)
        {
            isDragging = true;
            Instantiate(prefab_raw, transform.position, Quaternion.identity);
            offset = transform.position - GetMouseWorldPosition();
            originalPosition = transform.position;
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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bread") || collision.CompareTag("cut_vege") || collision.CompareTag("friedEgg") || collision.CompareTag("sauce"))
        {
            ingredientCount++;
            Destroy(collision.gameObject);
            UpdateSprite(); 
        }

        if (collision.CompareTag("friedBeef") || collision.CompareTag("friedPork"))
        {
            ingredientCount++;
            burgerType = collision.CompareTag("rawBeef") ? "BeefBurger" : "PorkBurger"; 
            Destroy(collision.gameObject); 
            UpdateSprite(); 
        }

        if (ingredientCount == 7) 
        {
            isDone = true;
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (isDone)
        {
            gameObject.tag = burgerType;
            spriteRenderer.sprite = sprites[sprites.Length - 1];
        }
        else if (ingredientCount < sprites.Length)
        {
            spriteRenderer.sprite = sprites[ingredientCount];
        }
    }
}
