using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResetPanel : UITypePanel
{
    public Action EventResetPlay;
    
    public void ResetButton()
    {
        EventResetPlay?.Invoke();
        GameManger.Instance.Score.ResetScore();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
