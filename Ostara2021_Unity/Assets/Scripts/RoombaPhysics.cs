using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaPhysics : MonoBehaviour
{
    [SerializeField] private float moveForce = 10000.0f;
    [SerializeField] private float moveImpulseForce = 1000.0f;
    [SerializeField] private float turnForce = 1000.0f;
    [SerializeField] private float turnTime = 1.0f;
    [SerializeField] private float backupTime = 1.0f;

    public enum State
    {
        forward,
        backward,
        turning
    }

    public State currentState = State.forward;

    private float currentTurnTime = 0.0f;
    private float currentBackupTime = 0.0f;
    private float destinationAngle = 0.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTurnTime = 0.0f;
        currentBackupTime = 0.0f;
        GoForward();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t = Time.fixedDeltaTime;
        if (currentState == State.forward)
        {
            rb.AddRelativeForce(Vector3.forward * moveForce * t, ForceMode.Force);
        }
        else if (currentState == State.backward)
        {
            currentBackupTime += t;
            rb.AddRelativeForce(Vector3.back * moveForce * t, ForceMode.Force);
            if (currentBackupTime > backupTime) { Turn(); }
        }
        else if (currentState == State.turning)
        {
            currentTurnTime += t;
            rb.AddRelativeTorque(Vector3.up * turnForce * t);
            if (currentTurnTime > turnTime) { GoForward(); }
        }
    }

    void Turn()
    {
        Stop();
        currentTurnTime = 0.0f;
        currentState = State.turning;

    }

    void GoForward()
    {
        Stop();
        rb.AddRelativeForce(Vector3.forward * moveImpulseForce); // give a lil boost
        currentState = State.forward;
    }

    void BackUp()
    {
        Stop();
        currentBackupTime = 0.0f;
        currentState = State.backward;
    }

    void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision col)
    {
        // don't back up from hitting the floor or the player
        if (!col.gameObject.CompareTag("floor") && col.gameObject.layer != 6)
        {
            BackUp();
        }
    }
}
