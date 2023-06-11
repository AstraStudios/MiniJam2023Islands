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
        Sword sword = otherObj.GetComponent<Sword>();
        if (!sword.swinging) return;

        int damage = (gameObject.CompareTag("Tree") ?
                sword.treeDamage :
                sword.rockDamage
            );

        // give player resource
        ResourceManager.Instance.AddResource(gameObject.tag, damage);

        // break if health is to low
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
