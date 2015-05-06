using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("Level Load: "+ name);
		Application.LoadLevel (name);
		
		//GameManager.Instance.SetGameState (GameManager.GameState.ChooseCharacterScene);
	}

	public void Quit(){

		Application.Quit ();

	}
}

