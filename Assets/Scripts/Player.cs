using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : GenericSingleton<Player>
{
    Sword sword;

    public float health = 100f;

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject losePanelObj;
    [SerializeField] Image losePanelRenderer;
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

        health -= 20;
        UImanager.Instance.DisplayPlayerHealthBar(health);
        if (health <= 0)
        {
            Time.timeScale = 0;
            gameAudioSource.clip = deathClip;
            gameAudioSource.Play();
            mainPanel.SetActive(false);
            StartCoroutine(FadeTo(255, 1));
            losePanelObj.SetActive(true);
            PlayerPrefs.DeleteAll();
        }

        PlayerPrefs.SetFloat("Health", health);
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = losePanelRenderer.color.a;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);

            losePanelRenderer.color = new Color(0,0,0,currentAlpha);

            yield return null;
        }

        losePanelRenderer.color = new Color(0,0,0, targetAlpha);
    }
}
