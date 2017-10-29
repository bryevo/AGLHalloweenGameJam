using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalController : MonoBehaviour {
	public string _destination;
    public string prevDestination;
    public GameObject spawnPoint;

	void OnTriggerStay2D(Collider2D collider){
		Debug.Log (collider);
		if(collider.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
                //prevDestination = GameObject.position;
                GameManager.Instance.mainPlayer.transform.position = spawnPoint.transform.position;
                GameManager.Instance.mainPlayer.transform.localScale = spawnPoint.transform.localScale;
				SceneManager.LoadScene(_destination);
			}
				
		}
	}

}
