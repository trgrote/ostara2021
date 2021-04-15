using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private HingeJoint joint;
    private bool isReleaseEnabled = false;
    public float releaseToGrabCooldown = 0.5f;
    private float nextGrabbableTime = 0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Grab(Rigidbody rbToGrab)
    {
        if (Time.time >= nextGrabbableTime)
        {
            EnableRelease(false);
            GameObject.Destroy(joint);
            joint = gameObject.AddComponent<HingeJoint>();
            joint.connectedBody = rbToGrab;
            joint.enableCollision = false;
        }
    }

    public void EnableRelease(bool enabled)
    {
        isReleaseEnabled = enabled;
    }

    public void Release()
    {
        if (isReleaseEnabled)
        {
            nextGrabbableTime = Time.time + releaseToGrabCooldown;
            GameObject.Destroy(joint);
            EnableRelease(false);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 7)
        {
            Grab(col.gameObject.GetComponent<Rigidbody>());
        }
    }
}
