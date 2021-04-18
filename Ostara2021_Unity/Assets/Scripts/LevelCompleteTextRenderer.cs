using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteTextRenderer : MonoBehaviour
{
    [SerializeField] rho.ExternalVariable<float> _timerValue;
    [SerializeField] Text _text;

    void Update()
    {
        _text.text = String.Format("You escape Belluca's Bistro in {0:0.0} seconds", _timerValue.Value);
    }
}
