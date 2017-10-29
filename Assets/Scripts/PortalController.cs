using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalController : MonoBehaviour {
	public string _destination;

	void OnTriggerStay2D(Collider2D collider){
		Debug.Log (collider);
		if(collider.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				SceneManager.LoadScene(_destination);
			}
		}
	}

}
