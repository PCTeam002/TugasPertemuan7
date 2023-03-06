using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameplayController : MonoBehaviour
{   
    public GameObject startMenu;
    public GameObject player1;
    public GameObject player2;
    public GameObject targetP1;
    public GameObject targetP2;

    public float timeLimit = 30f;
    private float timeRemaining;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private string turn;
    private Coroutine timerCoroutine;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI scoreWinnerText;

    void Start()
    {
        
    }
    void Update()
    {
        timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining);
    }
    public void SpawnBall()
    {
        turn = "P1";
        timeRemaining = timeLimit;
        timerCoroutine = StartCoroutine(TimerCoroutine());
        Instantiate(player1, new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(targetP1, new Vector3(Random.Range(-8, 8), 1, Random.Range(-8, 8)), Quaternion.identity);
        }
    }
    public void removeStartMenu()
    {   
        startMenu.SetActive(false);
        timerText.gameObject.SetActive(true);
        p1ScoreText.gameObject.SetActive(true);
    }
    IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f); // tunggu selama 1 detik
            timeRemaining -= 1f;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                // panggil method untuk ganti pemain setelah waktu habis
                //if turn P1
                if (turn == "P1")
                {
                    EndTurnP1();
                }
                //if turn P2
                else if (turn == "P2")
                {
                    EndTurnP2();
                }
            }
        }
    }
    public void UpdateScorePlayer1()
    {
        scoreP1 += 1;
        p1ScoreText.text = "Score : " + scoreP1;
    }
    public void UpdateScorePlayer2()
    {
        scoreP2 += 1;
        p2ScoreText.text = "Score : " + scoreP2;
    }
    void EndTurnP1()
    {
        // hentikan timer
        StopCoroutine(timerCoroutine);
        // hapus semua bola
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Target P1");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        //destroy player 1
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        Destroy(player1);
        // panggil method untuk ganti pemain
        MenuP2();
    }
    void EndTurnP2()
    {
        // hentikan timer
        StopCoroutine(timerCoroutine);
        // hapus semua bola
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Target P2");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        //destroy player 2
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Destroy(player2);
        // panggil method untuk ganti pemain
        MenuP2();
        //if condition if scoreP1 > scoreP2
        if (scoreP1 > scoreP2)
        {
            winnerText.text = "Player 1 Win";
            scoreWinnerText.text = "Score : " + scoreP1;
        }
        else if (scoreP1 < scoreP2)
        {
            winnerText.text = "Player 2 Win";
            scoreWinnerText.text = "Score : " + scoreP2;
        }
        else
        {
            winnerText.text = "Draw";
            scoreWinnerText.text = "Score : " + scoreP1;
        }
        winnerText.gameObject.SetActive(true);
        scoreWinnerText.gameObject.SetActive(true);
    }
    void MenuP2()
    {
        startMenu.SetActive(true);
        timerText.gameObject.SetActive(false);
        p1ScoreText.gameObject.SetActive(false);
        p2ScoreText.gameObject.SetActive(false);
    }
    public void Player2()
    {
        turn = "P2";
        startMenu.SetActive(false);
        timerText.gameObject.SetActive(true);
        p2ScoreText.gameObject.SetActive(true);
        
        timeRemaining = timeLimit;
        timerCoroutine = StartCoroutine(TimerCoroutine());
        Instantiate(player2, new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(targetP2, new Vector3(Random.Range(-8, 8), 1, Random.Range(-8, 8)), Quaternion.identity);
        }
    }

}
