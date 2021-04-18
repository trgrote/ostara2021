using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRenderer : MonoBehaviour
{
    [SerializeField] rho.ExternalVariable<float> _timerValue;
    [SerializeField] rho.ExternalVariable<bool> _isMeatballRun;
    [SerializeField] Text _text;
    [SerializeField] Color _standardColor;
    [SerializeField] Color _meatballColor;
    // Update is called once per frame
    void Update()
    {
        string formattedTime = _timerValue.Value.ToString("0.00");
        string runType = _isMeatballRun.Value ? "meatball%" : "any%";
        _text.color = _isMeatballRun.Value ? _standardColor : _meatballColor;
        _text.text = $"{runType}: {formattedTime}";
    }
}
