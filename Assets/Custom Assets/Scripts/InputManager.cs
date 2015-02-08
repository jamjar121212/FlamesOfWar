using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public bool isMouseDown = false;

	void Start () {
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			isMouseDown = true;
			BroadcastMessage("MouseClicked");
		}

		if (Input.GetMouseButtonUp(0)) {
			isMouseDown = false;
			BroadcastMessage("MouseReleased");
		}
	}
	
}
