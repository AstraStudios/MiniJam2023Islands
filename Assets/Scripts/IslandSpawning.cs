using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : MonoBehaviour
{
    [SerializeField] List<GameObject> islandList = new List<GameObject>();

    [SerializeField] GameObject sideBridge;
    [SerializeField] GameObject bottomBridge;
    [SerializeField] GameObject sideBarrier;
    [SerializeField] GameObject bottomBarrier;

    [SerializeField] int width = 5;
    [SerializeField] int height = 10;

    private const float DISTANCE_BETWEEN_X = 35;
    private const float DISTANCE_BETWEEN_Y = 20;

    void Start()
    {
        // -(int)(width/2)      = left cords.
        // width-(int)(width/2) = right cords. `width-` to avoid missing a number due to rounding errors
        for (int x = -(int)(width/2); x < width-(int)(width/2); x++)
        {
            for (int y = -(int)(height/2); y < height-(int)(height/2); y++)
            {
                // create island if not at center
                Vector3 islandPosition = new Vector3(x * DISTANCE_BETWEEN_X, y * DISTANCE_BETWEEN_Y, 0);
                if (!(x == 0 && y == 0))
                {
                    GameObject randIsland = islandList[Random.Range(0, islandList.Count)];

                    Instantiate(randIsland, islandPosition, Quaternion.identity);
                }

                // create bridge to left (if not farthest left island)
                Vector3 sideBridgePosition = islandPosition - new Vector3(DISTANCE_BETWEEN_X / 2, 0, 0);
                if (!(x == -(int)(width / 2)))
                    Instantiate(sideBridge, sideBridgePosition, Quaternion.identity);
                else
                    Instantiate(sideBarrier, sideBridgePosition, Quaternion.identity);

                // create bridge below (if not bottom island)
                Vector3 bottomBridgePosition = islandPosition - new Vector3(0, DISTANCE_BETWEEN_Y / 2, 0);
                if (!(y == -(int)(height / 2)))
                    Instantiate(bottomBridge, bottomBridgePosition, Quaternion.identity);
                else
                    Instantiate(bottomBarrier, bottomBridgePosition, Quaternion.identity);
            }
        }
    }
}
