using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] List<GameObject> buyingCardObj = new List<GameObject>();
    [SerializeField] List<Image> buyingCardHolders = new List<Image>();
    [SerializeField] GameObject panelParent;

    bool inZone;

    // Start is called before the first frame update
    void Start()
    {
        inZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayShop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            inZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone = false;
    }

    void DisplayShop()
    {
        if (inZone == true && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            shopPanel.SetActive(true);
            mainPanel.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                GameObject cardToPlace = buyingCardObj[Random.Range(0, buyingCardObj.Count)];
                Vector2 whereToSpawn = buyingCardHolders[i].transform.position;
                GameObject toBeParented = Instantiate(cardToPlace, whereToSpawn, Quaternion.identity);
                toBeParented.transform.parent = panelParent.transform;
                Destroy(buyingCardHolders[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inZone = false;
            print("YOU LEFT");
            shopPanel.SetActive(false);
            mainPanel.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
