using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSoundHandler : MonoBehaviour
{
    [SerializeField] AudioSource _plateCrashSound;
    [SerializeField, rho.TagSelector] string _floorTag;

    private bool _crashSoundPlayed = false;

    void OnCollisionEnter(Collision other)
    {
        // Play crash noise if the ground
        if (!_crashSoundPlayed && other.collider.tag == _floorTag)
        {
            _plateCrashSound.Play();
            _crashSoundPlayed = true;
        }
    }

    [SerializeField] bool _playShiftSound = false;
    [SerializeField] rho.StateScriptableObject _gameMode;
    [SerializeField] AudioSource _plateShiftSound;    

    public void OnStateChanged(rho.StateScriptableObject oldState, rho.StateScriptableObject newState)
    {
        if (_playShiftSound && oldState != _gameMode && newState == _gameMode)
        {
            _plateShiftSound.Play();            
        }
    }
}
