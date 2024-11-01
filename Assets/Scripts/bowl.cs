using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl : MonoBehaviour
{
    public Sprite[] sprites;
    private int vegetableCount = 0;
    private bool addSauce = false;
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
        if (collision.CompareTag("cut_vege"))
        {
            vegetableCount++;
            Destroy(collision.gameObject);
            UpdateSprite();
        }

        if (collision.CompareTag("sauce"))
        {
            addSauce = true;
            UpdateSprite();
            isDone = true;
        }
    }

    private void UpdateSprite()
    {
        if (vegetableCount < sprites.Length)
        {
            spriteRenderer.sprite = sprites[vegetableCount];
        }
    }
}
