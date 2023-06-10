using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float windTime = .175f;
    [SerializeField] float swingTime = .5f;

    [SerializeField] float swingDistance = 1f;
    [SerializeField] float windDistance = .5f;

    [HideInInspector] public bool swinging = false;
    private bool winding = false;

    private float startedSwingingAt;
    private float startedWindingAt;

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

        // start swing by winding back
        if (Input.GetMouseButtonDown(0) && !swinging) // start
        {
            startedSwingingAt = Time.time;
            winding = true;
        }

        // end winding, start swinging
        if (Time.time - startedSwingingAt >= windTime && winding)
        {
            winding = false;
            swinging = true;
        }
        // end swing
        if (Time.time - startedSwingingAt >= swingTime + windTime && swinging)
            swinging = false;

        // move sword
        Vector3 forward = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        if (winding)
            transform.position -= forward*windDistance;
        if (swinging)
            transform.position += forward*swingDistance;
    }
}
