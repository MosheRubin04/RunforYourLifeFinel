using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallOfDeathBehaiver : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void LateUpdate()
    {
        //MoveTworadsPlayer();
    }



    void MoveTworadsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, player.GetComponent<PlayerMovement>().GetMaxSpeed() / 2);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obsticale" || other.tag == "Collecteable")
        {
            Destroy(other.gameObject);
        }
    }
}
