using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodlePhysics : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private float colliderRadius = 0.2f;
    [SerializeField] private float colliderHeight = 0.005f;
    [SerializeField] private int collisionLayer = 0;

    [Header("Joints")]
    [SerializeField] [Range(0, 90)] private float twistability = 10f;
    [SerializeField] [Range(0, 90)] private float bendability = 10f;
    [SerializeField] private float twistSpringiness = 1f;
    [SerializeField] private float twistDampening = 1f;
    [SerializeField] private float twistContactDistance = 1f;
    [SerializeField] private float bendSpringiness = 1f;
    [SerializeField] private float bendDampening = 1f;
    [SerializeField] private float bendContactDistance = 1f;

    [Header("Rigidbodies")]
    [SerializeField] private float segmentMass = 1f;
    [SerializeField] private float segmentDrag = 1f;
    [SerializeField] private float headAndTailMassMultiplier = 1f;
    [SerializeField] private float midSegmentMassMultiplier = 1f;

    [SerializeField] private PhysicMaterial colliderPhysicsMaterial;

    [SerializeField]
    [Tooltip("Will be updated with a central location for the noodle")]
    private GameObject cameraFollowPoint;

    public List<Transform> bones;

    public Transform FirstBone
    {
        get => bones[0];
    }
    public Transform LastBone
    {
        get => bones[bones.Count - 1];
    }
    public Transform MidBone
    {
        get => bones[bones.Count / 2];
    }

    // [SerializeField] private GameObject partPrefab, parentObject;
    // [SerializeField] [Range(1, 100)] private int segments = 5;
    // [SerializeField] private bool reset, spawn, snapFirst, snapLast;
    // Start is called before the first frame update
    void Awake()
    {
        InitializeBones(transform);
        ApplyBoneModifications();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraFollowPoint();
    }

    void InitializeBones(Transform parent)
    {
        if (parent.childCount == 0) return;

        var child = parent.GetChild(0);
        bones.Add(child);

        // Rigidbody
        var childRigidbody = child.gameObject.AddComponent<Rigidbody>();
        childRigidbody.useGravity = true;
        childRigidbody.isKinematic = false;
        childRigidbody.freezeRotation = false;
        childRigidbody.mass = segmentMass;
        childRigidbody.drag = segmentDrag;
        childRigidbody.interpolation = RigidbodyInterpolation.Interpolate;


        // Collider
        var collider = child.gameObject.AddComponent<CapsuleCollider>();
        child.gameObject.layer = collisionLayer;
        collider.center = Vector3.zero;
        collider.radius = colliderRadius;
        collider.height = colliderHeight;
        collider.material = colliderPhysicsMaterial;

        // Joint
        // TODO maybe set the parent object as an articulationbody?
        Rigidbody parentRigidbody = parent.GetComponent<Rigidbody>();
        if (parentRigidbody)
        {
            CharacterJoint joint = child.gameObject.AddComponent<CharacterJoint>();
            joint.connectedBody = parent.GetComponent<Rigidbody>();
            joint.enableCollision = true;

            SoftJointLimit lowTwistLimit = joint.lowTwistLimit;
            lowTwistLimit.limit = -twistability;
            lowTwistLimit.contactDistance = twistContactDistance;
            joint.lowTwistLimit = lowTwistLimit;

            SoftJointLimit highTwistLimit = joint.highTwistLimit;
            highTwistLimit.limit = twistability;
            highTwistLimit.contactDistance = twistContactDistance;
            joint.highTwistLimit = highTwistLimit;

            SoftJointLimit swing1Limit = joint.swing1Limit;
            swing1Limit.limit = bendability;
            swing1Limit.contactDistance = bendContactDistance;
            joint.swing1Limit = swing1Limit;

            SoftJointLimit swing2Limit = joint.swing2Limit;
            swing2Limit.limit = bendability;
            swing2Limit.contactDistance = bendContactDistance;
            joint.swing2Limit = swing2Limit;

            SoftJointLimitSpring twistLimitSpring = joint.twistLimitSpring;
            twistLimitSpring.spring = twistSpringiness;
            twistLimitSpring.damper = twistDampening;
            joint.twistLimitSpring = twistLimitSpring;

            SoftJointLimitSpring swingLimitSpring = joint.swingLimitSpring;
            swingLimitSpring.spring = bendSpringiness;
            swingLimitSpring.damper = bendDampening;
            joint.swingLimitSpring = swingLimitSpring;
        }


        // Recursive
        InitializeBones(child);
    }

    void ApplyBoneModifications()
    {
        FirstBone.GetComponent<Rigidbody>().mass = segmentMass * headAndTailMassMultiplier;
        LastBone.GetComponent<Rigidbody>().mass = segmentMass * headAndTailMassMultiplier;

        MidBone.GetComponent<Rigidbody>().mass = segmentMass * midSegmentMassMultiplier;
    }

    // Sets camera follow point to midpoint of first and last segment
    void UpdateCameraFollowPoint()
    {
        cameraFollowPoint.transform.position = Vector3.Lerp(
            FirstBone.position,
            LastBone.position,
            0.5f
        );
    }
}
