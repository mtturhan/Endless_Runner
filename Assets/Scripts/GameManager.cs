using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//oyun y�neticisidir ve oyuncunun skorunu ve h�z�n� takip eder.
public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

    //fonksiyon, skoru art�r�r ve oyuncunun h�z�n� art�r�r.
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
