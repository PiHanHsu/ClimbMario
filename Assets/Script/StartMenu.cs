using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Texture Background;
	public GUISkin GameGUISkin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		
		GUI.skin = GameGUISkin;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Background);
		float x = Screen.width * 0.15f;
		float y = Screen.height * 0.5f;
		float width = Screen.width * 0.15f;
		float height = Screen.height * 0.1f;
		float gap = Screen.height * 0.05f;

		if (GUI.Button (new Rect (x, y, width, height), "Play")) {
			SceneManager.LoadScene ("Playing");
		}
		if (GUI.Button (new Rect (x, y+height+gap, width, height), "Setting")) {
			SceneManager.LoadScene ("Calibration");
		}
		if (GUI.Button (new Rect (x,y+(height+gap)*2 , width, height), "Quit")) {
			print ("quit!!");
			Application.Quit ();
		}
	}
}
