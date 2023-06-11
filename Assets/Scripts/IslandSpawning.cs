using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : GenericSingleton<IslandSpawning>
{
    [SerializeField] List<GameObject> islandList = new List<GameObject>();

    [SerializeField] GameObject kingIsland;
    [SerializeField] GameObject kingBridge;

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
                bool isKingIsland = (x == 0 && y == (height-1) - (int)(height / 2)); 
                bool isRightOfKingIsland = (x == 1 && y == (height-1) - (int)(height / 2)); 

                // create island if not at center
                Vector3 islandPosition = new Vector3(x * DISTANCE_BETWEEN_X, y * DISTANCE_BETWEEN_Y, 0);
                if (!(x == 0 && y == 0) && !isKingIsland )
                {
                    int islandType = GetIsland(new Vector2(x, y));
                    if (islandType == -1)
                        islandType = Random.Range(0, islandList.Count);

                    GameObject randIsland = islandList[islandType];

                    GameObject islandObj = Instantiate(randIsland, islandPosition, Quaternion.identity);
                    islandObj.transform.parent = parent.transform;

                    SaveIsland(new Vector2(x, y), islandType);
                }
                else if (isKingIsland)
                    Instantiate(kingIsland, islandPosition, Quaternion.identity);

                // create bridge to left (if not farthest left island)
                Vector3 leftBridgePosition = islandPosition - new Vector3(DISTANCE_BETWEEN_X / 2, 0, 0);
                if (x != -(int)(width / 2) && !isKingIsland && !isRightOfKingIsland) //!isRightOfKingIsland)
                {
                    GameObject bridgeObj = Instantiate(sideBridge, leftBridgePosition, Quaternion.identity);
                    Bridge bridge = bridgeObj.transform.GetChild(2).GetComponent<Bridge>();

                    bridge.left = true;
                    bridge.position = new Vector2(x, y);

                    if (GetBridgeBuilt(bridge.left, bridge.position))
                        bridge.build();
                    else
                        SaveBridge(bridge.left, bridge.position, false);

                    bridgeObj.transform.parent = parent.transform;
                }
                else
                {
                    GameObject barrierObj = Instantiate(sideBarrier, leftBridgePosition, Quaternion.identity);
                    barrierObj.transform.parent = parent.transform;
                }

                // create bridge below (if not bottom island)
                Vector3 bottomBridgePosition = islandPosition - new Vector3(0, DISTANCE_BETWEEN_Y / 2, 0);
                if (y != -(int)(height / 2) && !isKingIsland )
                {
                    GameObject bridgeObj = Instantiate(bottomBridge, bottomBridgePosition, Quaternion.identity);
                    Bridge bridge = bridgeObj.transform.GetChild(2).GetComponent<Bridge>();

                    bridge.left = true;
                    bridge.position = new Vector2(x, y);

                    if (GetBridgeBuilt(bridge.left, bridge.position))
                        bridge.build();
                    else
                        SaveBridge(bridge.left, bridge.position, false);

                    bridgeObj.transform.parent = parent.transform;
                }
                else if (isKingIsland)
                {
                    Instantiate(kingBridge, bottomBridgePosition, Quaternion.identity);
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

    // islands are stored like this:
    // for every island there is a key with its cords and its island type as the value
    //      "Island`posx`,`posy`" = islandType
    private string GetPrefKeyForIsland(Vector2 position)
    {
        return "Island" + position.x.ToString() + "," + position.y.ToString();
    }
    private string GetPrefKeyForBridge(bool left, Vector3 position)
    {
        return (left ? "Left" : "Bottom") + position.x.ToString() + "," + position.y.ToString();
    }

    public void ResetSave()
    {
        PlayerPrefs.SetInt("SavedIslands", 0);

        for (int x = -(int)(width / 2); x < width - (int)(width / 2); x++)
        {
            for (int y = -(int)(height / 2); y < height - (int)(height / 2); y++)
            {
                PlayerPrefs.DeleteKey(GetPrefKeyForIsland(new Vector2(x, y)));
                PlayerPrefs.DeleteKey(GetPrefKeyForBridge(false, new Vector2(x, y)));
                PlayerPrefs.DeleteKey(GetPrefKeyForBridge(true, new Vector2(x, y)));
            }
        }

        PlayerPrefs.Save();
    }

    public void SaveIsland(Vector2 position, int islandType)
    {
        PlayerPrefs.SetInt("SavedIslands", 1);
        PlayerPrefs.SetInt(GetPrefKeyForIsland(position), islandType);
        PlayerPrefs.Save();
    }

    public int GetIsland(Vector2 position)
    {
        return PlayerPrefs.GetInt(GetPrefKeyForIsland(position), -1);
    }

    public void SaveBridge(bool left, Vector2 position, bool built)
    {
        PlayerPrefs.SetInt(GetPrefKeyForBridge(left, position), (built ? 1 : 0));
        PlayerPrefs.Save();
    }
    public bool GetBridgeBuilt(bool left, Vector3 position)
    {
        return (PlayerPrefs.GetInt(GetPrefKeyForBridge(left, position), 0) == 1 ? true : false);
    }
}
