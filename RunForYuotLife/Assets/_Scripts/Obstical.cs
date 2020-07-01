using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstical : MonoBehaviour
{

    public int myID;
    public Genrator generator;
    private Renderer rend;
    public float obsticleSlowValue;
    [SerializeField] Mesh obsticelMesh;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        obsticelMesh = GetComponent<MeshFilter>().mesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            generator.ObsticaleMessage(myID);
            other.GetComponentInParent<PlayerMovement>().SlowDowenBy(obsticleSlowValue);
            other.GetComponentInParent<PlayerStrikes>().Strike();
            rend.material.color = Color.black;
        }
    }

    public void ChangeMeshTo(Mesh newMesh)
    {
        obsticelMesh = newMesh;
        
    }

    public void DetermineColor(int i)
    {
        switch (i)
        {
            case 0:
                rend.material.color = Color.blue;
                return;
            case 1:
                rend.material.color = Color.red;
                return;
            case 2:
                rend.material.color = Color.magenta;
                return;

            default:
                ;
                break;
        }
    }

}
