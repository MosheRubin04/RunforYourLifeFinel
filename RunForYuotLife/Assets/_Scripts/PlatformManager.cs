using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] int platformLegth = 120;
    [SerializeField]  private int zOffset;
    [SerializeField] private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platformPrefab.Length; i++)
        {
            GameObject Flor = Instantiate(platformPrefab[i], new Vector3(0, yOffset, i * platformLegth), Quaternion.Euler(Vector3.zero));
            zOffset += platformLegth;
        }
    }

    public void RecyclePlatform(GameObject platform)
    {
        //Reposition to next z oofset
        platform.transform.position = new Vector3(0, yOffset, zOffset);
        zOffset += platformLegth;
    }
}
