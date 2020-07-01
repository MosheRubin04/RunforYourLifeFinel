using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{    
    public Swipe swipeControls;

    [SerializeField] Transform player;
    [SerializeField] Transform playerStandeColider;
    [SerializeField] Transform playerSlideColldier;
    [SerializeField] float maxSpeed = 100;
    [SerializeField] float minSpeed = 10;
    [SerializeField] float excelarationRate = 5;

    [SerializeField] float forwerdSpeed;
    [SerializeField] [Range(1, 500)] float turnSpeed;
    [SerializeField] float distance;
    [SerializeField] float slideDuration;
    [SerializeField] float jumpStrength = 50;
    [SerializeField] float jumpDuration = 1;


    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    private Vector3 desiredPosition;

    Rigidbody rigid;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerSlideColldier.gameObject.SetActive(false);
        forwerdSpeed = minSpeed;
        
    }

    private void Update()
    {
        MoveForword();
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, forwerdSpeed * Time.deltaTime);
    }


    private void LateUpdate()
    {
        if (swipeControls.SwipeUp)
        {
            //MoveUp();
            StartCoroutine(Jump(jumpDuration));
        }
        if (swipeControls.SwipeDown)
        {
            //MoveDown();
            StartCoroutine(Slide(slideDuration));
        }
        if (swipeControls.SwipeLeft)
        {
            MoveLeft();
        }
        if (swipeControls.SwipeRight)
        {
            MoveRight();
        }

        if (desiredPosition.x > rightEdge.position.x)
        {
            desiredPosition.x = rightEdge.position.x;
            return;
        }           

        else if(desiredPosition.x < leftEdge.position.x)
        {
            desiredPosition.x = leftEdge.position.x;

            return;
        }

        playerStandeColider.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition , turnSpeed * Time.deltaTime);
        //desiredPosition = Vector3.zero;
    }

    public void SetPlayerSlideColider(Transform newSlideColider)
    {
        playerSlideColldier = newSlideColider;
    }

    public void SetPlayerStandeColider(Transform newStandeColider)
    {
        playerStandeColider = newStandeColider;
    }

    void MoveLeft()
    {
        desiredPosition += new Vector3(-distance, 0, 0);  //Vector3.left ;
    }
    void MoveRight()
    {
        desiredPosition += new Vector3(distance, 0, 0);//Vector3.right;
    }
    void MoveUp()
    {
        desiredPosition += new Vector3(0, distance, 0); //Vector3.up;
    }
    void MoveDown()
    {
        desiredPosition += new Vector3(0, -distance, 0); //Vector3.down;
    }
    void MoveForword()
    {
        Excelarete();
        desiredPosition +=  Vector3.forward * forwerdSpeed * Time.deltaTime;        
    }

    IEnumerator Jump(float jumpDuration)
    {
        Debug.Log("Jumped");
        MoveUp();
        playerStandeColider.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, turnSpeed * Time.deltaTime);
        yield return new WaitForSeconds(jumpDuration);
        MoveDown();
    }

    IEnumerator Slide(float slideDuration)
    {
        Debug.Log("Slideing");

        playerStandeColider.gameObject.SetActive(false);
        playerSlideColldier.gameObject.SetActive(true);
        yield return new WaitForSeconds(slideDuration);

        playerStandeColider.gameObject.SetActive(true);
        playerSlideColldier.gameObject.SetActive(false);
    }

    public void SlowDowenBy(float amount)
    {
        if (forwerdSpeed <= minSpeed)
        {
            forwerdSpeed = minSpeed;
            return;
        }

        forwerdSpeed -= amount;
    }

    void Excelarete()
    {
        if (forwerdSpeed >= maxSpeed)
        {
            forwerdSpeed = maxSpeed;
            return;
        }

        forwerdSpeed += excelarationRate;
    }
    public void UpdateStates(IMovementStats stats)
    {
        maxSpeed = stats.MaxSpeed;
        minSpeed = stats.MinSpeed;
        excelarationRate = stats.ExcelarationRate;

        forwerdSpeed = stats.ForwerdSpeed;
        turnSpeed = stats.TurnSpeed;
        distance = stats.Distance;
        slideDuration =stats.SlideDuration;
        jumpStrength = stats.JumpStrength;
        jumpDuration = stats.JumpDuration;
    }

    public float GetForwerdSpeed()
    {
        return forwerdSpeed;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
