using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    // The prefab to spawn
    public GameObject prefab;

    // The player transform used to determine where to spawn the item
    public Transform player;

    // Offset from player to randomly spawn
    public float spawnRange = 5.0f;

    // How often we spawn
    public float spawnIntervalSeconds = 5.0f;

    // Fade in time
    public float fadeInSeconds = 1.0f;

    // The maximum # of items to spawn
    public int maxInstances = 2;

    // Keeps track of previous instances spawned
    private List<GameObject> instances;

    void Start()
    {
        instances = new List<GameObject>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            // Remove old instances. Unity sets them to null when destroyed.
            for (int i = instances.Count - 1; i >= 0; i--)
            {
                if (instances[i] == null)
                {
                    instances.RemoveAt(i);
                }
            }

            // Spawn a new instance if we haven't reached the maximum
            if (instances.Count < maxInstances)
            {
                var instance = BuildPrefab();
                instances.Add(instance);
            }

            yield return new WaitForSeconds(spawnIntervalSeconds);
        }
    }

    private GameObject BuildPrefab()
    {
        var instance = Instantiate(prefab);
        instance.transform.position = RandomOffsetFromPlayer;
        var spriteRenderer = instance.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            StartCoroutine(FadeIn(spriteRenderer));
        }
        return instance;
    }

    private IEnumerator FadeIn(SpriteRenderer spriteRenderer)
    {
        float startTime = Time.time;
        var color = spriteRenderer.color;
        while (spriteRenderer != null)
        {
            color.a = (Time.time - startTime) / fadeInSeconds;
            if (color.a >= 1)
            {
                break;
            }
            spriteRenderer.color = color;
            yield return null;
        }
    }

    private Vector3 RandomOffsetFromPlayer
    {
        get
        {
            Vector3 position = player.transform.position;
            position.x += (Random.value - .5f) * 2 * spawnRange;
            position.y += (Random.value - .5f) * 2 * spawnRange;
            return position;
        }
    }
}