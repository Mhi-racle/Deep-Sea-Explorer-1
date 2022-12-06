using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawners : MonoBehaviour
{
    public GameObject chest;
    public float spawnChance = 0.001f;

    private void FixedUpdate()
    {
        if (Random.Range(0f, 1f) <= spawnChance) Instantiate(chest, transform.position, Quaternion.identity);
    }
}
