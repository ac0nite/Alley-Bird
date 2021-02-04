using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action EventJump;
    private Touch _touch;

    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetKeyUp(KeyCode.Space))
            EventJump?.Invoke();
#else
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                EventJump?.Invoke();
            }
        }
#endif

    }
}
