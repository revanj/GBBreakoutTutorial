using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveLimit = 4.3f;
    private Rigidbody2D _rigidbody;
    private bool _hasMadeShot;
    private float _movement = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var direction = Input.GetAxis("Horizontal");
        var targetPos = Vector3.right * 
                        (direction * Time.fixedDeltaTime * moveSpeed) 
                        + transform.position;
        if (targetPos.x > moveLimit)
        {
            targetPos.x = moveLimit;
        }
        if (targetPos.x < -moveLimit)
        {
            targetPos.x = -moveLimit;
        }

        _movement = targetPos.x - transform.position.x;
        
        _rigidbody.MovePosition(targetPos);

        if (!_hasMadeShot && Input.GetKey("space"))
        {
            ball.StartMovement(new Vector2(direction, 0.8f));
            _hasMadeShot = true;
        }
    }

    public float GetMovement()
    {
        return _movement;
    }
    
}
