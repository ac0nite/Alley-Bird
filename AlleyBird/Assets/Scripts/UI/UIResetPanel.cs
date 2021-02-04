using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResetPanel : UIPanel
{
    public Action EventResetPlay;

    [SerializeField] private Text _score = null;
    [SerializeField] private Text _bestScore = null;
    [SerializeField] private Text _coins = null;

    private void OnEnable()
    {
        _score.text = GameManger.Instance.Score.CurrentScore.ToString();
        _bestScore.text = GameManger.Instance.Score.BestScore.ToString();
        _coins.text = GameManger.Instance.Score.CurrentCoins.ToString();
    }

    public void ResetButton()
    {
        EventResetPlay?.Invoke();
        GameManger.Instance.Score.ResetScore();
        GameManger.Instance.Spawning.SpawnAll();
        UIManager.Instance.ShowUIPanel(TypePanel.GamePlay);
    }

    public void HomeMenu()
    {
        GameManger.Instance.Score.ResetScore();
        GameManger.Instance.Spawning.CleanAll();
        GameManger.Instance.Score.SaveProgress();

        UIManager.Instance.ShowUIPanel(TypePanel.Start);
    }

    public void ExitGame()
    {
        GameManger.Instance.Score.SaveProgress();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
