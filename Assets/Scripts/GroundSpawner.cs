using UnityEngine;

//zemin parçalarının oluşturulmasını ve yerlerine engellerin ve altınların yerleştirilmesini kontrol eder.
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    //SpawnTile, yeni bir zemin parçası oluşturur ve üzerine engelleri ve altınları yerleştirir.
    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}