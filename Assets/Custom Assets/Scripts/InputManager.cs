using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public bool isMouseDown = false;
	public delegate void onMouseDownDelegate();
	public delegate void onMouseUpDelegate();

	public event onMouseDownDelegate onMouseDown;
	public event onMouseUpDelegate onMouseUp;

	void Start () {
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			isMouseDown = true;
			if (onMouseDown != null) {
				onMouseDown();
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			isMouseDown = false;
			if (onMouseUp != null) {
				onMouseUp();
			}
		}
	}
	
}
