using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {

	private bool gamePaused;

	// Use this for initialization
	void Start () {
		gamePaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p")) 
		{
			//PauseGame();
			gamePaused = !gamePaused;
			if (gamePaused) {
				PauseGame();
			}else{
				UnpauseGame();
			}
		}


	}

	void PauseGame() {
		Time.timeScale = 0;
	}

	void UnpauseGame(){
		Time.timeScale = 1;
	}
}
