using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public bool IsMove = false;

    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().flipX = (Random.Range(0, 2) == 1);
    }
}
