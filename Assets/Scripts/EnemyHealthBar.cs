using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthBar : MonoBehaviour
{
    Transform healthBar;

    public float fullHealthScale = 1.525f;

    void Start()
    {
        healthBar = transform.GetChild(1);
    }
    
    public void SetHealth(float health)
    {
        healthBar.localScale = new Vector3(fullHealthScale * (health / 100), .1375f, 1f);
        healthBar.localPosition = new Vector3(fullHealthScale * (health / 200) - fullHealthScale/2, 0, 0);
    }
}
