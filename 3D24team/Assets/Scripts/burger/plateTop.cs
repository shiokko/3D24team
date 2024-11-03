using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateTop : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
    }

    public void ChangeSprite(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }

    public void ResetSprite() 
    {
        spriteRenderer.sprite = defaultSprite;
    }
}
