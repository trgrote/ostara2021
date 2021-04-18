using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class MenuInputHandler : MonoBehaviour
{
    NoodleControls _controls;
    [SerializeField] rho.StateVariable _stateRef;

    [Header("State Values")]
    [SerializeField] rho.StateScriptableObject _start;
    [SerializeField] rho.StateScriptableObject _instructions;
    [SerializeField] rho.StateScriptableObject _gameMode;
    [SerializeField] rho.StateScriptableObject _levelComplete;

    void Awake()
    {
        _controls = new NoodleControls();

        _controls.Menu.Start.performed += OnMenuStartPerformed;
    }

    void OnEnable()
    {
        _controls.Enable();
    }

    void OnDisable()
    {
        _controls.Disable();
    }

    void OnMenuStartPerformed(CallbackContext ctx)
    {
        if (_stateRef.Value == _start)
        {
            // Go to Next State
            _stateRef.Value = _instructions;
        }
        else if (_stateRef.Value == _instructions)
        {
            // Go to Next State
            _stateRef.Value = _gameMode;
        }
    }
}
