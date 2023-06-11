using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> dungeonPrefabs = new List<GameObject>();
    GameObject dungeonChest;

    private void Awake()
    {
        SpawnRandDungeon();

        dungeonChest = GameObject.Find("Dungeon Chest");
        dungeonChest.SetActive(false);
    }

    void SpawnRandDungeon()
    {
        if (SceneManager.GetActiveScene().name == "DungeonScene")
        {
            int randDungeon = Random.Range(0, dungeonPrefabs.Count);
            Instantiate(dungeonPrefabs[randDungeon], new Vector2(0, 0), Quaternion.identity);
        }
    }

    private void Update()
    {
        // if there are no more enemies
        if (!(GameObject.FindGameObjectWithTag("Enemy")) && dungeonChest)
            dungeonChest.SetActive(true);
    }
}
