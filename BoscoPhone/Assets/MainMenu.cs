using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()//load next leve
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void QuiteGame()
	{
		Debug.Log("QUIT");//Just to show getting in since need that other line to make quit work in the editor.
		Application.Quit();
		//UnityEditor.EditorApplication.isPlaying = false;//This is only for the editor, not released products.
	}
}
