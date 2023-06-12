using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UImanager : GenericSingleton<UImanager>
{
    [SerializeField] TMP_Text rockText;
    [SerializeField] TMP_Text treeText;
    [SerializeField] TMP_Text coinText;
    [SerializeField] RectTransform healthBar;

    private void Start()
    {
        DisplayResources(PlayerPrefs.GetInt("Tree"), PlayerPrefs.GetInt("Rock"), PlayerPrefs.GetInt("DungeonCoins"));
    }

    public void DisplayResources(float wood, float stone, float dc) {
        if (!rockText) return;
        rockText.text = stone.ToString();
        treeText.text = wood.ToString();
        coinText.text = dc.ToString();
    }

    public void DisplayPlayerHealthBar(float health)
    {
        healthBar.localScale = new Vector3(230.2151f * (health / 100f), 0.675f, 1f);
        healthBar.anchoredPosition = new Vector3(115f + 227.8294f * (health / 200f), healthBar.anchoredPosition.y, 0);
    } 

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
