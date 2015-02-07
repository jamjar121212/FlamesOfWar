using UnityEngine;
using System.Collections;

public class PieceSelection : MonoBehaviour {

	public ActionResolution actionResolution;
	public GameObject selectedPiece = null;

	// Use this for initialization
	void Start () {
		this.actionResolution = this.gameObject.GetComponent<ActionResolution> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PieceClicked(GameObject piece) {
		if (piece.CompareTag ("Infantry")) {
			Debug.Log ("Piece Clicked.");
			selectedPiece = piece;
		}
	}

	public void PieceDropped(GameObject pieceDroppedOn) {
		if (selectedPiece) {
			this.actionResolution.ResolveAction (this.selectedPiece, pieceDroppedOn);
			this.selectedPiece = null;
		}
	}
}
