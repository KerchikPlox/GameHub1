using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private GameObject[] boosts;
    [SerializeField] private int platCount = 20;
    [SerializeField] private float minX = -42.5f, maxX = 42.5f;
    [SerializeField] private float minY = 1.5f, maxY = 12.5f;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject randomPlat;
    [SerializeField] private GameObject randomBoost;
    [SerializeField] private int lastType;

    [SerializeField] private float highestPlat;
    [SerializeField] private List<GameObject> platforms = new List<GameObject>();

    private void Start()
    {
        highestPlat = player.position.y;
        Generate();
    }

    private void Update()
    {
        if (player.position.y + 8f > highestPlat)
        {
            Spawn();
        }
    }

    private void Generate()
    {
        float yPosition = player.position.y;

        for (int i = 0; i < platCount; i++)
        {
            yPosition += Random.Range(minY, maxY);
            Spawn(yPosition);
        }
    }

    private void Spawn(float yPosition = -1)
    {
        if (yPosition == -1) yPosition = highestPlat + Random.Range(minY, maxY);
        float xPosition = Random.Range(minX, maxX);
        RandomizePlat();

        if (lastType == 0)
        {
            RandomizeBoost(xPosition, yPosition);
        }

        GameObject newPlatform = Instantiate(randomPlat, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
        platforms.Add(newPlatform);
        highestPlat = yPosition;
        Remove();
    }

    private void Remove()
    {
        if (platforms.Count > platCount)
        {
            Destroy(platforms[0]);
            platforms.RemoveAt(0);
        }
    }

    private void RandomizePlat()
    {
        float randomValueForPlat = Random.Range(0f, 100f);

        if (randomValueForPlat < 30f)
        {
            randomPlat = platformPrefab[2];
            lastType = 2;
        }
        else if (randomValueForPlat >= 31f && randomValueForPlat < 44f)
        {
            if (lastType == 1)
            {
                randomPlat = platformPrefab[0];
                lastType = 0;
            }
            else
            {
                randomPlat = platformPrefab[1];
                lastType = 1;
            }
        }
        else
        {
            randomPlat = platformPrefab[0];
            lastType = 0;
        }
    }



    private void RandomizeBoost(float xPosition, float yPosition)
    {
        float spawningBoost = Random.Range(0f, 100f);
        float randomValueForBoost = Random.Range(0f, 100f);
        if (spawningBoost > 50f)
        {
            if (randomValueForBoost < 10f) randomBoost = boosts[2];
            else if (10f < randomValueForBoost && randomValueForBoost < 30f) randomBoost = boosts[1];
            else randomBoost = boosts[0];
            GameObject boost = Instantiate(randomBoost, new Vector3(xPosition, yPosition + 0.7f, 0), Quaternion.identity);
        }
    }
}
