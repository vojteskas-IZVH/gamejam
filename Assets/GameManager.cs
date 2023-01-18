using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public void addScore(){
        score += 1;
        scoreText.text = score.ToString();
    }

    public void endGame(){
        score = 0;
        scoreText.text = "0";
    }
}
