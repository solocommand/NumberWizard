using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States { New, Cell, Sheets, Lock, Mirror, Corridor, Hairpin, Stairs, Closet, Freedom };
	private States State = States.New;

	private bool closetUnlocked;
	private bool hasSheets;
	private bool hasMirror;
	private bool hasCostume;
	private bool hasHairpin;

	// Use this for initialization
	void Start () {
		State = States.New;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			State = States.New;
		}
		if (State == States.New) 						{ StateNew(); }
		else if (State == States.Cell) 			{ StateCell(); }
		else if (State == States.Sheets) 		{ StateSheets(); }
		else if (State == States.Lock) 			{ StateLock(); }
		else if (State == States.Mirror)  	{ StateMirror(); }
		else if (State == States.Corridor) 	{ StateCorridor(); }
		else if (State == States.Hairpin) 	{ StateHairpin(); }
		else if (State == States.Stairs) 		{ StateStairs(); }
		else if (State == States.Closet) 		{ StateCloset(); }
		else if (State == States.Freedom) 	{ StateFreedom(); }
	}

	void StateNew() {
		hasSheets = false;
		hasMirror = false;
		hasCostume = false;
		hasHairpin = false;
		closetUnlocked = false;

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
		text.text = text.text + "[S] Inspect Sheets\n";
		if (Input.GetKeyDown(KeyCode.S)) {
			State = States.Sheets;
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
				State = States.Corridor;
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

	void StateCorridor() {
		string closet = "an unobtrusive closet marked \"CUSTODIAL\"";
		if (closetUnlocked) {
			closet = "an open closet door";
		}
		string hairpin = "a hairpin glinting out of the dust";
		if (hasHairpin) {
			hairpin = "a clean spot where your hairclip was";
		}
		text.text = "You are in an empty corridor. A dim light flickers slowly, illuminating a stairwell, " +
			hairpin + ", and " + closet + "\n\n"
		;

		if (!hasHairpin) {
			text.text = text.text + "[H] Inspect Hairpin\n";
			if (Input.GetKeyDown(KeyCode.H)) {
				State = States.Hairpin;
			}
		}
		text.text = text.text + "[S] Take the Stairs\n";
		text.text = text.text + "[C] Inspect Closet";
		if (Input.GetKeyDown(KeyCode.S)) {
			State = States.Stairs;
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			State = States.Closet;
		}
	}

	void StateStairs() {
		if (hasSheets) {
			text.text = "You throw your sheets over your head like a ghost. This might be the craziest thing you've tried yet.\n\n";
			text.text = text.text + "[G] Go for it\n";
			text.text = text.text + "[R] Run away";
			if (Input.GetKeyDown(KeyCode.G)) {
				hasSheets = false;
			}
			if (Input.GetKeyDown(KeyCode.R)) {
				State = States.Corridor;
			}
		} else if (!hasCostume) {
			text.text = "A passing guard recognizes you and pounces. After a swift struggle, you are overpowered and returned to your cell.\n\nPress [SPACE] to continue.";
			if (Input.GetKeyDown(KeyCode.Space)) {
				State = States.New;
			}
		} else {
			text.text = "Your stolen disguise might do the trick.\n\n";
			text.text = text.text + "[L] Try your luck\n";
			text.text = text.text + "[R] Return to the Corridor";
			if (Input.GetKeyDown(KeyCode.L)) {
				State = States.Freedom;
			} else if (Input.GetKeyDown(KeyCode.R)) {
				State = States.Corridor;
			}
		}
	}

	void StateHairpin() {
		text.text = "You seem to remember someone using a hairpin to pick a lock. Or maybe that was something else?\n\n";
		text.text = text.text + "[T] Take Hairpin\n";
		text.text = text.text + "[R] Return to Corridor";
		if (Input.GetKeyDown(KeyCode.T)) {
			hasHairpin = true;
			State = States.Corridor;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			State = States.Corridor;
		}
	}

	void StateCloset() {
		if (closetUnlocked && !hasCostume) {
			text.text = "You look around the closet and see an old pair of janitor's coveralls. They might make a decent disguise.\n\n";
			text.text = text.text + "[C] Take Coveralls\n";
			if (Input.GetKeyDown(KeyCode.C)) {
				hasCostume = true;
				State = States.Corridor;
			}
		} else if (closetUnlocked) {
			text.text = "The closet seems pretty bare with nothing in it.\n\n";
		} else {
			text.text = "The closet door is locked. Maybe you can find something to open it?\n\n";
			if (hasHairpin) {
				text.text = text.text + "[H] Use Hairpin\n";
				if (Input.GetKeyDown(KeyCode.H)) {
					closetUnlocked = true;
				}
			}
		}
		text.text = text.text + "[R] Return to the Corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			State = States.Corridor;
		}
	}

	void StateFreedom() {
		text.text = "You have escaped!\n\nPress [ESC] to play again.";
	}
}
