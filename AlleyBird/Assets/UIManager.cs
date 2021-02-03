using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : SingletoneGameObject<UIManager>
{
    private List<UITypePanel> _panels = null;
    private void Awake()
    {
        _panels = GetComponentsInChildren<UITypePanel>(true).ToList();
    }

    private void Start()
    {
        ShowUIPanel(TypePanel.GamePlay);
    }
    public void ShowUIPanel(TypePanel type)
    {
        foreach (var uiTypePanel in _panels)
        {
            uiTypePanel.gameObject.SetActive(uiTypePanel.Type == type);
        }
    }
}
