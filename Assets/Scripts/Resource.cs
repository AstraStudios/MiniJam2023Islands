using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] float health = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;

        if (!otherObj.CompareTag("Player Sword")) return;
        if (!otherObj.GetComponent<Sword>().swinging) return;

        // give player resource
        ResourceManager.Instance.AddResource(gameObject.tag, 1);

        // break if health is to low
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
