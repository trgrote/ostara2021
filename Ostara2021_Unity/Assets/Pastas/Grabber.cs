using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private HingeJoint joint;

    public bool isLocked = false;
    private bool isReleaseEnabled = false;
    private bool isGrabEnabled = true;
    private bool isGrabbing = false;
    public float releaseToGrabCooldown = 0.5f;
    private float nextGrabbableTime = 0f;

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableRelease(bool enabled)
    {
        isReleaseEnabled = enabled;
    }

    public void EnableGrab(bool enabled)
    {
        isGrabEnabled = enabled;
    }

    void Grab(Rigidbody rbToGrab)
    {
        if (!isLocked && isGrabEnabled && !isGrabbing && Time.time >= nextGrabbableTime)
        {
            // Controller will re-enable release when lift button is released
            EnableRelease(false);
            GameObject.Destroy(joint);
            joint = gameObject.AddComponent<HingeJoint>();
            joint.connectedBody = rbToGrab;
            joint.enableCollision = false;
            isGrabbing = true;
        }
    }

    public void Release()
    {
        if (!isLocked && isReleaseEnabled && isGrabbing)
        {
            nextGrabbableTime = Time.time + releaseToGrabCooldown;
            GameObject.Destroy(joint);
            isGrabbing = false;
            EnableRelease(false);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 7 || col.gameObject.tag == "grabbable")
        {
            Grab(col.gameObject.GetComponent<Rigidbody>());
        }
    }
}
