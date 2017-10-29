using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerState {
    public Vector3 position;
    public Vector3 scale;
    public PlayerState()
    {
        position = new Vector3();
        scale = new Vector3();
    }

    public PlayerState(Vector3 pos, Vector3 scal) {
        position = pos;
        scale = scal;
    }
}

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public PlayerState playerState;
    public GameObject mainPlayer;
    private void Awake()
    {
        if (!Instance) Instance = this;
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        playerState = new PlayerState();
		DontDestroyOnLoad (this.gameObject);
	}

	public void LoadScene(string sceneName)
	{
		//SceneManager.LoadScene (sceneName);
		Debug.Log(sceneName);
	}
}
