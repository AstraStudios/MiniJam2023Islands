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
    GameObject swordBefore;

    // Start is called before the first frame update
    void Start()
    {
        swordBefore = GameObject.Find("Player Sword Variant Variant");
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
            GameObject spawnedSword = Instantiate(swordToSpawn, player.transform.position, Quaternion.identity, player.transform);
            PlayerPrefs.SetInt("Rock", PlayerPrefs.GetInt("Rock") - swordCost);
            swordBefore.SetActive(false);
            print("Bought a sword");
        }
    }
}
