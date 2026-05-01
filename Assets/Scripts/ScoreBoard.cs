using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score";
    }
    public void ScoreKeeper(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

}
