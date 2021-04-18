using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRenderer : MonoBehaviour
{
    [SerializeField] rho.ExternalVariable<float> _timerValue;
    [SerializeField] rho.ExternalVariable<float> _meatballTimeSplit;
    [SerializeField] rho.ExternalVariable<bool> _isMeatballRun;
    [SerializeField] rho.ExternalVariable<bool> _isMeatballTouched;
    [SerializeField] Text _runTypeText;
    [SerializeField] Text _meatballSplitText;
    [SerializeField] Text _totalText;
    [SerializeField] Color _standardColor;
    [SerializeField] Color _translucentColor;
    [SerializeField] Color _meatballColor;
    // Update is called once per frame
    void Update()
    {
        _runTypeText.text = _isMeatballRun.Value ? "meatball%" : "any%";
        _runTypeText.color = _isMeatballRun.Value ? _meatballColor : _standardColor;

        _meatballSplitText.text = "(optional) Get Meatball: " + (_isMeatballTouched.Value ? _meatballTimeSplit.Value.ToString("0.00") : "----");
        _meatballSplitText.color = _isMeatballTouched.Value ? _meatballColor : _translucentColor;
        _meatballSplitText.fontStyle = _isMeatballTouched.Value ? FontStyle.Bold : FontStyle.Normal;

        _totalText.text = "Finish: " + _timerValue.Value.ToString("0.00");
    }
}
