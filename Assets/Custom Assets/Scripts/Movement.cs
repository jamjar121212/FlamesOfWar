using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	PieceSelection pieceSelection;
	ActionResolution actionResolution;
	GameObject ghostPiece;

	void Start() {
		this.pieceSelection = this.gameObject.GetComponent<PieceSelection> ();
		this.actionResolution = this.gameObject.GetComponent<ActionResolution> ();
	}

	public void BeginMovement(GameObject pieceMoved) {
		Debug.Log ("begin Movement");
		ghostPiece = Instantiate (pieceMoved, pieceMoved.transform.position, pieceMoved.transform.rotation) as GameObject;
		Color newColor = ghostPiece.renderer.material.color;
		newColor.a = 0.3f;
		ghostPiece.renderer.material.color = newColor;
	}

	public void PieceDropped(GameObject pieceDropped) {
		Debug.Log ("Move ended");
		pieceDropped.transform.position = GetGroundPosition ();
		Object.Destroy (ghostPiece);
		ghostPiece = null;
	}

	void Update() {
		if (ghostPiece) {
			ghostPiece.transform.position = GetGroundPosition();
		}
	}

	Vector3 GetGroundPosition() {
		LayerMask ground = 1 << LayerMask.NameToLayer("PlayingBoard");
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray, out hit, float.MaxValue, ground);
		return hit.point;
	}
}
