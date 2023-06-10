using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : MonoBehaviour
{
    [SerializeField] List<GameObject> islandList = new List<GameObject>();
    [SerializeField] List<Vector2> spawnCords = new List<Vector2>();
    List<GameObject> inGameIsland = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < islandList.Count; i++)
        {
            inGameIsland.Add(islandList[i]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnIslands();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnIslands()
    {
        for (int i = 0; i < islandList.Count; i++)
        {
            int randIsland = Random.Range(0, inGameIsland.Count);
            int randCords = Random.Range(0, spawnCords.Count);
            Debug.Log("Spawning: " + inGameIsland[randIsland].name + " at position: " + spawnCords[randCords]);

            Instantiate(inGameIsland[randIsland], spawnCords[randCords], Quaternion.identity);

            inGameIsland.Remove(inGameIsland[randIsland]);
        }
    }
}
