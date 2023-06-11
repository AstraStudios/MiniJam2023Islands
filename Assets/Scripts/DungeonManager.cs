using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] GameObject breakableWall;

    private void Update()
    {
        // destroy wall when there are no enemies
        if (!GameObject.FindGameObjectWithTag("Enemy") && breakableWall)
            Destroy(breakableWall);
    }
}
