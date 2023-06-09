using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : MonoBehaviour
{
    float gridSize = 10f;
    [SerializeField] List<GameObject> islandList = new List<GameObject>();

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
            int randIsland = Random.Range(0, islandList.Count);
            Debug.Log("Spawning: " + islandList[randIsland].name + " at position: " + i);
            float x = Mathf.Round(Random.Range(-50, 50) / gridSize) * gridSize;
            float y = Mathf.Round(Random.Range(-50, 50) / gridSize) * gridSize;
            Vector2 gridPos = new Vector2(x, y);
            Instantiate(islandList[randIsland], gridPos, Quaternion.identity);
        }
    }
}
