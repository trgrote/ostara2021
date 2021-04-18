using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField, rho.TagSelector] string _playerTag;
    [SerializeField] rho.StateVariable _gameStateRef;
    [SerializeField] rho.StateScriptableObject _levelComplete;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == _playerTag && _gameStateRef.Value != _levelComplete)
        {
            _gameStateRef.Value = _levelComplete;
        }
    }
}
