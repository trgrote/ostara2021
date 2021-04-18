using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternTransformRegister : MonoBehaviour
{
    [SerializeField] ExternalTransformVariable _transformRef;
    [SerializeField] Transform _transform;

    void OnEnable()
    {
        _transformRef.Value = _transform;
    }

    void OnDisable()
    {
        if (_transformRef.Value == _transform)
            _transformRef.Value = null;
    }
}
