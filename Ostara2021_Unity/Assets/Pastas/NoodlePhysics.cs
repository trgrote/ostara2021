using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodlePhysics : MonoBehaviour
{
    [SerializeField] private float segmentMass = 1f;
    [SerializeField] private float colliderRadius = 0.2f;
    [SerializeField] private float colliderHeight = 0.005f;

    [SerializeField] [Range(0, 90)] private float twistability = 10f;
    [SerializeField] [Range(0, 90)] private float bendability = 10f;
    [SerializeField] private float twistSpringiness = 1f;
    [SerializeField] private float twistDampening = 1f;
    [SerializeField] private float twistContactDistance = 1f;
    [SerializeField] private float bendSpringiness = 1f;
    [SerializeField] private float bendDampening = 1f;
    [SerializeField] private float bendContactDistance = 1f;

    [SerializeField] private PhysicMaterial colliderPhysicsMaterial;

    public Transform firstBone;
    public Transform lastBone;

    // [SerializeField] private GameObject partPrefab, parentObject;
    // [SerializeField] [Range(1, 100)] private int segments = 5;
    // [SerializeField] private bool reset, spawn, snapFirst, snapLast;
    // Start is called before the first frame update
    void Awake()
    {
        InitializeSubParts(transform);
        firstBone = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeSubParts(Transform parent)
    {
        print(parent.name);
        print(parent.childCount);
        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.GetChild(i);
            lastBone = child;

            // Rigidbody
            print("adding rigidbody to" + child.name);
            var childRigidbody = child.gameObject.AddComponent<Rigidbody>();
            childRigidbody.useGravity = true;
            childRigidbody.isKinematic = false;
            childRigidbody.freezeRotation = false;
            childRigidbody.mass = segmentMass;


            // Collider
            var collider = child.gameObject.AddComponent<CapsuleCollider>();
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
            InitializeSubParts(child);
        }
    }
}
