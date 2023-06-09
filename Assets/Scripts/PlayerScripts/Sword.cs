using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float sliceTime = .5f;
    [SerializeField] float sliceDistance = 1f;

    private float swordSliceTimer;

    void Start()
    {
        swordSliceTimer = 0f;
    }

    void Update()
    {
        // face mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);


        // follow player
        transform.position = player.position;


        // shoot forward on click
        if (Input.GetMouseButtonDown(0))
        {
            swordSliceTimer = sliceTime;
        }
        if (swordSliceTimer > 0)
        {
            Vector3 forward = new Vector3(sliceDistance*Mathf.Cos(angle * Mathf.Deg2Rad), sliceDistance*Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            transform.position += forward;
        }

        swordSliceTimer -= Time.deltaTime;
    }
}
