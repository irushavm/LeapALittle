using UnityEngine;
using System.Collections;
using Leap;

public class GuideFollow : MonoBehaviour {

    private HandModel reference_hand;

    private Vector3 Player_Palm_pos;

    private Vector3 Reference_Palm_pos;

    // Use this for initialization
    void Start () {
        reference_hand = transform.GetComponent<HandModel>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HandAttributes.Current_Hand != null)
        {
            //Player_Palm_pos = HandAttributes.Current_Hand.getHandModel().GetLeapHand().StabilizedPalmPosition.ToUnity();
            //Reference_Palm_pos = reference_hand.GetLeapHand().StabilizedPalmPosition.ToUnity();
            //reference_hand.SetLeapHand(HandAttributes.Current_Hand.GetComponent<Hand>());
            GetComponent<HandModel>().transform.position = new Vector3(0, 5, 0);
        }

    }
}
