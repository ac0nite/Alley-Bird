using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _offset = 0;
    [SerializeField] private float _speed = 5f;

    private GameObject _bird = null;
    private Vector3 _target = Vector3.zero;

    private void Awake()
    {
        GameManger.Instance.Spawning.EventSpawnPlayer += OnFollowPlayer;
        _target = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(_bird != null)
            _target = new Vector3(transform.position.x, _bird.transform.position.y + _offset, transform.position.z);
    }

    private void OnFollowPlayer(GameObject player)
    {
        _bird = player;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnDestroy()
    {
        if(GameManger.TryInstance != null)
            GameManger.Instance.Spawning.EventSpawnPlayer -= OnFollowPlayer;
    }
}
