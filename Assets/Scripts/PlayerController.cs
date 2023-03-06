using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    float xVal, vVal, zVal, jump, yBound, zBound;

    public float speed = 2.0f;
    public float jumpForce = 2.0f;

    private int score;
    private int timer;

    public TextMeshProUGUI finishText;
    public TextMeshProUGUI timerFinishText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TimerText;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //InvokeRepeating("UpdateScore", 1f, 0.5f);
        //InvokeRepeating("UpdateTimer", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        xVal = Input.GetAxis("Vertical");
        zVal = Input.GetAxis("Horizontal");
        //jump = Input.GetAxis("Jump");

        rb.AddForce(new Vector3(zVal, 0, xVal) * speed);
        
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        }
        Finish();*/
    }
/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            UpdateScore();
        }
    }*/
    /*void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score : " + score;
    }
    void UpdateTimer()
    {
        timer += 1;
        TimerText.text = "Timer : " + timer;
    }
    void SetTimerFinish()
    {
        timerFinishText.text = "Waktu Kamu : " + timer + " Detik";
    }
    void Finish()
    {
        if (score == 10)
        {
            SetTimerFinish();
            TimerText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            finishText.gameObject.SetActive(true);
            timerFinishText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }*/
}
