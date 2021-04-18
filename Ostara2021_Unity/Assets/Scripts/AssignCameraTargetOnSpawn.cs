using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;

public class AssignCameraTargetOnSpawn : MonoBehaviour
{
    [SerializeField] ExternalTransformVariable _noodleCameraTargetRef;
    [SerializeField] Cinemachine.CinemachineVirtualCamera _camera;

    void OnEnable()
    {
        _noodleCameraTargetRef.Changed += OnNoodleCameraSpawn;
        OnNoodleCameraSpawn(null, null, _noodleCameraTargetRef.Value);
    }

    void OnDisable()
    {
        _noodleCameraTargetRef.Changed -= OnNoodleCameraSpawn;
    }

    void OnNoodleCameraSpawn(ExternalVariable<Transform> sender, Transform oldValue, Transform newValue)
    {
        _camera.Follow = _camera.LookAt = newValue;
    }
}
