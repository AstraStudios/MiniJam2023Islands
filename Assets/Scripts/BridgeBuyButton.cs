using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuyButton : MonoBehaviour
{
    Bridge bridge;
    [SerializeField] bool kingBridge;

    void Start()
    {
        bridge = transform.parent.GetComponent<Bridge>();

        if (bridge.built)
            gameObject.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Bridge Button"));

            if (hit.collider == null) return;
            if (hit.collider.gameObject != gameObject) return;

            string resource = (kingBridge ? "DungeonCoins" : "Tree");
            int resourceAmount = (kingBridge ? 5 : 10);

            if (ResourceManager.Instance.resources[resource] < resourceAmount) return;
            ResourceManager.Instance.AddResource(resource, -resourceAmount);

            bridge.build();

            gameObject.SetActive(false);
        }
    }
}
