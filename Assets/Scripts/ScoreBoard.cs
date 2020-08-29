using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;
    int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void ScoreHit()
    {
        score += scorePerHit;
        updateScore();
    }
}
