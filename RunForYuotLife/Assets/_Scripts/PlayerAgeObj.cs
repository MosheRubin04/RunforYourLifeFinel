using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgeObj : MonoBehaviour, IMovementStats
{

    [SerializeField] float maxSpeed = 100;
    [SerializeField] float minSpeed = 10;
    [SerializeField] float excelarationRate = 5;

    [SerializeField] float forwerdSpeed;
    [SerializeField] [Range(1, 500)] float turnSpeed;
    [SerializeField] float distance;
    [SerializeField] float slideDuration;
    [SerializeField] float jumpStrength = 50;
    [SerializeField] float jumpDuration = 1;



    public float MaxSpeed { get { return maxSpeed; } }
    public float MinSpeed { get { return minSpeed; } }
    public float ExcelarationRate { get { return excelarationRate; } }
    public float ForwerdSpeed { get { return forwerdSpeed; } }
    public float TurnSpeed { get { return turnSpeed; } }
    public float Distance { get { return distance; } }
    public float SlideDuration { get { return slideDuration; } }
    public float JumpStrength { get { return jumpStrength; } }
    public float JumpDuration { get { return jumpDuration; } }
    
}
