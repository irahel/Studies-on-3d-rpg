using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingPost : ActionItem {
    public string[] dialogue;
    public string name;
    public override void Interact()
    {
        DialogueSystem.Instance.addNewDialogue(dialogue, name );
    }
}
