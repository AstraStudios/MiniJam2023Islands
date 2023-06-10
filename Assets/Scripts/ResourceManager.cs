using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : GenericSingleton<ResourceManager>
{
    private Dictionary<string, int> resources;
    // [SerializeField] TMP_Text resourceText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // initilize dictionary
        resources = new Dictionary<string, int>()
        {
            { "Rock", 0 },
            { "Tree", 0 }
        };
    }

    public void AddResource(string ResourceType, int amount)
    {
        if (!resources.ContainsKey(ResourceType)) return;

        resources[ResourceType] += amount;

        UImanager.Instance.DisplayResources(resources["Tree"], resources["Rock"]);
        // resourceText.text = "Rocks: " + resources["Rock"].ToString() + ", Trees: " + resources["Tree"].ToString();
    }
}
