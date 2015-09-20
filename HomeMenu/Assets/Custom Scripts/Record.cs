using UnityEngine;
using System.Collections;
using Leap;
using System.Runtime.Serialization.Formatters.Binary;   //BInary serialization
using System.IO;        //Input, Output

public class Record : MonoBehaviour {

    [SerializeField] private KeyCode playKey = KeyCode.R;

    private bool isgrabping;
    private bool isPinching;

    [SerializeField] private float pinch_true;
    [SerializeField] private float grab_true;
    private float grab;
    private float pinch;

    private HandController cur_hand_controller;


	// Use this for initialization
	void Start () {
        cur_hand_controller = transform.GetComponent<HandController>();
        isgrabping = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (HandAttributes.Current_Hand != null)
        {
            grab = HandAttributes.Current_Hand.getGrabStrength();
            pinch = HandAttributes.Current_Hand.getPinchStrength();

            if (isgrabping == false && grab > grab_true)
            {

                cur_hand_controller.Record();
                isgrabping = true;

            }
            else if (isgrabping == true && pinch > pinch_true)
            {
                Debug.Log("Recording saved to: " + cur_hand_controller.FinishAndSaveRecording());
                isgrabping = false;
            }

            if (Input.GetKeyDown(playKey))
            {
                cur_hand_controller.PlayRecording();
            }
        }

    }
}
