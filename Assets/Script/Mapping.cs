using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mapping : MonoBehaviour
{
    public VR_Map Head;
    public VR_Map LeftHand;
    public VR_Map RightHand;
    public Transform HeadLimit;
    public Vector3 HeadOffSet; // The initial Difference between the head and the body
    public float turnSmoothness;

    private void Start()
    {
        HeadOffSet = transform.position - HeadLimit.position; // The initial Difference between the head and the body
    }


    void FixedUpdate()
    {
        transform.position = HeadLimit.position + HeadOffSet; //move the body according to the movement of the head 
        transform.forward = Vector3.ProjectOnPlane(HeadLimit.forward, Vector3.up).normalized; //up = green axis / forward = blue
        Head.Map();
        LeftHand.Map();
        RightHand.Map();
        //transform.position.Set(transform.position.x, transform.position.y, transform.position.z - 1);

    }
    [System.Serializable]

    public class VR_Map // custom class inside my inspector 
    {
        public Transform VRTarget;   //Controller,Headset
        public Transform BoneTarget;
        public Vector3 PositionOffSet;
        public Vector3 RotationOffSet;
        public void Map()
        {
            BoneTarget.position = VRTarget.TransformPoint(PositionOffSet); // TransformPoint : return the world position that the BoneTarget would have.
            BoneTarget.rotation = VRTarget.rotation * Quaternion.Euler(RotationOffSet);
        }

    }
}
