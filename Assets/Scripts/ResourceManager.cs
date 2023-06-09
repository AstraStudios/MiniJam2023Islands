using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : GenericSingleton<ResourceManager>
{
    private Dictionary<string, int> resources;

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

        print("Rocks: " + resources["Rock"].ToString() + ", Trees: " + resources["Tree"].ToString());
    }
}
