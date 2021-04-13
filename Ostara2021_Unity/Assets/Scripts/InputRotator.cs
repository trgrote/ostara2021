using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotate a Transform based off input
public class InputRotator : MonoBehaviour
{
    [SerializeField] Transform _transform;
    
    // Update is called once per frame
    void Update()
    {
        var horiz = Input.GetAxis("Horizontal");

        _transform.rotation *= Quaternion.AngleAxis(horiz, Vector3.up);
    }
}
