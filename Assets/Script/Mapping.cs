using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mapping : MonoBehaviour
{
    public VR_Map Head;
    public VR_Map LeftHand;
    public VR_Map RightHand;
    public Transform HeadLimit;
    public Vector3 HeadOffSet;

    private void Start()
    {
        HeadOffSet = transform.position - HeadLimit.position;
    }


    void Update()
    {
        transform.position = HeadLimit.position + HeadOffSet;
        transform.forward = Vector3.ProjectOnPlane(HeadLimit.up, Vector3.up).normalized;
        Head.Map();
        LeftHand.Map();
        RightHand.Map();

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
            BoneTarget.rotation = VRTarget.rotation * Quaternion.Euler(PositionOffSet);
        }

    }
}
