using UnityEngine;
using System.Collections;
using Leap;


public class HandAttributes : MonoBehaviour
{
    private bool handInFrame;
    public static HandAttributes Current_Hand; 

    private HandModel cur_hand_model; 

    private float cur_hand_pinch;
    private float cur_hand_grab;
    private Vector3 direction;
    private Vector3 normal;
    private Quaternion rotation;


    public HandModel getHandModel() { 
        return cur_hand_model;
    }

    public bool isHandinFrame()  {
        return handInFrame;
    }

    public float getGrabStrength()
    {
        return cur_hand_grab;
    }

    public float getPinchStrength()
    {
        return cur_hand_pinch;
    }

    public Vector3 get_palm_Direction()
    {
        return direction;
    }

    public Vector3 get_palm_Normal()
    {
        return normal;
    }
    public Quaternion get_palm_Rotation()
    {
        return rotation;
    }
    
    // Use this for initialization
    void Start()
    {
        Current_Hand = new HandAttributes();

        cur_hand_model = transform.GetComponent<HandModel>();
        handInFrame = false;
        //   Debug.Log(cur_hand_model.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Leap Hand: " + cur_hand_model.GetLeapHand());
        if (cur_hand_model.GetLeapHand() != null)
        {
            handInFrame = true;
            //Debug.Log(cur_hand_model);

            cur_hand_grab = cur_hand_model.GetLeapHand().GrabStrength;
            cur_hand_pinch = cur_hand_model.GetLeapHand().PinchStrength;

            direction = cur_hand_model.GetPalmNormal();
            normal = cur_hand_model.GetPalmDirection();
            rotation = cur_hand_model.GetPalmRotation();

            Vector3 rotMag = rotation.eulerAngles;
            //Debug.Log("Rotation: " + rotMag + " normal: " + normal + " direction: " + direction);
            Debug.Log("Grab: " + cur_hand_grab + " Pinch: " + cur_hand_pinch);
        }
        else {
            handInFrame = false;
        }
    }
}

