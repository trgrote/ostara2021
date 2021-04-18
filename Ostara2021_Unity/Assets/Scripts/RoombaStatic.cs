using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaStatic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float backupTime = 1.0f;
    [SerializeField] private float turnAngle = 120.0f;


    enum State
    {
        forward,
        backward,
        turning
    }
    private State currentState;
    private Vector3 turnStartedEuler = Vector3.zero;
    private Vector3 destinationEuler = Vector3.zero;
    private float backedUpTime = 0.0f;
    private float turnProgress = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t = Time.fixedDeltaTime;

        if (currentState == State.forward)
        {
            transform.position += transform.TransformVector(Vector3.forward) * speed * t;
        }
        else if (currentState == State.backward)
        {
            transform.position += transform.TransformVector(Vector3.back) * speed * t;
            backedUpTime += t;
            if (backedUpTime > backupTime) Turn();
        }
        else if (currentState == State.turning)
        {
            turnProgress += turnSpeed * t;
            transform.eulerAngles = Vector3.Lerp(turnStartedEuler, destinationEuler, turnProgress);
            if (turnProgress > 1.0f) Forward();
        }
    }

    void BackUp()
    {
        print("backing up");
        currentState = State.backward;
        backedUpTime = 0.0f;
    }

    void Forward()
    {
        print("forward");
        currentState = State.backward;
    }

    void Turn()
    {
        print("turning");
        currentState = State.turning;
        backedUpTime = 0.0f;
        turnProgress = 0.0f;
        turnStartedEuler = transform.eulerAngles;
        destinationEuler = transform.TransformVector(Vector3.up * turnAngle);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("floor"))
        {
            BackUp();
        }
    }
}
