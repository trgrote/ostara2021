using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRenderer : MonoBehaviour
{
    [SerializeField] rho.ExternalVariable<float> _timerValue;
    [SerializeField] Text _text;

    // Update is called once per frame
    void Update()
    {
        string formatted = _timerValue.Value.ToString("0.00");
        _text.text = $"Timer: {formatted}";
    }
}
