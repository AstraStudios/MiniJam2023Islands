using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : MonoBehaviour
{
    float gridSize = 10f;
    [SerializeField] List<GameObject> islandList = new List<GameObject>();
    Grid worldGrid;


    private void Awake()
    {
        worldGrid = gameObject.GetComponent<Grid>();
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
            int randIsland = Random.Range(0, islandList.Count);
            Debug.Log("Spawning: " + islandList[randIsland].name + " at position: " + i);

            //We can move around this randomness based off how many islands etc
            float x = Mathf.Round(Random.Range(-25, 25) / gridSize) * gridSize;
            float y = Mathf.Round(Random.Range(-25, 25) / gridSize) * gridSize;
            Vector3 worldPos = worldGrid.GetCellCenterWorld(new Vector3Int((int)x, (int)y, 0));

            Instantiate(islandList[randIsland], worldPos, Quaternion.identity);

            islandList.Remove(islandList[randIsland]);
        }
    }
}
