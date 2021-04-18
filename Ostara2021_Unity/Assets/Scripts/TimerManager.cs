using System.Collections;
using System.Collections.Generic;
using rho;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] ExternalVariable<float> _timerRef;
    [SerializeField] rho.ExternalVariable<float> _meatballTimeSplit;
    [SerializeField] rho.ExternalVariable<bool> _isMeatballRun;
    [SerializeField] rho.ExternalVariable<bool> _isMeatballTouched;
    [SerializeField] StateScriptableObject _gameMode;

    public void OnStateChanged(StateScriptableObject oldState, StateScriptableObject newState)
    {
        if (newState == _gameMode)
        {
            _timerRef.Value = 0;
            _meatballTimeSplit.Value = 0f;
            _isMeatballRun.Value = false;
            _isMeatballTouched.Value = false;
            StartCoroutine("CountTimer");
        }
        else
        {
            StopCoroutine("CountTimer");
        }
    }

    IEnumerator CountTimer()
    {
        while (true)
        {
            _timerRef.Value += Time.deltaTime;
            yield return null;
        }
    }
}
