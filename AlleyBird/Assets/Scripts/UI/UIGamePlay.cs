using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : UIPanel
{
    [SerializeField] private Text _score = null;
    [SerializeField] private Text _coins = null;
    [SerializeField] private Text _bestScore = null;

    private void OnEnable()
    {
        GameManger.Instance.Score.EventScoreChanged += OnScoreChanged;

        _score.text = GameManger.Instance.Score.CurrentScore.ToString();
        _coins.text = GameManger.Instance.Score.CurrentCoins.ToString();
        _bestScore.text = GameManger.Instance.Score.BestScore.ToString();
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
