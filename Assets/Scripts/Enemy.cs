using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool infinateSight = false;
    [SerializeField] float healthBarYOffset;
    public float health = 100f;

    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float attackDistance = 2f;

    private Sword sword;

    private Transform player;
    private GameObject playerSwordObj;
    private Sword playerSword;
    private GameObject healthBar;

    // needs to be invunrable after hit so it dousent double register hits when its sword gets hit
    private float invunrableAfterHitTime = .1f;
    private float iWasHitAt = Mathf.NegativeInfinity; // time
    public bool invunrable = false;


    void Start()
    {
        sword = gameObject.GetComponentInChildren<Sword>();

        player = Player.Instance.gameObject.transform;
        playerSwordObj = player.GetChild(0).gameObject;
        playerSword = playerSwordObj.GetComponent<Sword>();

        healthBar = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        // make player invunrable after hit
        if ((Time.time - iWasHitAt) < invunrableAfterHitTime) invunrable = true;
        else                                                  invunrable = false;

        // movement
        if (!sword.attacking && (infinateSight ? true : Vector3.Distance(transform.position, player.position) <= 8f))
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

        if (invunrable) return;

        health -= playerSword.monsterDamage;
        healthBar.GetComponent<EnemyHealthBar>().SetHealth(health);
        
        if (health <= 0)
            Destroy(gameObject);

        iWasHitAt = Time.time;
    }
}
