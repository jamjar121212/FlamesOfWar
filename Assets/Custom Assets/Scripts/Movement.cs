﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	PieceSelection pieceSelection;
	ActionResolution actionResolution;
	GameObject ghostPiece;
	GameObject pieceMoving;
	public GameObject unitSpherePrefab;
	GameObject rangeSphere;

	void Start() {
		this.pieceSelection = this.gameObject.GetComponent<PieceSelection> ();
		this.actionResolution = this.gameObject.GetComponent<ActionResolution> ();
	}

	public void BeginMovement(GameObject pieceMoved) {
		Debug.Log ("begin Movement");
		this.pieceMoving = pieceMoved;
		ghostPiece = Instantiate (pieceMoved, pieceMoved.transform.position, pieceMoved.transform.rotation) as GameObject;
		Color newColor = ghostPiece.renderer.material.color;
		newColor.a = 0.3f;
		ghostPiece.renderer.material.color = newColor;

		rangeSphere = Instantiate (unitSpherePrefab, pieceMoved.transform.position, pieceMoved.transform.rotation) as GameObject;
		rangeSphere.transform.localScale = new Vector3 (0.1524f*2, 0.1524f*2, 0.1524f*2);
	}

	public void PieceDropped(GameObject pieceDropped) {
		Debug.Log ("Move ended");
		pieceDropped.transform.position = GetGroundPosition ();
		Object.Destroy (ghostPiece);
		ghostPiece = null;
		Object.Destroy (rangeSphere);
		rangeSphere = null;
	}

	void Update() {
		if (ghostPiece) {
			ghostPiece.transform.position = GetGroundPosition();
			if (Vector3.Distance(this.pieceMoving.transform.position, this.ghostPiece.transform.position) > 0.1524) {
			Debug.DrawLine(this.pieceMoving.transform.position, this.ghostPiece.transform.position, Color.red);
			}
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
