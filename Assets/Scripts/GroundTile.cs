using UnityEngine;

//zemin par�alar�n�n olu�turulmas�n� ve �zerlerine engellerin ve alt�nlar�n yerle�tirilmesini sa�lar.

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;

    private void Start()
    {
        //Start fonksiyonunda, groundSpawner belirlenir.
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();

    }

    //zemin par�alar� s�n�rdan ��kt���nda yeni bir zemin par�as� olu�turulur ve eski zemin par�as� yok edilir.
    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    //engellerin olu�turulmas�n� sa�lar.
    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    //Bu fonksiyon, alt�nlar�n olu�turulmas�n� sa�lar.
    public void SpawnCoins()
    {
        //her zemin par�as�na 10 alt�n aatr.
        int coinstoSpawn = 10;
        for (int i = 0; i < coinstoSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
