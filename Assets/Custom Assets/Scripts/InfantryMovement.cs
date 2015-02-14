using UnityEngine;
using System.Collections;

public class InfantryMovement : MonoBehaviour {

	public GameObject unitSpherePrefab;

	GameObject ghostPiece;
	GameObject pieceMoving;
	GameObject rangeSphere;

	GameObject mainController;
	PieceSelection pieceSelection;
	
	void Start() {
		addEventListeners ();
	}

	void addEventListeners() {
		mainController = GameObject.Find("Maincontroller");
		pieceSelection = mainController.GetComponent<PieceSelection>();

		pieceSelection.onPieceClicked += BeginMovement;
		pieceSelection.onPieceDropped += PieceDropped;
	}
	
	public void BeginMovement(GameObject pieceMoved) {
		if (!pieceMoved.Equals(this.gameObject)) { return; }
		Debug.Log ("begin Infantry Movement");
		this.pieceMoving = pieceMoved;
		ghostPiece = Instantiate (pieceMoved, pieceMoved.transform.position, pieceMoved.transform.rotation) as GameObject;
		Color newColor = ghostPiece.renderer.material.color;
		newColor.a = 0.3f;
		ghostPiece.renderer.material.color = newColor;
		
		rangeSphere = Instantiate (unitSpherePrefab, pieceMoved.transform.position, pieceMoved.transform.rotation) as GameObject;
		rangeSphere.transform.localScale = new Vector3 (0.1524f*2, 0.1524f*2, 0.1524f*2);
	}
	
	public void PieceDropped(GameObject pieceDropped) {
		if (!pieceDropped.Equals(this.gameObject)) { return; }
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

	void OnDestroy() {
		pieceSelection.onPieceClicked -= BeginMovement;
		pieceSelection.onPieceDropped -= PieceDropped;
	}

}
