using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int min = 1;
		int max = 1000;

		print("Welcome to Number Wizard!");
		print("Pick a number between " + min + " and " + max + " and I'll guess it for you! Ready?");
		print("Press RETURN for a correct guess, UP if my guess is too low, and DOWN if I guessed too high.");

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			print("UP");
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			print("DOWN");
		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			print("RETURN");
		}
	}
}
