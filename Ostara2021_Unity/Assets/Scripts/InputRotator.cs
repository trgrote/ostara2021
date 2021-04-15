using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Rotate a Transform based off input
public class InputRotator : MonoBehaviour
{
    [SerializeField] Transform _transform;
    
    [SerializeField] float _rotationSpeed = 100f;

    NoodleControls _controls;

    float _direction = 0;

    void Awake()
    {
        _controls = new NoodleControls();

        _controls.Noodle.Rotate.performed += ctx => _direction = ctx.ReadValue<float>();
        _controls.Noodle.Rotate.canceled += ctx => _direction = 0;
    }

    void OnEnable()
    {
        _controls.Enable();
    }

    void OnDisable()
    {
        _controls.Disable();
    }
    
    // Update is called once per frame
    void Update()
    {
        _transform.rotation *= Quaternion.AngleAxis(_direction * _rotationSpeed * Time.deltaTime, Vector3.up);
    }
}
