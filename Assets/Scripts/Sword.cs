using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform follow;

    [SerializeField] float windTime = .175f;
    [SerializeField] float swingTime = .5f;

    [SerializeField] float swingDistance = 1f;
    [SerializeField] float windDistance = .5f;

    [HideInInspector] public bool swinging = false;
    [HideInInspector] public bool winding = false;
    [HideInInspector] public bool attacking = false; // swinging || winding

    private float startedSwingingAt = 0f;

    private float facingAngle = 0f;

    void Update()
    {
        transform.position = follow.position;

        HandleSwing();
    }

    //////////// public methods //////////////

    public void FacePosition(Vector3 position)
    {
        Vector3 direction = position - follow.position;
        facingAngle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3 (0, 0, facingAngle-90);
    }

    public void StartAttack()
    {
        // start swing by winding back
        startedSwingingAt = Time.time;
        winding = true;
    }

    //////////// private methods //////////////

    private void HandleSwing()
    {
        // end winding, start swinging
        if (Time.time - startedSwingingAt >= windTime && winding)
        {
            winding = false;
            swinging = true;
        }
        // end swing
        if (Time.time - startedSwingingAt >= swingTime + windTime && swinging)
            swinging = false;

        // move/swing sword
        Vector3 forward = new Vector3(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad), 0);
        if (winding)
            transform.position -= forward*windDistance;
        if (swinging)
            transform.position += forward*swingDistance;

        attacking = winding || swinging;
    }
}
