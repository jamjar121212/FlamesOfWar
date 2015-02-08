using UnityEngine;
using System.Collections;

public class ActionResolution : MonoBehaviour {

	public enum Action {NoAction, Movement};
	Action currentAction = Action.Movement;
	Movement movement;

	void Update() {
		this.movement = this.gameObject.GetComponent<Movement> ();
	}

	public void setAction(Action newAction) {
		currentAction = newAction;
	}

	public Action getCurrentAction() {
		return currentAction;
	}

	public void PieceSelected(GameObject pieceSelected) {
		if (currentAction == ActionResolution.Action.Movement) {
			BroadcastMessage("BeginMovement", pieceSelected);
		}
	}
	
	public void ResolveAction(GameObject selectedPiece, GameObject pieceDroppedOn, Vector3 dropLocation) {
		Debug.Log ("Resolving action!");
		if (pieceDroppedOn.CompareTag ("Infantry")) {
			Debug.Log ("Dropping piece on Infantry");
		} else if (pieceDroppedOn.CompareTag("PlayingBoard")) {
			Debug.Log ("Dropping piece on board");
			selectedPiece.transform.position = dropLocation;
		}
	}
}
