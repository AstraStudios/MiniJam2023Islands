using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : MonoBehaviour
{
    [SerializeField] List<GameObject> islandList = new List<GameObject>();

    [SerializeField] int width = 5;
    [SerializeField] int height = 10;

    void Start()
    {
        for (int x = -(int)(width/2); x < width-(int)(width/2); x++)
        {
            for (int y = -(int)(height/2); y < height-(int)(height/2); y++)
            {
                GameObject randIsland = islandList[Random.Range(0, islandList.Count)];
                Vector3 position = new Vector3(x * 35, y * 20, 0);

                Instantiate(randIsland, position, Quaternion.identity);
            }
        }
    }
}
