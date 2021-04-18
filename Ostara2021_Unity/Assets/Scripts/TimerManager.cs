using System.Collections;
using System.Collections.Generic;
using rho;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] ExternalVariable<float> _timerRef;
    [SerializeField] StateScriptableObject _gameMode;

    public void OnStateChanged(StateScriptableObject oldState, StateScriptableObject newState)
    {
        if (newState == _gameMode)
        {
            _timerRef.Value = 0;
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
