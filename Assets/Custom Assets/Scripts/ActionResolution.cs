using UnityEngine;
using System.Collections;

public class ActionResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResolveAction(GameObject selectedPiece, GameObject pieceDroppedOn) {
		Debug.Log ("Resolving action!");
		if (pieceDroppedOn.CompareTag ("Infantry")) {
			Debug.Log ("Dropping piece on Infantry");
		} else if (pieceDroppedOn.CompareTag("PlayingBoard")) {
			Debug.Log ("Dropping piece on board");
		}
	}
}
