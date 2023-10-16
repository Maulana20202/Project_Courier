using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    public WheelCollider targetWheel;

    private Vector3 wheelPosisiton = new Vector3();

    private Quaternion WheelRotation = new Quaternion();

    // Update is called once per frame
    void Update()
    {
        targetWheel.GetWorldPose(out wheelPosisiton, out WheelRotation);
        transform.position = wheelPosisiton;
        transform.rotation = WheelRotation;
    }
}
