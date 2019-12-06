using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class InputManager : MonoBehaviour {

    InputField inputField;
    public int x;
    string x_string;
    public bool state = false;

    void Start () {
	inputField = GetComponent<InputField>();
	InitInputField();
    }

    public void InputLogger() {
	string inputValue = inputField.text;
	Debug.Log(inputValue);
	InitInputField();
    }

    void InitInputField() {
	inputField.text = "";
	inputField.ActivateInputField();
	x_string = inputField.text;
	Int32.TryParse(x_string, out x);
	state = true;
    }
}
