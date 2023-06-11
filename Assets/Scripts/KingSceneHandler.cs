using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSceneHandler : MonoBehaviour
{
    [SerializeField] GameObject bossfightPrefab;
    [SerializeField] GameObject room1prefab;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bossFightAudio;
    Vector2 spawnLoc;
    bool inZone;

    // Start is called before the first frame update
    void Start()
    {
        spawnLoc = player.transform.position;
        inZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone == true)
        {
            room1prefab.SetActive(false);
            Instantiate(bossfightPrefab, new Vector2(0, 0), Quaternion.identity);
            player.transform.position = spawnLoc;
            audioSource.clip = bossFightAudio;
            audioSource.Play();
            print("HELLO NIGRECT");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone = false;
    }
}
