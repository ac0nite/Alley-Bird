using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float _jumpForce = 10;

    [SerializeField] private int _maxJump = 2;
    private int _countJump = 0;

    private Rigidbody2D _rigidbody = null;
    private Animator _animator = null;

    private void Start()
    {
        _countJump = _maxJump;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        GameManger.Instance.Input.EventJump += OnJump;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
            GameManger.Instance.Input.EventJump -= OnJump;
    }

    private void OnJump()
    {
        if (_countJump > 0)
        {
            _animator.SetTrigger("Fly");
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _countJump--;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _countJump = _maxJump;
    }
}
