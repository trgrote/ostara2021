using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFlipAnimEventHandler : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody _rigidBody;

    // Start is called before the first frame update
    public void OnPlateFlipEvent()
    {
        print ("OnPlateFlipEvent");
    }

    public void OnFlipAnimComplete()
    {
        _rigidBody.isKinematic = false;
        _animator.enabled = false;
    }
}
