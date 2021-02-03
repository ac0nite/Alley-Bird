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

    private void Awake()
    {
        _colliderGround = GetComponentInChildren<Collider2D>();
        _camera = Camera.main;
    }

    private void Start()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            var o = Instantiate(GameManger.Instance.CoinPrefab, Vector3.zero, Quaternion.identity, transform);
            Vector3 view = new Vector3(Random.Range(0.1f, 0.9f), 0f, 0f);
            Vector3 viewWorld = Camera.main.ViewportToWorldPoint(view);
            o.transform.localPosition = new Vector3(viewWorld.x, 0, 0);
        }
    }



    private void FixedUpdate()
    {
        Vector2 view = _camera.WorldToViewportPoint(transform.position);
        if (view.y < _deltaNeedRemove)
        {
           // Debug.Log(view, transform.gameObject);
            EventDestroyPlatform?.Invoke();
            Destroy(transform.gameObject);
        }
    }
    public void DisableKinematic()
    {
        _colliderGround.isTrigger = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DisableKinematic();
    }
}
