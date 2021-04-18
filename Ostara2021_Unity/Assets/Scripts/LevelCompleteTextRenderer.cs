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
        _text.text = $"You escape Belluca's Bistro in {_timerValue.Value} seconds";
    }
}
