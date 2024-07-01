using UnityEngine;
//kameranýn oyuncuyu takip etmesini saðlar.

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;

    void Start()
    {
        //offset, kameranýn ve oyuncunun baþlangýç ??konumu arasýndaki farký saklar.
        //offset deðeri hesaplama.
        offset = transform.position - player.position;
    }

    void Update()
    {
        //kamera pozisyonu ayarlanýr,
        Vector3 targetPos = player.position + offset;
        
        //ancak yalnýzca x konumu (yatay) sabitlenir.
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
