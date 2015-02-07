using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public bool isMouseDown = false;
	public PieceSelection pieceSelection;

	void Start () {
		this.pieceSelection = this.gameObject.GetComponent<PieceSelection>();
		Debug.Log ("initialising input manager...");
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			isMouseDown = true;
			this.SelectObject();
		}

		if (Input.GetMouseButtonUp(0)) {
			isMouseDown = false;
		}
	}

	void SelectObject() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)) 
		{
			Debug.Log("Clicked Something!");
		}
	}
}
