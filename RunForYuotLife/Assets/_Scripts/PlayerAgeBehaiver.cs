using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgeBehaiver : MonoBehaviour
{
    //[SerializeField] GameObject playerInfentObj;
    //[SerializeField] GameObject playerTeenObj;
    //[SerializeField] GameObject playerOldObj;
    [SerializeField] GameObject[] playerAgingAR;
    
    [SerializeField] float timeToAge;
    [SerializeField] float timeToAgeModifaier;

    [SerializeField] int courentAgeStage = 0;
    PlayerScore playerScore;
    PlayerMovement playerMovement;
    IMovementStats infantStats, teenStats, oldStats;
    IMovementStats[] statsAR;


    private void Start()
    {
        playerScore = GetComponent<PlayerScore>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    public void AgePlayer()
    {
        if(playerScore.CalculteTimeTraveld() > timeToAge)
        {
            playerAgingAR[courentAgeStage].SetActive(false);
            courentAgeStage++;
            if(courentAgeStage >= playerAgingAR.Length)
            {
                courentAgeStage = 0;
            }
            playerAgingAR[courentAgeStage].SetActive(true);
            playerMovement.SetPlayerStandeColider(playerAgingAR[courentAgeStage].GetComponentInChildren<Transform>());
            playerMovement.UpdateStates(playerAgingAR[courentAgeStage].GetComponent<PlayerAgeObj>());
            timeToAge += timeToAgeModifaier;
        }
    }

    public void ResetTimeToAge()
    {
        timeToAge = 10;
    }


}
