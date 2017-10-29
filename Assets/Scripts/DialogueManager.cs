using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject prefabButton, prefabText;
    public RectTransform ParentPanel;
    private RectTransform buttonRT, textRT, descRT;
    public float textWidth, textHeight, left, right, top, bottom;
    private GameObject dialogueBox;
    private List<GameObject> objList;
    private List<Button> buttonList;
    private List<Text> textList;
    private Dictionary<string, DialogueList> dictDialogue;

    void Start()
    {
        dictDialogue = new Dictionary<string, DialogueList>();
        objList = new List<GameObject>();
        buttonList = new List<Button>();
        textList = new List<Text>();
    }

    public void StartDialogue(DialogueList[] dialogueList, GameObject dialogueBox)
    {
        dictDialogue.Clear();
        this.dialogueBox = dialogueBox;

        foreach (var dialogues in dialogueList)
        {
            dictDialogue.Add(dialogues.keyID, dialogues);
        }
        DisplayNextSentence("0");
    }

    public void DisplayNextSentence(string hashKey)
    {
        if (dictDialogue.Count == 0)
        {
            Debug.Log("end lmao");
            return;
        }
        DialogueList dope = dictDialogue[hashKey];
        Debug.Log("Start Dialogue: " + dope.description);
        float pos = 4.2f;
        GameObject textObj = (GameObject) Instantiate(prefabText);
        textObj.transform.localPosition = new Vector3(0.0f, pos, 0);
        textObj.transform.SetParent(ParentPanel, false);
        Text descriptionText = textObj.GetComponent<Text>();
        descriptionText.text = dope.description;
        descRT = (RectTransform) descriptionText.transform;
        descRT.sizeDelta = new Vector2(420, 18);
        descriptionText.transform.localScale = new Vector3(0.04f, 0.04f, 1);
        descriptionText.color = Color.white;
        pos -= 0.65f;
        objList.Add(textObj);
        textList.Add(descriptionText);
        foreach (var dialogue in dope.dialogue)
        {
            GameObject button = (GameObject) Instantiate(prefabButton);

            button.transform.localPosition = new Vector3(0f, pos, 0);
            buttonRT = (RectTransform) button.transform;

            buttonRT.sizeDelta = new Vector2(15f, 0.9f);
            button.transform.SetParent(ParentPanel, false);
            button.transform.localScale = new Vector3(1, 1, 1);
            Button tempButton = button.GetComponent<Button>();
            ColorBlock cb = tempButton.colors;
            cb.normalColor = new Color();
            cb.highlightedColor = new Color();
            cb.pressedColor = Color.cyan;
            tempButton.colors = cb;

            Text buttonText = tempButton.GetComponentsInChildren<Text>()[0];

            textRT = (RectTransform) buttonText.transform;
            textRT.offsetMax = new Vector2(left, bottom);
            textRT.offsetMin = new Vector2(right, top);
            buttonText.transform.localScale = new Vector3(0.035f, 0.035f, 0f);
            buttonText.alignment = TextAnchor.MiddleLeft;
            buttonText.color = Color.white;
            buttonText.text = dialogue.value;
            tempButton.onClick.AddListener(() => ButtonClicked(dialogue.key, dialogue.value));
            pos -= 0.65f;

            objList.Add(button);
            buttonList.Add(tempButton);
            textList.Add(buttonText);
        }
    }


    void ButtonClicked(string key, string value)
    {
        if (key.Equals("Sleep"))
        {
            foreach (var obj in objList)
            {
                Destroy(obj);
            }
            objList.Clear();
            foreach (var obj in buttonList)
            {
                Destroy(obj);
            }
            buttonList.Clear();
            foreach (var obj in textList)
            {
                Destroy(obj);
            }
            textList.Clear();
            DisplayNextSentence("1");
        }
        else
        {
            foreach (var obj in objList)
            {
                Destroy(obj);
            }
            objList.Clear();
            foreach (var obj in buttonList)
            {
                Destroy(obj);
            }
            buttonList.Clear();
            foreach (var obj in textList)
            {
                Destroy(obj);
            }
            textList.Clear();

            dialogueBox.SetActive(false);
        }
    }
}