using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States { New, Cell, Sheets, Lock, Mirror, Freedom };
	private States State = States.New;

	private bool hasSheets;
	private bool hasMirror;
	private bool hasCostume;

	// Use this for initialization
	void Start () {
		State = States.New;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			State = States.New;
		}
		if (State == States.New) {
			StateNew();
		} else if (State == States.Cell) {
			StateCell();
		} else if (State == States.Sheets) {
			StateSheets();
		} else if (State == States.Lock) {
			StateLock();
		} else if (State == States.Mirror) {
			StateMirror();
		} else if (State == States.Freedom) {
			StateFreedom();
		}
	}

	void StateNew() {
		hasSheets = false;
		hasMirror = false;
		hasCostume = false;

		text.text = "Press [SPACE] to begin.";
		if (Input.GetKeyDown(KeyCode.Space)) {
			State = States.Cell;
		}
	}

	void StateCell() {
		string sheets = "are some dirty sheets on the";
		if (hasSheets) {
			sheets = "is an empty";
		}
		string mirror = "mirror";
		if (hasMirror) {
			mirror = "blank spot";
		}
		text.text = "You are in a prison cell, and you want to escape. " +
			"There "+sheets+" bed, a "+mirror+" on the wall, " +
			"and the door is locked from the outside.\n\n"
		;
		if (!hasSheets) {
			text.text = text.text + "[S] Inspect Sheets\n";
			if (Input.GetKeyDown(KeyCode.S)) {
				State = States.Sheets;
			}
		}
		if (!hasMirror) {
			text.text = text.text + "[M] Inspect Mirror\n";
			if (Input.GetKeyDown(KeyCode.M)) {
				State = States.Mirror;
			}
		}
		text.text = text.text + "[L] Inspect Lock";
		if (Input.GetKeyDown(KeyCode.L)) {
			State = States.Lock;
		}
	}

	void StateSheets() {
		if (hasSheets) {
			text.text = "Your bed looks empty without your sheets.\n\n" +
				"[R] Return to Cell"
			;
		} else {
			text.text = "You can't believe you sleep in these things. " +
				"Surely it's time somebody changed them. The pleasures of " +
				"prison life I guess!\n\n" +
				"[T] Take Sheets\n " +
				"[R] Return to Cell"
			;
			if (Input.GetKeyDown(KeyCode.T)) {
				hasSheets = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			State = States.Cell;
		}
	}

	void StateLock() {
		if (hasMirror) {
			text.text = "This door is locked from the outside. Perhaps your new mirror could be of use?\n\n"  +
				"[M] Use Mirror"
			;
			if (Input.GetKeyDown(KeyCode.M)) {
				State = States.Freedom;
			}
		} else {
			text.text = "The door is locked.\n\n" +
				"[R] Return to Cell"
			;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			State = States.Cell;
		}
	}

	void StateMirror() {
		if (hasMirror) {
			text.text = "The blank spot on the wall where the mirror was glistens with...something. " +
				"Probably just a shadow.\n\n" +
				"[R] Return to Cell"
			;
		} else {
			text.text = "The crude mirror does a poor job of reflecting your " +
				"form. Perhaps it has other uses?\n\n" +
				"[T] Take Mirror\n" +
				"[R] Return to Cell"
			;
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			hasMirror = true;
			State = States.Cell;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			State = States.Cell;
		}
	}

	void StateFreedom() {
		text.text = "You have escaped!\n\nPress [ESC] to play again.";
	}
}
