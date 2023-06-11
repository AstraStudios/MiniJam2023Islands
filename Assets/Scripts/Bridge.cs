using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool built = false;

    private SpriteRenderer spriteRenderer;

    void Start()
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

        ResourceManager.Instance.AddResource("Tree", -10);
    }
}
