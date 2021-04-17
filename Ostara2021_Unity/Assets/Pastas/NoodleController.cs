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

    public Grabber headGrabber;
    public Grabber tailGrabber;


    [Header("Movement")]
    [SerializeField] private float endMoveForce;
    [SerializeField] private float midMoveForce;
    [SerializeField]
    [Tooltip("the angle above horizontal to apply movement force")]
    [Range(0, 90)] private float moveVertAngle = 0.0f;

    [Header("Lift")]
    [SerializeField] private float endLiftForce;
    [SerializeField] private float midLiftForce;

    [Header("Climbing")]
    [SerializeField] private float grabCooldown = 0.5f;

    [SerializeField]
    [Tooltip("Whether noodle will grab while raising an end")]
    private bool alwaysGrab = false;

    // When true, apply head movement forces to midPart 
    private bool isControllingMid = false;

    private Quaternion vertMovementRotation;

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

        // 
        if (!alwaysGrab)
        {
            controls.Noodle.RaiseHead.performed += ctx => headGrabber.EnableGrab(false);
            controls.Noodle.RaiseTail.performed += ctx => tailGrabber.EnableGrab(false);
            controls.Noodle.RaiseHead.canceled += ctx => headGrabber.EnableGrab(true);
            controls.Noodle.RaiseTail.canceled += ctx => tailGrabber.EnableGrab(true);
        }

        // Allow releasing grabber after letting go of trigger once
        controls.Noodle.RaiseHead.canceled += ctx => headGrabber.EnableRelease(true);
        controls.Noodle.RaiseTail.canceled += ctx => tailGrabber.EnableRelease(true);

        // Lock grab/release state while button is held
        controls.Noodle.LockGrip.performed += ctx => headGrabber.isLocked = true;
        controls.Noodle.LockGrip.canceled += ctx => headGrabber.isLocked = false;
        controls.Noodle.LockGrip.performed += ctx => tailGrabber.isLocked = true;
        controls.Noodle.LockGrip.canceled += ctx => tailGrabber.isLocked = false;

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

        Transform head = noodlePhysics.FirstBone;
        Transform tail = noodlePhysics.LastBone;
        Transform mid = noodlePhysics.MidBone;

        headPart = head.GetComponent<Rigidbody>();
        tailPart = tail.GetComponent<Rigidbody>();
        midPart = mid.GetComponent<Rigidbody>();

        headGrabber = MakeGrabber(head.gameObject);
        tailGrabber = MakeGrabber(tail.gameObject);

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

        // This could be moved to start for efficiency if it's a heavy calc
        vertMovementRotation = Quaternion.AngleAxis(moveVertAngle, Vector3.left);

        // Adjust horizontal movement to camera angle, then adjust that to vertical rotation
        return vertMovementRotation * (direction * movementVector);
    }

    Grabber MakeGrabber(GameObject obj)
    {
        Grabber grabber = obj.AddComponent<Grabber>();
        grabber.releaseToGrabCooldown = grabCooldown;
        return grabber;
    }
}
