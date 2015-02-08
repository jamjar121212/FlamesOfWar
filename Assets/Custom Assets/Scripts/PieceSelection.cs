using UnityEngine;
using System.Collections;

public class PieceSelection : MonoBehaviour {

	public ActionResolution actionResolution;
	public GameObject selectedPiece = null;

	// Use this for initialization
	void Start () {
		this.actionResolution = this.gameObject.GetComponent<ActionResolution> ();
	}

	public void MouseClicked() {
		RaycastHit hit = this.SelectObject ();
		this.PieceClicked(hit.transform.gameObject);
	}

	public void MouseReleased() {
		BroadcastMessage ("PieceDropped", this.selectedPiece);
		this.selectedPiece = null;
	}
	
	public void PieceClicked(GameObject piece) {
		if (piece.CompareTag ("Infantry")) {
			Debug.Log ("Piece Selected.");
			this.selectedPiece = piece;
			BroadcastMessage ("PieceSelected", selectedPiece);
		} 
	}

	public RaycastHit SelectObject() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
