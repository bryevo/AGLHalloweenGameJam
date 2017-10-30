using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallwayToTown : MonoBehaviour {


	void OnTriggerStay2D(Collider2D collider){
		Debug.Log (collider);
		if(collider.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				SceneManager.LoadScene("Town");
				collider.gameObject.transform.position = new Vector3(7.419995f, -3.56f, 0f);
				collider.gameObject.transform.localScale = new Vector3 (1.2f, 1.2f, 1f);
			}
		}
	}
}
