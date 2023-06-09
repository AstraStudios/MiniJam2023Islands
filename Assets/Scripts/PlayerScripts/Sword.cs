using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float swingTime = .5f;
    [SerializeField] float swingDistance = 1f;

    [HideInInspector] public bool swinging = false;
    private float startedSwingingAt;

    void Start()
    {
        startedSwingingAt = 0f;
    }

    void Update()
    {
        // face mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - player.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);


        // follow player
        transform.position = player.position;

        // swinging
        if (Input.GetMouseButtonDown(0) && !swinging) // start
        {
            startedSwingingAt = Time.time;
            swinging = true;
        }
        if (Time.time - startedSwingingAt >= swingTime) swinging = false; // end
        if (swinging) // for each frame
        {
            Vector3 forward = new Vector3(swingDistance * Mathf.Cos(angle * Mathf.Deg2Rad), swingDistance * Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            transform.position += forward;
        }
    }
}
