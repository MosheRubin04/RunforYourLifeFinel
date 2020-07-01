using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; set; }

    public float timeTraveld;
    public float startingTime;

    [SerializeField] TMP_Text scoreText;
    

    public float CalculteTimeTraveld()
    {
        timeTraveld = Time.realtimeSinceStartup;
        return timeTraveld;
    }


    public void UpdateScore(int value)
    {
        Score += value;
        scoreText.text = Score.ToString();
    }


}

