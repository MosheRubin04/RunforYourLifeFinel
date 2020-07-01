using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int myID;
    private Genrator generator;
    private Renderer rend;
    public int collecteableValue;

    private void Start()
    {
        generator = GetComponentInParent<Genrator>();
        rend = GetComponentInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            generator.CollectedableMessage(myID);
            other.GetComponentInParent<PlayerScore>().UpdateScore(collecteableValue);
            rend.material.color = Color.green;
        }
    }
}
