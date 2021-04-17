using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource _vintage;
    [SerializeField] AudioSource _normal;

    [Header("Game State Stuff")]
    [SerializeField] rho.StateVariable _stateRef;
    [SerializeField] List<rho.StateScriptableObject> _normalStates;
    [SerializeField] List<rho.StateScriptableObject> _vintageStates;

    void OnEnable()
    {
        _stateRef.Changed += OnStateChanged;
        OnStateChanged(null, null, _stateRef.Value);   // init
    }

    void OnDisable()
    {
        _stateRef.Changed -= OnStateChanged;
    }

    void OnStateChanged(rho.ExternalVariable<rho.StateScriptableObject> sender, rho.StateScriptableObject oldState, rho.StateScriptableObject newState)
    {
        _normal.mute = true;
        _vintage.mute = true;

        if (_normalStates.Contains(newState))
        {
            _normal.mute = false;
        }
        else if (_vintageStates.Contains(newState))
        {
            _vintage.mute = false;
        }
    }
}
