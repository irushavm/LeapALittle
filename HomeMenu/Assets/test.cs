//using UnityEngine;
//using System.Collections;
//using Leap;
//
//public class RotatingHands : MonoBehaviour
//{
//	public static HandAtributes hand;
//	private HandModel handModel;
//
//	void Start (){
//		controller 	= new Controller();
//		handModel = transform.GetComponent<HandModel>();
//	}
//	
//	void Update(){
//		//Hand hand = controller.Frame().Hands[0];
//		Quaternion palm_rotation = handModel.Basis().Rotation();
//		Debug.Log("Rotation : " + palm_rotation.y);
//	}		
//}