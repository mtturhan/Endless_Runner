using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//engellerin oyuncuya çarptýðýnda ne olacaðýný belirler.

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        //Start fonksiyonunda, playerMovement deðiþkeni belirlenir.
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    //Çarpýþma tespit edilir ve eðer çarpan nesne "Player" ise Die fonksiyonu çaðrýlacak.
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
