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

    private void OnMouseDown()
    {
        print("click");
        bridge.build();

        gameObject.SetActive(false);
    }
}
