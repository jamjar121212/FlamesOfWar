using UnityEngine;
using System.Collections;

public class PieceSelection : MonoBehaviour {

	public ActionResolution actionResolution;
	public GameObject selectedPiece = null;

	public delegate void onPieceClickedDelegate(GameObject objectClicked);
	public delegate void onPieceDroppedDelegate(GameObject objectClicked);

	public event onPieceClickedDelegate onPieceClicked;
	public event onPieceDroppedDelegate onPieceDropped;

	// Use this for initialization
	void Start () {
		this.actionResolution = this.gameObject.GetComponent<ActionResolution> ();
		this.addEventListeners ();
	}

	void addEventListeners() {
		GameObject mainController = GameObject.Find("Maincontroller");
		InputManager inputManager = mainController.GetComponent<InputManager>();
		
		inputManager.onMouseDown += MouseClicked;
		inputManager.onMouseUp += MouseReleased;
	}

	public void MouseClicked() {
		Debug.Log ("mouse clicked");
		RaycastHit hit = this.SelectObject ();
		this.PieceClicked(hit.transform.gameObject);
	}

	public void MouseReleased() {
		Debug.Log ("mouse released");
		if (onPieceDropped != null && this.selectedPiece != null) {
			onPieceDropped (selectedPiece);
		}
		this.selectedPiece = null;
	}
	
	public void PieceClicked(GameObject piece) {

		if (piece.CompareTag ("Infantry")) {
			Debug.Log ("Piece Selected.");
			this.selectedPiece = piece;
		}

		if (onPieceClicked != null && this.selectedPiece != null) {
			onPieceClicked (selectedPiece);
		}
	}

	public RaycastHit SelectObject() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
