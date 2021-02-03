using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Moving : MonoBehaviour
{
    private SpriteRenderer _sprite = null;
    private Rigidbody2D _rigidbody = null;

    [Range(1f, 10f)] 
    [SerializeField] private float _jumpForce = 10;
    
    private float _direction = 1;
    
    [Range(1f, 10f)] 
    [SerializeField] private float _speed = 1f;

    [SerializeField] private int _maxJump = 2;
    private int _countJump = 0;

    private Camera _camera = null;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _camera = Camera.main;
        _countJump = _maxJump;
        //_rigidbody.isKinematic = true;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && _countJump > 0)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _countJump--;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //_direction *= -1;
        //_sprite.flipX = _direction < 0;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        _countJump = _maxJump;
    }

    private void FixedUpdate()
    {
        Vector2 view = _camera.WorldToViewportPoint(transform.position);
        if (view.x < 0.05f || view.x > 0.95f)
        {
            _direction *= -1;
            _sprite.flipX = _direction < 0;
        }
        //transform.Translate(_direction.normalized * (_speed * Time.fixedDeltaTime));

        _rigidbody.velocity  = new Vector2(_direction * (_speed * 1), _rigidbody.velocity.y);
    }
}
