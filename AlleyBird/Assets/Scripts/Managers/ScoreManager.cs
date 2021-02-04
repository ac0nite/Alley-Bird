using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    public int CurrentCoins { get; private set; }
    public int BestScore { get; private set; }

    public Action<int, int> EventScoreChanged;

    private void Awake()
    {
        CurrentScore = 0;
        CurrentCoins = PlayerPrefs.GetInt("Coins", 0);
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void ChangeScore(int value)
    {
        CurrentScore = Mathf.Clamp(CurrentScore + value, 0, CurrentScore + value);

        if (CurrentScore > BestScore) BestScore = CurrentScore;

        EventScoreChanged?.Invoke(CurrentScore, CurrentCoins);
    }
    
    public void ChangeCoins(int value)
    {
        CurrentCoins = Mathf.Clamp(CurrentCoins + value, 0, CurrentCoins + value);
        EventScoreChanged?.Invoke(CurrentScore, CurrentCoins);
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("Coins", CurrentCoins);
        PlayerPrefs.SetInt("BestScore", BestScore);
    }
}
