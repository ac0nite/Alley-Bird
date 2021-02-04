using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private Platform _prefabPlatform = null;
    [SerializeField] private float _countPlatforms = 4f;
    [SerializeField] private float _startPosition = -2f;
    [SerializeField] private float _offsetBetweenPlatforms = 2f;
    [SerializeField] private Vector2 _startPositionPlayer = Vector2.zero;

    private List<Platform> _platforms = new List<Platform>();
    private GameObject _player = null;

    private float _spawnPosition = 0f;

    public Action<GameObject> EventSpawnPlayer;

    public void SpawnAll()
    {
        CleanAll();

        for (int i = 0; i < _countPlatforms; i++)
        {
            var p = Spawn();
            if (i > 0) p.SpawnContent();
        }

        _platforms[0].DisableKinematic();

        _player = Instantiate(GameManger.Instance.PlayerPrefab, _startPositionPlayer, Quaternion.identity);
        EventSpawnPlayer?.Invoke(_player);
    }

    public void CleanAll()
    {
        transform.position = Vector3.zero;

        if (_player != null) Destroy(_player);
        foreach (Platform platform in _platforms)
        {
            Destroy(platform.gameObject);
        }
        _platforms.Clear();
    }

    private Platform Spawn()
    {
        Vector3 position = Vector3.zero;

        if (_platforms.Count == 0)
            position = new Vector3(transform.position.x, _startPosition, transform.position.z);
        else
            position = new Vector3(transform.position.x, _platforms[_platforms.Count - 1].transform.position.y + _offsetBetweenPlatforms, transform.position.z);

        var p = Instantiate(_prefabPlatform, position, Quaternion.identity);
        _platforms.Add(p);

        p.EventDestroyPlatform += OnSpawn; 
        return p;
    }

    private void OnSpawn()
    {
        _platforms[0].EventDestroyPlatform -= OnSpawn;
        _platforms.RemoveAt(0);

        Spawn().SpawnContent();
    }
}
