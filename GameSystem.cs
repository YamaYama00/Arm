using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {
    public void StartGame() {
	SceneManager.LoadScene("Game");
    }
}
