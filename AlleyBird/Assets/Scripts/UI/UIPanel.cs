using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypePanel
{
    Undefined = -1,
    Start = 0,
    GamePlay = 1,
    Reset = 2
}
public class UIPanel : MonoBehaviour
{
    public TypePanel Type = TypePanel.GamePlay;
}
