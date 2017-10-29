using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;
    private RectTransform buttonRT, textRT;
    public float textWidth, textHeight, left, right, top, bottom;
    private GameObject dialogueBox;
    private List<GameObject> objList;
    private List<Button> buttonList;
    private List<Text> textList;

    void Start()
    {
        objList = new List<GameObject>();
        buttonList = new List<Button>();
        textList = new List<Text>();
    }

    public void StartDialogue(Dialogue[] dialogue, GameObject dialogueBox)
    {
        this.dialogueBox = dialogueBox;
        float pos = 0.6f;
        foreach (var sentence in dialogue)
        {
            GameObject button = (GameObject) Instantiate(prefabButton);
            button.transform.localPosition = new Vector3(-6.35f, pos, 0);
            buttonRT = (RectTransform) button.transform;
            buttonRT.sizeDelta = new Vector2(0.9f, 0.9f);
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
            buttonText.transform.localScale = new Vector3(0.03f, 0.05f, 0.04f);
            buttonText.color = Color.white;
            buttonText.text = sentence.value;
            tempButton.onClick.AddListener(() => ButtonClicked(sentence.key, sentence.value));
            pos -= 0.95f;

            objList.Add(button);
            buttonList.Add(tempButton);
            textList.Add(buttonText);
        }
    }

    void ButtonClicked(string key, string value)
    {
        if (key.Equals("Sleep"))
        {
            Debug.Log(key + ": " + value);
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