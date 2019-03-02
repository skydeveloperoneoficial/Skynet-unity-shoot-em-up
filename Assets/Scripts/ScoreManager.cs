using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : ScriptGlobal
{
    public static int TotalScore;
    public static int multiplication;
    public static string scoreText= "Score: ";

    public Text text;

    public override void Awake()
    {
        TotalScore = 0;
        multiplication = 10;
        base.Awake();
    }




    public override void Update()
    {
        HUDScore();
        base.Update();
    }
    public void HUDScore()
    {
        text.text = scoreText + TotalScore;
    }
    public static void AddScore(int value)
    {
        TotalScore += value * multiplication;
    }
    public static int SetScore(int setvalue)
    {
        return TotalScore += setvalue;
        
    }

    
}
