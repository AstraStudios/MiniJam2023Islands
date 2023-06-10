using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : GenericSingleton<UImanager>
{
    [SerializeField] Image healthBar;

    public void DisplayResources(float wood, float stone) { }
    public void DisplayPlayerHealthBar(float health) {
        healthBar.fillAmount = Mathf.Clamp01(health / 100);
    } // out of 100
    public void DisplayEnemyHealth(List<Vector3> enemies) { } // vector 3 being (x, y, health) in world cords

    private void Update()
    {
        DisplayEnemyHealth(Enemy.enemyList);
    }
}
