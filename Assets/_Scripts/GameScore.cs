using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script displays the score of the gameplay  
 *  
 */

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Use this for initialization
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000}", score);
        scoreTextUI.text = scoreStr;
    }

}	
