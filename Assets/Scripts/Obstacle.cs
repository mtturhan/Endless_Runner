using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//engellerin oyuncuya �arpt���nda ne olaca��n� belirler.

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        //Start fonksiyonunda, playerMovement de�i�keni belirlenir.
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    //�arp��ma tespit edilir ve e�er �arpan nesne "Player" ise Die fonksiyonu �a�r�lacak.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMovement.Die();  
        }
    }

    private void Update()
    {
        
    }
}
