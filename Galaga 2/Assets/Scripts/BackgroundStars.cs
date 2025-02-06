using UnityEngine;

public class BackgroundStars : MonoBehaviour
{
    public float screenWidth = 90.0f;
    private float halfWidth => screenWidth / 2;
    
    public GameObject starPrefab;

    public float spawnRate = 1f;

    private Vector3 starSpawnPosition = new Vector3();

    private void Start()
    {
        starSpawnPosition.z = 0;

        for (int x = 0; x < 25 / spawnRate; x++)
        {
            starSpawnPosition.y = Random.Range(-halfWidth, halfWidth);
            SpawnStar();
        } 

        starSpawnPosition.y = (halfWidth) + 1;
        InvokeRepeating(nameof(SpawnStar), spawnRate, spawnRate);
    }

    private void SpawnStar()
    {
        if(Random.value < 0.8f)
        {
            starSpawnPosition.x = Random.Range(-halfWidth, halfWidth);

            GameObject newStar = Instantiate(starPrefab, starSpawnPosition, Quaternion.identity);
        }
    }
}
