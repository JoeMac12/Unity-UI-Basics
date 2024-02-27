using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void ModifyScore(int change) // Main method
    {
        if (change == 0)
        {
            score = 0;
        }
        else
        {
            score += change;
        }
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = score.ToString("D9"); // Format
    }
}
