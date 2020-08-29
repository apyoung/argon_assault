using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    
    [SerializeField] float scoreTimeFactor = 5f;
    [SerializeField] int scoreByTime = 12;
    int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        updateScore();
        InvokeRepeating(nameof(ScoreTime), scoreTimeFactor, scoreTimeFactor);
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scoreIncrease)
    {
        this.score += scoreIncrease;
        updateScore();
    }

    private void ScoreTime()
    {
        this.score += scoreByTime;
        updateScore();
    }
}
