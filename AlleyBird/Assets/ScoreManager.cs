using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Spawning _spawning = null;
    
    private int _currentScore = 0;
    private int _currentCoins = 0;
    
    public Action<int, int> EventScoreChanged;

    public void ChangeScore(int value)
    {
        _currentScore = Mathf.Clamp(_currentScore + value, 0, _currentScore + value);
        EventScoreChanged?.Invoke(_currentScore, _currentCoins);
    }
    
    public void ChangeCoins(int value)
    {
        _currentCoins = Mathf.Clamp(_currentCoins + value, 0, _currentCoins + value);
        EventScoreChanged?.Invoke(_currentScore, _currentCoins);
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }
}
