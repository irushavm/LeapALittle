using UnityEngine;
using System.Collections;
using Leap;


public class HandAttributes : MonoBehaviour
{

    public static HandAttributes Current_Hand;

    private HandModel cur_hand_model;

    private float cur_hand_pinch;
    private float cur_hand_grab;



    public float getgrabStrength()
    {
        return cur_hand_grab;
    }

    public float getPinchStrength()
    {
        return cur_hand_pinch;
    }
    // Use this for initialization
    void Start()
    {

    
        cur_hand_model = transform.GetComponent<HandModel>();
        //   Debug.Log(cur_hand_model.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_hand_model.GetLeapHand() != null)
        {
            //Debug.Log(cur_hand_model);

            cur_hand_grab = cur_hand_model.GetLeapHand().GrabStrength;
            cur_hand_pinch = cur_hand_model.GetLeapHand().PinchStrength;

            //Debug.Log("Grab: " + cur_hand_grab + " Pinch: " + cur_hand_pinch);
        }
    }
}

