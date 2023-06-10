using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Sword sword;

    public float health = 100f;

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject losePanel;

    void Start()
    {
        sword = gameObject.GetComponentInChildren<Sword>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sword.FacePosition(mousePosition);
        UImanager.Instance.DisplayPlayerHealthBar(health);

        if (Input.GetMouseButtonDown(0) && !sword.swinging)
        {
            sword.StartAttack();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObj = other.gameObject;

        if (!otherObj.CompareTag("Enemy Sword")) return;
        if (!otherObj.GetComponent<Sword>().swinging) return;

        health -= 10;
        UImanager.Instance.DisplayPlayerHealthBar(health);
        if (health <= 0)
        {
            Time.timeScale = 0;
            mainPanel.SetActive(false);
            losePanel.SetActive(true);
        }
    }
}
