using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{
    private int total;
    public Text textscore;

    // Start is called before the first frame update
    void Start()
    {
        

        total = PlayerPrefs.GetInt("scoretotal");
        textscore.text = "SCORE TOTAL: "+total.ToString();
        PlayerPrefs.SetInt("scoretotal", 0);
    }

}
