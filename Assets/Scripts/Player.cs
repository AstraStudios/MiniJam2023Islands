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
    [SerializeField] AudioClip deathClip;
    AudioSource gameAudioSource;

    void Start()
    {
        sword = gameObject.GetComponentInChildren<Sword>();
        gameAudioSource = GetComponent<AudioSource>();
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

        health -= 25;
        UImanager.Instance.DisplayPlayerHealthBar(health);
        if (health <= 0)
        {
            Time.timeScale = 0;
            gameAudioSource.clip = deathClip;
            gameAudioSource.Play();
            mainPanel.SetActive(false);
            losePanel.SetActive(true);
        }
    }
}
