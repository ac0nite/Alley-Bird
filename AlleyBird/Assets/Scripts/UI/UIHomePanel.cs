using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHomePanel : UIPanel
{
    [SerializeField] private Text _bestScore = null;
    private void OnEnable()
    {
        _bestScore.text = GameManger.Instance.Score.BestScore.ToString();

        GameManger.Instance.Input.EventJump += OnTapStart;
    }

    private void OnTapStart()
    {
        GameManger.Instance.Input.EventJump -= OnTapStart;

        UIManager.Instance.ShowUIPanel(TypePanel.GamePlay);

        GameManger.Instance.Score.ResetScore();
        GameManger.Instance.Spawning.SpawnAll();
    }
}
