using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int initscore;
    public int shiptotal = 0;
    public Text textscore2;


    public void SetScore(int score)
    {
        //print(shiptotal);
        //shiptotal = PlayerPrefs.GetInt("scoreship");
        //print(shiptotal);
        initscore = initscore + score + shiptotal;
        textscore2.text= "SCORE: "+initscore.ToString();
        PlayerPrefs.SetInt("scoretotal", initscore);
        PlayerPrefs.SetInt("scoreship", 0);

    }


}
