using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.tvOS;

public class Ball : MonoBehaviour
{
    private Vector2 _currentHeading;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 7f;
    private bool started;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (started)
        {
            _rigidbody.MovePosition((Vector2)transform.position + _currentHeading.normalized * (speed * Time.fixedDeltaTime));
        }
    }

    public void StartMovement(Vector2 initialDirection)
    {
        _currentHeading = initialDirection.normalized * speed;
        transform.parent = null;
        started = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var normal = col.contacts[0].normal;
        if (normal.x != 0)
        {
            _currentHeading.x = -_currentHeading.x;
        }

        if (normal.y != 0)
        {
            _currentHeading.y = -_currentHeading.y;
        }

        var board = col.gameObject.GetComponent<Board>();
        if (board != null)
        {
            _currentHeading.x += board.GetMovement() * 5f;
            _currentHeading = _currentHeading.normalized;
        }
    }
}
