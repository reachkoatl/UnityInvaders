using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int initscore;
    public Text textscore2;


    public void SetScore(int score)
    {
        initscore = initscore + score;
       
        textscore2.text= "SCORE: "+initscore.ToString();

        PlayerPrefs.SetInt("scoretotal", initscore);
    }
}
