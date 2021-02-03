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

    private List<Platform> _platforms = new List<Platform>();

    private void Start()
    {
        SpawnAll();
        _platforms[0].DisableKinematic();
    }

    public void SpawnAll()
    {
        var position = new Vector3(transform.position.x, _startPosition, transform.position.z);

        for (int i = 0; i < _countPlatforms; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 position = Vector3.zero;

        if (_platforms.Count == 0)
            position = new Vector3(transform.position.x, _startPosition, transform.position.z);
        else
            position = new Vector3(transform.position.x, _platforms[_platforms.Count - 1].transform.position.y + _offsetBetweenPlatforms, transform.position.z);

        var p = Instantiate(_prefabPlatform, position, Quaternion.identity, transform);
        _platforms.Add(p);

        p.EventDestroyPlatform += OnSpawn;
    }

    private void OnSpawn()
    {
        _platforms[0].EventDestroyPlatform -= OnSpawn;
        _platforms.RemoveAt(0);

        Spawn();
    }
}
