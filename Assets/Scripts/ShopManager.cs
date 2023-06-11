using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject mainPanel;

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
