using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool built = false;

    public bool left;
    public Vector2 position;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();

        if (!built)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .5f);
        }
        else
            Destroy(gameObject.GetComponent<BoxCollider2D>());
    }

    public void build()
    {
        built = true;

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        Destroy(gameObject.GetComponent<BoxCollider2D>());

        IslandSpawning.Instance.SaveBridge(left, position, true);
    }
}
