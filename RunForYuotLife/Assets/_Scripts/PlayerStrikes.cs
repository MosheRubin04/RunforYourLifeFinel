using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class PlayerStrikes : MonoBehaviour
{

    [SerializeField] int strikeCount = 0;
    [SerializeField] Image chessersImage;

    public void Strike()
    {
        strikeCount++;
        CheckStrikes();
    }

    public void CheckStrikes()
    {
        Vector3 currentPoistion = chessersImage.transform.position;


        switch (strikeCount)
        {

            case 0:
                //image is berly visable
                chessersImage.transform.position = (currentPoistion - new Vector3(0,-40,0));
                return;


            case 1:
                //image is halve visable
                chessersImage.transform.position = (currentPoistion - new Vector3(0, -20, 0));
                return;

            case 2:
                //image is full visable
                chessersImage.transform.position = (currentPoistion - new Vector3(0, 0, 0));                
                return;

            case 3:                             
                GameRestart();
                return;

            default:
                break;
        }
    }

    public void GameRestart()
    {
        Debug.Log("YOU DIE");
        SceneManager.LoadScene(0);
    }

}
