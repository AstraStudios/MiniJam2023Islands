using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLoader : MonoBehaviour
{
    bool playerInZone;
    [SerializeField] bool isKingIsland;

    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInZone && SceneManager.GetActiveScene().name == "MainScene")
        {
            SceneManager.LoadScene("DungeonScene", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInZone && SceneManager.GetActiveScene().name == "DungeonScene")
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInZone && SceneManager.GetActiveScene().name == "MainScene" && isKingIsland == true)
        {
            SceneManager.LoadScene("KingScene", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInZone = false;
    }
}
