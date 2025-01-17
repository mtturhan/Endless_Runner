using UnityEngine;

//zemin parçalarının oluşturulmasını ve üzerlerine engellerin ve altınların yerleştirilmesini sağlar.

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

    //zemin parçaları sınırdan çıktığında yeni bir zemin parçası oluşturulur ve eski zemin parçası yok edilir.
    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    //engellerin oluşturulmasını sağlar.
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

    //Bu fonksiyon, altınların oluşturulmasını sağlar.
    public void SpawnCoins()
    {
        //her zemin parçasına 10 altın aatr.
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
