using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleClimb : MonoBehaviour
{
    private NoodlePhysics noodlePhysics;
    [SerializeField] private float grabCooldown = 0.5f;

    private GameObject head;
    private GameObject tail;
    private Grabber headGrabber;
    private Grabber tailGrabber;

    // Start is called before the first frame update
    void Start()
    {
        noodlePhysics = transform.GetComponent<NoodlePhysics>();
        head = noodlePhysics.FirstBone.gameObject;
        tail = noodlePhysics.LastBone.gameObject;

        headGrabber = MakeGrabber(head);
        tailGrabber = MakeGrabber(tail);
    }

    // Update is called once per frame
    void Update()
    {

    }

    Grabber MakeGrabber(GameObject obj)
    {
        Grabber grabber = obj.AddComponent<Grabber>();
        grabber.releaseToGrabCooldown = grabCooldown;
        return grabber;
    }

}
