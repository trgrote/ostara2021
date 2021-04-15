using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoodleController : MonoBehaviour
{
    NoodleControls controls;

    [SerializeField] private Transform cameraDirection;

    private NoodlePhysics noodlePhysics;
    private Rigidbody headPart;
    private Rigidbody tailPart;
    private Rigidbody midPart;

    private Grabber headGrabber;
    private Grabber tailGrabber;


    [Header("Movement")]
    [SerializeField] private float endMoveForce;
    [SerializeField] private float midMoveForce;

    [Header("Lift")]
    [SerializeField] private float endLiftForce;
    [SerializeField] private float midLiftForce;

    // When true, apply head movement forces to midPart 
    private bool isControllingMid = false;

    private Vector2 headMoveVector;
    private Vector2 tailMoveVector;

    private float headLift;
    private float tailLift;
    private float midLift;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new NoodleControls();

        // Moving head and tail
        controls.Noodle.MoveHead.performed += ctx => headMoveVector = ctx.ReadValue<Vector2>();
        controls.Noodle.MoveTail.performed += ctx => tailMoveVector = ctx.ReadValue<Vector2>();
        controls.Noodle.MoveHead.canceled += ctx => headMoveVector = Vector2.zero;
        controls.Noodle.MoveTail.canceled += ctx => tailMoveVector = Vector2.zero;

        // Raising head and tail
        controls.Noodle.RaiseHead.performed += ctx => headLift = ctx.ReadValue<float>();
        controls.Noodle.RaiseTail.performed += ctx => tailLift = ctx.ReadValue<float>();
        controls.Noodle.RaiseHead.canceled += ctx => headLift = 0.0f;
        controls.Noodle.RaiseTail.canceled += ctx => tailLift = 0.0f;

        // Allow releasing grabber after letting go of trigger once
        controls.Noodle.RaiseHead.canceled += ctx => headGrabber.EnableRelease(true);
        controls.Noodle.RaiseTail.canceled += ctx => tailGrabber.EnableRelease(true);


        // Middle Controls
        controls.Noodle.RaiseMid.performed += ctx => midLift = 1f;
        controls.Noodle.RaiseMid.canceled += ctx => midLift = 0f;

        controls.Noodle.ControlMid.performed += ctx => isControllingMid = true;
        controls.Noodle.ControlMid.canceled += ctx => isControllingMid = false;
    }

    void OnEnable()
    {
        controls.Noodle.Enable();
    }

    void OnDisable()
    {
        controls.Noodle.Disable();
    }

    void Start()
    {
        noodlePhysics = transform.GetComponent<NoodlePhysics>();

        headPart = noodlePhysics.FirstBone.GetComponent<Rigidbody>();
        tailPart = noodlePhysics.LastBone.GetComponent<Rigidbody>();
        midPart = noodlePhysics.MidBone.GetComponent<Rigidbody>();

        headGrabber = headPart.gameObject.GetComponent<Grabber>();
        tailGrabber = tailPart.gameObject.GetComponent<Grabber>();
    }

    void FixedUpdate()
    {
        float t = Time.fixedDeltaTime;
        CheckAndReleaseGrabbers();

        if (isControllingMid)
        {
            midPart.AddForce(movementVectorFromInput(headMoveVector) * midMoveForce * t, ForceMode.Force);
        }
        else
        {
            headPart.AddForce(movementVectorFromInput(headMoveVector) * endMoveForce * t, ForceMode.Force);
            tailPart.AddForce(movementVectorFromInput(tailMoveVector) * endMoveForce * t, ForceMode.Force);
        }

        // Can lift EITHER middle or ends
        if (midLift > 0)
        {
            midPart.AddForce(new Vector3(0, midLift, 0) * midLiftForce * t, ForceMode.Force);
        }
        else
        {
            headPart.AddForce(new Vector3(0, headLift, 0) * endLiftForce * t, ForceMode.Force);
            tailPart.AddForce(new Vector3(0, tailLift, 0) * endLiftForce * t, ForceMode.Force);
        }
    }

    void CheckAndReleaseGrabbers()
    {
        if (headLift > 0) headGrabber.Release();
        if (tailLift > 0) tailGrabber.Release();
    }

    Vector3 movementVectorFromInput(Vector2 xz)
    {
        Quaternion direction = cameraDirection.rotation;
        Vector3 movementVector = new Vector3(xz.x, 0, xz.y);
        return direction * movementVector;
    }

    // void Jump()
    // { }
}
