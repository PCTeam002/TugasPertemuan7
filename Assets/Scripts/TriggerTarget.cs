using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTarget : MonoBehaviour
{
    //get function from another script named "GameplayController" that has function named "UpdateScorePlayer1()"
    public GameplayController gameplayController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target P1"))
        {
            Destroy(other.gameObject);
            gameplayController.UpdateScorePlayer1();
        }
        if (other.gameObject.CompareTag("Target P2"))
        {
            Destroy(other.gameObject);
            gameplayController.UpdateScorePlayer2();
        }
    }
    
}
