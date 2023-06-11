using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopIdentifier : MonoBehaviour
{
    [SerializeField] GameObject swordToSpawn;
    [SerializeField] int swordCost;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerNoCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSelectedSword()
    {
        if (PlayerPrefs.GetInt("Rock") < swordCost)
            print("You dont have enough money!");
        if (PlayerPrefs.GetInt("Rock") > swordCost)
        {
            GameObject spawnedSword = Instantiate(swordToSpawn, player.transform.position, Quaternion.identity);
            spawnedSword.transform.parent = player.transform;
            PlayerPrefs.SetInt("Rock", PlayerPrefs.GetInt("Rock") - swordCost);
        }
    }
}
