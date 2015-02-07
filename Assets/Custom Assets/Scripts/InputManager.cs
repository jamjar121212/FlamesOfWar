using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public bool isMouseDown = false;
	public PieceSelection pieceSelection;

	void Start () {
		this.pieceSelection = this.gameObject.GetComponent<PieceSelection> ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			isMouseDown = true;
			RaycastHit objectClickedOn = this.SelectObject();
			pieceSelection.PieceClicked(objectClickedOn.transform.gameObject);
		}

		if (Input.GetMouseButtonUp(0)) {
			isMouseDown = false;
			RaycastHit objectReleasedOn = this.SelectObject();
			this.pieceSelection.PieceDropped(objectReleasedOn.transform.gameObject);
		}
	}

	RaycastHit SelectObject() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
