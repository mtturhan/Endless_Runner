using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//altýnlarýn toplanmasý ve kaybolmasý için gereken mantýk.

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    //altýnlarla çarpýþma tespit edilir ve oyuncunun skorunu artýrýr.
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

        // coinlerin kaybolmasý
        Destroy(gameObject);
        
        // oyuncunun skorunun gözükmesi
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
