using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private CanvasBehavior canvas;

    private void OnCollisionEnter2D(Collision2D col)
    {
        canvas.ScoreInc();
        Destroy(gameObject);
    }
}
