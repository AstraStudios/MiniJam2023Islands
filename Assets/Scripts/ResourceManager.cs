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

        if (resources == null)
        {
            resources = new Dictionary<string, int>()
            {
                { "Rock", 0 },
                { "Tree", 0 }
            };
        }
    }

    public void AddResource(string ResourceType, int amount)
    {
        if (!resources.ContainsKey(ResourceType)) return;

        resources[ResourceType] += amount;

        SaveResources();

        UImanager.Instance.DisplayResources(PlayerPrefs.GetInt("Wood"), PlayerPrefs.GetInt("Rock"));
        // resourceText.text = "Rocks: " + resources["Rock"].ToString() + ", Trees: " + resources["Tree"].ToString();
    }

    private void SaveResources()
    {
        PlayerPrefs.SetInt("Rock", resources["Rock"]);
        PlayerPrefs.SetInt("Rock", resources["Tree"]);
        PlayerPrefs.Save();
    }

    private void LoadResources()
    {
        if (PlayerPrefs.HasKey("Rock"))
        {
            resources = new Dictionary<string, int>()
            {
                { "Rock", PlayerPrefs.GetInt("Rock") },
                { "Tree", PlayerPrefs.GetInt("Tree") }
            };
        }
    }
}
