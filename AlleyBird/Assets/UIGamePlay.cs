using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : UITypePanel
{
    [SerializeField] private Text _score = null;
    [SerializeField] private Text _coins = null;

    private void Start()
    {
        GameManger.Instance.Score.EventScoreChanged += OnScoreChanged;
        
        _score.text = "0";
        _coins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }

    private void OnScoreChanged(int score, int coins)
    {
        _score.text = score.ToString();
        _coins.text = coins.ToString();
    }
    private void OnDestroy()
    {
        if(GameManger.TryInstance != null)
            GameManger.Instance.Score.EventScoreChanged -= OnScoreChanged;
    }
}
