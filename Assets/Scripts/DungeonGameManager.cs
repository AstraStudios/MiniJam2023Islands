using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> dungeonPrefabs = new List<GameObject>();


    private void Awake()
    {
        SpawnRandDungeon();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandDungeon()
    {
        if (SceneManager.GetActiveScene().name == "DungeonScene")
        {
            int randDungeon = Random.Range(0, dungeonPrefabs.Count);
            Instantiate(dungeonPrefabs[randDungeon], new Vector2(0, 0), Quaternion.identity);
        }
    }
}
