using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonChest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;

        if (!otherObj.CompareTag("Player Sword")) return;

        Sword sword = otherObj.GetComponent<Sword>();
        if (!sword.swinging) return;

        // give player resource
        ResourceManager.Instance.AddResource("DungeonCoins", 1);

        Destroy(gameObject);
    }
}
