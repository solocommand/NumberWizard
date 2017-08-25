using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	int min;
	int max;
	int guess;

	// Use this for initialization
	void Start () {
		StartGame();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			Next();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			guess = (max + min) / 2;
			Next();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print("I won!");
			StartGame();
		}
	}

	void StartGame()
	{
		min = 1;
		max = 1000;
		print("┌===========================┐");
		print("| Welcome to Number Wizard! |");
		print("└===========================┘");
		print("Pick a number between " + min + " and " + max + " and I'll guess it for you! Ready?");
		max = max + 1;
		Next();
	}

	void Next() {
		guess = (max + min) / 2;
		print("Higher or lower than " + guess + "?");
		print("Press RETURN for a correct guess, UP if my guess is too low, and DOWN if I guessed too high.");
	}
}
