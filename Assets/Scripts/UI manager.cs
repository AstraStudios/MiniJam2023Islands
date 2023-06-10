using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : GenericSingleton<UImanager>
{
    public void DisplayResources(float wood, float stone) { }
    public void DisplayPlayerHealthBar(float health) { } // out of 100
    public void DisplayEnemyHealth(List<Vector3> enimes) { } // vector 3 being (x, y, health) in world cords

    private void Update()
    {
        DisplayEnemyHealth(Enemy.enemyList);
    }
}
