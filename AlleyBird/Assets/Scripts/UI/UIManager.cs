using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : SingletoneGameObject<UIManager>
{
    private List<UIPanel> _panels = null;
    private void Awake()
    {
        _panels = GetComponentsInChildren<UIPanel>(true).ToList();
    }

    private void Start()
    {
        ShowUIPanel(TypePanel.Start);
    }
    public void ShowUIPanel(TypePanel type)
    {
        foreach (var uiTypePanel in _panels)
        {
            uiTypePanel.gameObject.SetActive(uiTypePanel.Type == type);
        }
    }

    public UIPanel GetInstancePanel(TypePanel panel)
    {
        return _panels.Find(typePanel => typePanel.Type == panel);
    }
}
