using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour {
	
	public Dialogue[] dialogue;
	public GameObject dialogueBox;
	
	
	// Use this for initialization
	void Start () {
		dialogueBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToSleep()
	{
		if (!dialogueBox.active)
		{	
		dialogueBox.SetActive(true);
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueBox);
		}

	}
}
