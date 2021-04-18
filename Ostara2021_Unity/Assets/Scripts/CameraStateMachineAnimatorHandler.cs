using System.Collections;
using System.Collections.Generic;
using rho;
using UnityEngine;

public class CameraStateMachineAnimatorHandler : MonoBehaviour
{
    [SerializeField] Animator _animator;

    [Header("State Values")]
    [SerializeField] StateScriptableObject _start;
    [SerializeField] StateScriptableObject _instructions;
    [SerializeField] StateScriptableObject _gameMode;
    [SerializeField] StateScriptableObject _levelComplete;
    [SerializeField] StateScriptableObject _backstory;

    // Compare State Values and Trigger Appropriate Animation event when state changes
    public void OnStateChanged(StateScriptableObject oldState, StateScriptableObject newState)
    {
        if (newState == _start)
        {
            _animator.SetTrigger("ToStart");
        }
        else if (newState == _instructions)
        {
            _animator.SetTrigger("ToInstructions");
        }
        else if (newState == _gameMode)
        {
            _animator.SetTrigger("ToGameMode");
        }
        else if (newState == _levelComplete)
        {
            _animator.SetTrigger("ToLevelComplete");
        }
        else if (newState == _backstory)
        {
            _animator.SetTrigger("ToBackStory");
        }
    }
}
