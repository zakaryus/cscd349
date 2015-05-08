using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CharacterManager : MonoBehaviour {

	private SpriteRenderer spriterRenderer;
	public Sprite[] sprites;

	void Awake() {
		spriterRenderer = FindObjectOfType<SpriteRenderer> ();
	}

	public void LoadCharacter(int index) {

		spriterRenderer.sprite = sprites [index];
		print (sprites [index].texture.ToString ());
	}
}
