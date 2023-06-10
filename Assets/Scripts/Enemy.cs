using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float attackDistance = 2f;

    private Sword sword;
    private Transform player;

    void Start()
    {
        sword = gameObject.GetComponentInChildren<Sword>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // movement
        if (!sword.attacking)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);

            sword.FacePosition(player.position);
        }

        // attack when close enough
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackDistance && !sword.attacking )
        {
            sword.StartAttack();
        }
    }
}
