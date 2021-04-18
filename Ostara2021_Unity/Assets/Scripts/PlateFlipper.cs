using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFlipper : MonoBehaviour
{
    [SerializeField] Rigidbody _body;
    [SerializeField] Vector3 _force;
    [SerializeField] Transform _position;
    [SerializeField] rho.StateScriptableObject _gameMode;

    public void OnStateChanged(rho.StateScriptableObject oldState, rho.StateScriptableObject newState)
    {
        if (newState == _gameMode)
        {
            StartCoroutine("ApplyForce");
        }
    }

    IEnumerator ApplyForce()
    {
        yield return new WaitForFixedUpdate();
        _body.isKinematic = false;
        _body.AddForceAtPosition(_force, _position.position, ForceMode.Impulse);
    }
}
