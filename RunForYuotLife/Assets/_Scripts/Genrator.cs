using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genrator : MonoBehaviour
{
    [SerializeField] float genreteCooldown = 1f;

    [Header("Obsitcale")]
    [SerializeField] GameObject obsitclCarObj;
    [SerializeField] GameObject obsitclSharkObj;
    [SerializeField] float levelObsticleSlowValue;
    [SerializeField] int obsticaleCount = 1;
    [SerializeField] Mesh bootomObsiclMesh;
    [SerializeField] Mesh midObsiclMesh;

    [Header("Collecteable")]
    [SerializeField] GameObject collecteableObj;
    [SerializeField] int levelCollectableValue;
    [SerializeField] int collecteacleCount = 1;

    [SerializeField] int obsticaleSpawenRate = 1;

    bool next;

    [Header("Position")]
    public int lastPos = 1;

    [SerializeField] float[] posX;
    [SerializeField] float[] posZ;
    [SerializeField] float[] posY;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(WaitSys());
    }

    IEnumerator WaitSys()
    {
        yield return new WaitForSeconds(genreteCooldown);
        next = true;
        Generate();
    }

    void Generate()
    {
        if (!next)
            return;
        int randX = Random.Range(0, 3);
        int randY = Random.Range(0, 3);
        int randZ = Random.Range(0, 3);
        int totalRand = randX + randY + randZ;
        pos.x = posX[randX];
        pos.y = posY[randY];
        pos.z += posZ[randZ];

        if(totalRand > obsticaleSpawenRate)
        {
            if(randY == 0)
            {
                InstantioatObstical(obsitclSharkObj, randY);
            }
            else
            {
                InstantioatObstical(obsitclCarObj, randY);
            }
            obsticaleCount++;
        }
        else
        {
            GameObject instantiuationClone = Instantiate(collecteableObj, pos, collecteableObj.transform.rotation);
            instantiuationClone.GetComponent<Collectable>().myID = obsticaleCount;
            instantiuationClone.transform.SetParent(this.transform);
            instantiuationClone.GetComponent<Collectable>().collecteableValue = levelCollectableValue;
            collecteacleCount++;
        }
        next = false;
    }

    void SetMeshToObstical(int i,GameObject obsiticel )
    {
        switch (i)
        {
            case 0:
                obsiticel.GetComponent<Obstical>().ChangeMeshTo(bootomObsiclMesh);
                obsiticel.name = "Shark Obsitcel";
                return;
            case 1:
                obsiticel.GetComponent<Obstical>().ChangeMeshTo(midObsiclMesh);
                obsiticel.name = "Car Obsitcel";

                return;
            default:
                break;
        }

    }


    void InstantioatObstical(GameObject obsitclObj, int randY)
    {

        GameObject instantiuationClone = Instantiate(obsitclObj, pos, obsitclObj.transform.rotation);
        instantiuationClone.GetComponent<Obstical>().myID = obsticaleCount;
        instantiuationClone.GetComponent<Obstical>().generator = this;
        instantiuationClone.transform.SetParent(this.transform);
        instantiuationClone.GetComponent<Obstical>().obsticleSlowValue = levelObsticleSlowValue;

        instantiuationClone.GetComponent<Obstical>().DetermineColor(randY);
        //SetMeshToObstical(randY, instantiuationClone);
    }

    public void CollectedableMessage(int i)
    {
        if (lastPos == i)
        {
            lastPos++;
            Debug.Log("Not Collected! Ho Ho");            
        }
        else
        {
            Debug.Log("Colected HA HA");
        }
    }


    public void ObsticaleMessage(int i)
    {
        if(lastPos == i)
        {
            lastPos++;
            Debug.Log("Found! HA HA");
        }
        else
        {
            Debug.Log("Not Found! Ho Ho");
        }
    }
}
