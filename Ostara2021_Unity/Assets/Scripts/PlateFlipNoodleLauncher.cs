using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFlipNoodleLauncher : MonoBehaviour
{
    [SerializeField] Vector3 _force;
    [SerializeField] rho.StateScriptableObject _gameMode;

    [SerializeField] NoodlePhysics _noodlePhysics;

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
        _noodlePhysics.AllRigidBodies.ForEach(body => body.AddForce(_force, ForceMode.Impulse));
    }
}
