using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousetrap : MonoBehaviour
{
    [SerializeField] private Vector3 launchDirection;
    [SerializeField] private float launchPower;
    [SerializeField] private int collisionLayer = 8;
    [SerializeField] private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        GameObject other = col.gameObject;
        if (isActive && other.layer == collisionLayer)
        {
            isActive = false;
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            Vector3 worldLaunchDirection = transform.TransformVector(launchDirection).normalized;
            otherRb.AddForce(Vector3.zero, ForceMode.VelocityChange);
            otherRb.AddForce(worldLaunchDirection * launchPower, ForceMode.Impulse);
        }
    }
}
