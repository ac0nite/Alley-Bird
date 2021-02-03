using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    [SerializeField] private GameObject _bird = null;
    [SerializeField] private float _offset = 0;
    private Vector3 _target = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, _bird.transform.position.y + _offset, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, _target, 3f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _target, 5f * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _target = new Vector3(transform.position.x, _bird.transform.position.y + _offset, transform.position.z);
    }
}
