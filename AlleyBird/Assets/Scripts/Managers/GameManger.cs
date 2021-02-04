using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManger : SingletoneGameObject<GameManger>
{
    public GameObject PlayerPrefab = null;
    public Coin CoinPrefab = null;
    public List<Enemy> EnemyPrefabs = null;

    public ScoreManager Score = null;
    public InputManager Input = null;
    public Spawning Spawning = null;
}
