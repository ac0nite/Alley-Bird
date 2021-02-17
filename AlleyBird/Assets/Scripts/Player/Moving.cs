using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Moving : MonoBehaviour
{
    private SpriteRenderer _sprite = null;
    private Rigidbody2D _rigidbody = null;

    private float _direction = 1;
    
    [Range(1f, 10f)] 
    [SerializeField] private float _speed = 1f;

    private Camera _camera = null;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Coin>() != null)
        {
            GameManger.Instance.Score.ChangeCoins(other.GetComponent<Coin>().Cost);
            Destroy(other.gameObject);
        }
        else if (other.GetComponent<Enemy>() != null)
        {
            _speed = 0;
            _sprite.flipY = true;
            UIManager.Instance.ShowUIPanel(TypePanel.Reset);
        }
    }

    private void FixedUpdate()
    {
        var area = GameManger.Instance.LimitAreaX; 
        //var posX = Mathf.Round(transform.position.x);
        var posX = transform.position.x;
        //if (posX < -area || posX > area)
        //{
        //    _direction *= -1;
        //    _sprite.flipX = _direction < 0;
        //}

        if (posX < -area)
        {
            _direction = 1;
            _sprite.flipX = _direction < 0;
        }
        else if (posX > area)
        {
            _direction = -1;
            _sprite.flipX = _direction < 0;
        }

        //Vector2 view = _camera.WorldToViewportPoint(transform.position);
        //if (view.x < 0.08f || view.x > 0.95f)
        //{
        //    _direction *= -1;
        //    _sprite.flipX = _direction < 0;
        //}

        _rigidbody.velocity  = new Vector2(_direction * (_speed), _rigidbody.velocity.y);
    }
}
