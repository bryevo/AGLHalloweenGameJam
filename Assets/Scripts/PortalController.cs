using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalController : MonoBehaviour {

	public GameObject Player;
	public GameObject SpawnPoint;

	void OnTriggerStay2D(Collider2D collider){
		Debug.Log (collider);
		if(collider.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				SceneManager.LoadScene("HotelHallway");
				collider.gameObject.transform.position = new Vector3(7.959f, -0.922f, 0f);
				collider.gameObject.transform.localScale = new Vector3 (-2.491678f, 2.491678f, 2.491678f);
				Player.GetComponent<PlayerController> ()._facingRight = false;

			}
		}
	}

}
