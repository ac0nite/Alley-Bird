using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    public event Action EventDestroyPlatform;

    [SerializeField] private float _deltaNeedRemove = -0.3f;

    private Collider2D _colliderGround = null;
    private Camera _camera = null;
    private float _widthPlatform = 0f;

    private void Awake()
    {
        _colliderGround = GetComponentInChildren<Collider2D>();
        _camera = Camera.main;
        _widthPlatform =  _camera.ViewportToWorldPoint(Vector3.zero).x + 0.4f;
    }

    private void FixedUpdate()
    {
        Vector2 view = _camera.WorldToViewportPoint(transform.position);
        if (view.y < _deltaNeedRemove)
        {
            EventDestroyPlatform?.Invoke();
            Destroy(transform.gameObject);
        }
    }

    public void SpawnContent()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            var coin = Instantiate(GameManger.Instance.CoinPrefab, Vector3.zero, Quaternion.identity, transform);
            coin.transform.localPosition = new Vector3(Random.Range(-_widthPlatform, _widthPlatform), 0.7f, 0);
        }
        else if (UnityEngine.Random.Range(0, 3) == 1)
        {
            var enemy = Instantiate(
                GameManger.Instance.EnemyPrefabs[Random.Range(0, GameManger.Instance.EnemyPrefabs.Count)], Vector3.zero,
                Quaternion.identity, transform);
            enemy.transform.localPosition = new Vector3(Random.Range(-_widthPlatform, _widthPlatform), 0.2f, 0);
        }
    }
    public void DisableKinematic()
    {
        _colliderGround.isTrigger = false;
        GameManger.Instance.Score.ChangeScore(+1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.position.y > transform.position.y)
            DisableKinematic();
    }
}
