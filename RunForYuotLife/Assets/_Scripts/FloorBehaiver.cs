using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaiver : MonoBehaviour
{
    private PlatformManager platformManager;

    private void OnEnable()
    {
        platformManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
    }

    private void OnBecameInvisible()
    {
        //Recycle this floor
        platformManager.RecyclePlatform(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log($"Player reached The end of the platform in {Time.realtimeSinceStartup} seconds");
            other.GetComponentInParent<PlayerAgeBehaiver>().AgePlayer();
        }
    }

}
