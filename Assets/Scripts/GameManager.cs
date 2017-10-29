using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}

	public void LoadScene(string sceneName)
	{
		//SceneManager.LoadScene (sceneName);
		Debug.Log(sceneName);
	}
}
