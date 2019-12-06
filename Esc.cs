using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour {
    void Quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
	#elif UNITY_STANDALONE
	UnityEngine.Application.Quit();
	#endif
    }
    void Update () {
	if (Input.GetKey(KeyCode.Escape)) {
	    Application.LoadLevel("edit");
	}

	if (Input.GetKey(KeyCode.Escape)&&Input.GetKey(KeyCode.LeftShift)) {
	    Quit();
	}
    }
	// Use this for initialization
}
