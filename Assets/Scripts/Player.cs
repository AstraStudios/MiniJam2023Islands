using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Sword sword;

    void Start()
    {
        sword = gameObject.GetComponentInChildren<Sword>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sword.FacePosition(mousePosition);

        if (Input.GetMouseButtonDown(0) && !sword.swinging)
        {
            sword.StartAttack();
        }
    }
}
