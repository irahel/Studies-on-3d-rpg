using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public string npc_name;
    public GameObject dialoguePanel;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text DialogueText, nameText;
    int dialogueIndex;

	void Awake () {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        DialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { continueDialogue();  } );

        dialoguePanel.SetActive(false);

		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}
	
    public void addNewDialogue(string[] lines, string npc_name)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npc_name = npc_name;
        Debug.Log(dialogueLines.Count);
        createDialogue();
    }

    public void createDialogue()
    {
        DialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npc_name;
        dialoguePanel.SetActive(true);
    }

    public void continueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            DialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
