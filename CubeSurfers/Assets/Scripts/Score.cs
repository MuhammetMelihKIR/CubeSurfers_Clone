using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    Text menuScoreText;
    // Start is called before the first frame update
    void Start()
    {
        score= 0;
        scoreText = GetComponent<Text>();
        menuScoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        menuScoreText.text = score.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text=score.ToString();
        menuScoreText.text = score.ToString();
    }
}
