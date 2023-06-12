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

            if (kingBridge)
            {
                if (ResourceManager.Instance.resources["Rock"] < 75) return;
                if (ResourceManager.Instance.resources["DungeonCoins"] < 3) return;
                ResourceManager.Instance.AddResource("Rock", -75);
                ResourceManager.Instance.AddResource("DungeonCoins", -3);
            }
            else {
                if (ResourceManager.Instance.resources["Tree"] < 10) return;
                ResourceManager.Instance.AddResource("Tree", -10);
            }

            bridge.build();

            gameObject.SetActive(false);
        }
    }
}
