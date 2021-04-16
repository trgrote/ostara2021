using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;
using UnityEngine.Events;

// Listen to State Change in the State Ref and invoke unity event.
public class ExternStateChangeListener : MonoBehaviour
{
    [SerializeField] StateVariable _stateRef;
    [SerializeField] UnityEvent<StateScriptableObject, StateScriptableObject> _onStateChange;

    void OnEnable()
    {
        _stateRef.Changed += OnStateChanged;
    }

    void OnDisable()
    {
        _stateRef.Changed -= OnStateChanged;
    }

    void OnStateChanged(ExternalVariable<StateScriptableObject> sender, StateScriptableObject oldState, StateScriptableObject newState)
    {
        _onStateChange.Invoke(oldState, newState);
    }
}
