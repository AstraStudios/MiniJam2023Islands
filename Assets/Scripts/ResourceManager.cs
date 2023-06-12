using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : GenericSingleton<ResourceManager>
{
    public Dictionary<string, int> resources;
    // [SerializeField] TMP_Text resourceText;

    void Start()
    {
        LoadResources();
        UImanager.Instance.DisplayResources(PlayerPrefs.GetInt("Tree"), PlayerPrefs.GetInt("Rock"), PlayerPrefs.GetInt("DungeonCoins"));

        if (resources == null)
        {
            resources = new Dictionary<string, int>()
            {
                { "Rock", 0 },
                { "Tree", 0 },
                { "DungeonCoins", 0 }
            };
        }
    }

    public void AddResource(string ResourceType, int amount)
    {
        if (!resources.ContainsKey(ResourceType)) return;

        resources[ResourceType] += amount;

        SaveResources();

        UImanager.Instance.DisplayResources(PlayerPrefs.GetInt("Tree"), PlayerPrefs.GetInt("Rock"), PlayerPrefs.GetInt("DungeonCoins"));
        // resourceText.text = "Rocks: " + resources["Rock"].ToString() + ", Trees: " + resources["Tree"].ToString();
    }

    private void SaveResources()
    {
        PlayerPrefs.SetInt("Rock", resources["Rock"]);
        PlayerPrefs.SetInt("Tree", resources["Tree"]);
        PlayerPrefs.SetInt("DungeonCoins", resources["DungeonCoins"]);
        PlayerPrefs.Save();
    }

    private void LoadResources()
    {
        if (PlayerPrefs.HasKey("Rock"))
        {
            resources = new Dictionary<string, int>()
            {
                { "Rock", PlayerPrefs.GetInt("Rock") },
                { "Tree", PlayerPrefs.GetInt("Tree") },
                { "DungeonCoins", PlayerPrefs.GetInt("DungeonCoins") }
            };
        }
    }
}