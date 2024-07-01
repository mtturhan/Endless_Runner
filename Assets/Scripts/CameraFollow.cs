using UnityEngine;
//kameran�n oyuncuyu takip etmesini sa�lar.

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;

    void Start()
    {
        //offset, kameran�n ve oyuncunun ba�lang�� ??konumu aras�ndaki fark� saklar.
        //offset de�eri hesaplama.
        offset = transform.position - player.position;
    }

    void Update()
    {
        //kamera pozisyonu ayarlan�r,
        Vector3 targetPos = player.position + offset;
        
        //ancak yaln�zca x konumu (yatay) sabitlenir.
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
