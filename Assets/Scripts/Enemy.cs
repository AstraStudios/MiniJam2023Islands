using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float healthBarYOffset;
    public float health = 100f;

    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float attackDistance = 2f;

    private Sword sword;

    private Transform player;
    private GameObject playerSwordObj;
    private Sword playerSword;
    private GameObject healthBar;

    void Start()
    {
        sword = gameObject.GetComponentInChildren<Sword>();

        player = GameObject.FindWithTag("Player").transform;
        playerSwordObj = GameObject.FindWithTag("Player Sword");
        playerSword = playerSwordObj.GetComponent<Sword>();

        healthBar = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        // movement
        if (!sword.attacking && Vector3.Distance(transform.position, player.position) <= 8f)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);

            sword.FacePosition(player.position);
            healthBar.transform.position = transform.position + new Vector3(0, healthBarYOffset, 0);
        }

        // attack when close enough
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackDistance && !sword.attacking )
        {
            sword.StartAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if hit with player sword
        if (collision.gameObject != playerSwordObj) return;
        if (!playerSword.swinging) return;

        health -= playerSword.monsterDamage;
        healthBar.GetComponent<EnemyHealthBar>().SetHealth(health);
        
        if (health <= 0)
            Destroy(gameObject);
    }
}
