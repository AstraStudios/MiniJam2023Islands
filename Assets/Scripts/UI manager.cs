using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : GenericSingleton<UImanager>
{
    [SerializeField] RectTransform healthBar;

    private void Start()
    {
        healthBar = GameObject.Find("HealthBarInner").GetComponent<RectTransform>();
    }

    public void DisplayResources(float wood, float stone) { }
    public void DisplayPlayerHealthBar(float health)
    {
        healthBar.localScale = new Vector3(230.2151f * (health / 100f), 0.675f, 1f);
        healthBar.anchoredPosition = new Vector3(162.72185f + 230.2151f * (health / 200f), healthBar.anchoredPosition.y, 0);
    } 
    public void DisplayEnemyHealth(List<Vector3> enemies) { } // vector 3 being (x, y, health) in world cords

    private void Update()
    {
        DisplayEnemyHealth(Enemy.enemyList);
    }
}
