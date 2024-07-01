using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alt�nlar�n toplanmas� ve kaybolmas� i�in gereken mant�k.

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    //alt�nlarla �arp��ma tespit edilir ve oyuncunun skorunu art�r�r.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        // coinlerin kaybolmas�
        Destroy(gameObject);
        
        // oyuncunun skorunun g�z�kmesi
        GameManager.inst.IncrementScore();
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
