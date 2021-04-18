using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResetter : MonoBehaviour
{
    [SerializeField] GameObject _resettable;
    [SerializeField] rho.StateVariable _stateRef;
    [SerializeField] rho.StateScriptableObject _start;
    GameObject _currentResettable;

    public void OnNoodleCameraSpawn(rho.ExternalVariable<rho.StateScriptableObject> sender, rho.StateScriptableObject oldValue, rho.StateScriptableObject newValue)
    {
        if (oldValue != _start && newValue == _start)
        {
            if (_currentResettable)
            {
                Destroy(_currentResettable);
            }

            _currentResettable = Instantiate(_resettable);
        }
    }

    void OnEnable()
    {
        _stateRef.Changed += OnNoodleCameraSpawn;
        OnNoodleCameraSpawn(_stateRef, null, _stateRef.Value);
    }

    void OnDisable()
    {
        _stateRef.Changed -= OnNoodleCameraSpawn;
    }
}
