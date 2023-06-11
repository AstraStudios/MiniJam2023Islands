using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuyButton : MonoBehaviour
{
    Bridge bridge;

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

            if (ResourceManager.Instance.resources["Tree"] < 10) return;

            bridge.build();

            gameObject.SetActive(false);
        }
    }
}
