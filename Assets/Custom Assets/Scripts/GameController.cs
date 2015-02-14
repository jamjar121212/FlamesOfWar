using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameState {Movement, Combat};

	public GameState gameState = GameState.Movement;
	public int playerTurn = 0;

	// Use this for initialization
	void Start () {
		
	}

	void OnGUI () {

		GUI.Box(new Rect(10,0,160,25), "current player: " + playerTurn);
		GUI.Box(new Rect(10,30,160,25), "current state: " + gameState.ToString());

		if(GUI.Button(new Rect(10,70,200,20), "Begin player " + getNextPlayerPhase() + "'s " + getNextState().ToString())) {
			if (getNextState() == GameState.Movement) {
				playerTurn = getNextPlayerTurn();
			}
			gameState = getNextState();
		}

	}

	// Update is called once per frame
	void Update () {
	
	}

	GameState getNextState() {
		if (gameState == GameState.Movement)
			return GameState.Combat;

		return GameState.Movement;
	}

	int getNextPlayerTurn() {
		if (playerTurn == 0) {
			return 1;
		}
		return 0;
	}

	int getNextPlayerPhase() {
		if (gameState == GameState.Combat) {
			return getNextPlayerTurn();
		}
		return playerTurn;
	}
}
