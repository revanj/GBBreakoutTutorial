using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasBehavior : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] private TMP_Text scoreboard;
    public void ScoreInc()
    {
        _score += 1;
        scoreboard.text = "Score: " + _score;
    }
}
