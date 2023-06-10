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
    [SerializeField] GameObject parent;

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

                    GameObject islandObj = Instantiate(randIsland, islandPosition, Quaternion.identity);

                    islandObj.transform.parent = parent.transform;
                }

                // create bridge to left (if not farthest left island)
                Vector3 leftBridgePosition = islandPosition - new Vector3(DISTANCE_BETWEEN_X / 2, 0, 0);
                if (x != -(int)(width / 2))
                {
                    GameObject bridgeObj = Instantiate(sideBridge, leftBridgePosition, Quaternion.identity);
                    bridgeObj.transform.parent = parent.transform;
                }
                else
                {
                    GameObject barrierObj = Instantiate(sideBarrier, leftBridgePosition, Quaternion.identity);
                    barrierObj.transform.parent = parent.transform;
                }

                // create bridge below (if not bottom island)
                Vector3 bottomBridgePosition = islandPosition - new Vector3(0, DISTANCE_BETWEEN_Y / 2, 0);
                if (y != -(int)(height / 2))
                {
                    GameObject bridgeObj = Instantiate(bottomBridge, bottomBridgePosition, Quaternion.identity);
                    bridgeObj.transform.parent = parent.transform;
                }
                else
                {
                    GameObject barrierObj = Instantiate(bottomBarrier, bottomBridgePosition, Quaternion.identity);
                    barrierObj.transform.parent = parent.transform;
                }

                // create barriers on right and top
                if (x == width-(int)(width/2)-1)
                {
                    Vector3 rightBridgePosition = islandPosition + new Vector3(DISTANCE_BETWEEN_X / 2, 0, 0);
                    GameObject barrierObj = Instantiate(sideBarrier, rightBridgePosition, Quaternion.identity);
                    barrierObj.transform.parent = parent.transform;
                }
                if (y == (int)(height / 2)-1)
                {
                    Vector3 aboveBridgePosition = islandPosition + new Vector3(0, DISTANCE_BETWEEN_Y / 2, 0);
                    GameObject barrierObj = Instantiate(bottomBarrier, aboveBridgePosition, Quaternion.identity);
                    barrierObj.transform.parent = parent.transform;
                }
            }
        }
    }
}
