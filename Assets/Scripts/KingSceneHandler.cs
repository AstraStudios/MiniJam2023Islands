using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSceneHandler : MonoBehaviour
{
    [SerializeField] GameObject bossfightPrefab;
    [SerializeField] GameObject bossFightInRoomChecker;
    [SerializeField] GameObject room1prefab;
    [SerializeField] GameObject player;
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
