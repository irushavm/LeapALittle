using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject LoadImg;

	public void LoadScene(int level) {

		LoadImg.SetActive (true);
		Application.LoadLevel(level);
	}
}