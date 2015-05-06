using UnityEngine;
using System.Collections;

public class btnStart : MonoBehaviour {

	public void LoadLevel(string name) {
		print ("btn pressed");
		Debug.Log (name);
		//GameManager.Instance.SetGameState (GameManager.GameState.ChooseCharacterScene);
	}
}
