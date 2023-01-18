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
}
