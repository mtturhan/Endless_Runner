using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//oyun yöneticisidir ve oyuncunun skorunu ve hýzýný takip eder.
public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

    //fonksiyon, skoru artýrýr ve oyuncunun hýzýný artýrýr.
    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;

        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
