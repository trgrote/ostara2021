using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoodleController : MonoBehaviour
{
    NoodleControls controls;

    public NoodlePhysics noodlePhysics;
    public Rigidbody headPart;
    public Rigidbody tailPart;

    [SerializeField] private float moveForce;
    [SerializeField] private float liftForce;

    private Vector2 headMoveVector;
    private Vector2 tailMoveVector;

    private float headLift;
    private float tailLift;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new NoodleControls();

        // controls.Noodle.Jump.performed += ctx => Jump();

        controls.Noodle.MoveHead.performed += ctx => headMoveVector = ctx.ReadValue<Vector2>();
        controls.Noodle.MoveTail.performed += ctx => tailMoveVector = ctx.ReadValue<Vector2>();
        controls.Noodle.MoveHead.canceled += ctx => headMoveVector = Vector2.zero;
        controls.Noodle.MoveTail.canceled += ctx => tailMoveVector = Vector2.zero;

        controls.Noodle.RaiseHead.performed += ctx => headLift = ctx.ReadValue<float>();
        controls.Noodle.RaiseTail.performed += ctx => tailLift = ctx.ReadValue<float>();
        controls.Noodle.RaiseHead.canceled += ctx => headLift = 0.0f;
        controls.Noodle.RaiseTail.canceled += ctx => tailLift = 0.0f;
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
        headPart = noodlePhysics.firstBone.GetComponent<Rigidbody>();
        tailPart = noodlePhysics.lastBone.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        headPart.AddForce(vector3FromXZ(headMoveVector) * moveForce, ForceMode.Force);
        tailPart.AddForce(vector3FromXZ(tailMoveVector) * moveForce, ForceMode.Force);

        headPart.AddForce(new Vector3(0, headLift, 0) * liftForce, ForceMode.Force);
        tailPart.AddForce(new Vector3(0, tailLift, 0) * liftForce, ForceMode.Force);
    }

    Vector3 vector3FromXZ(Vector2 xz)
    {
        return new Vector3(xz.x, 0, xz.y);
    }

    // void Jump()
    // { }
}
