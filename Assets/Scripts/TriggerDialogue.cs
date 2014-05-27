using UnityEngine;
using System.Collections;

public class TriggerDialogue : Clickable {

	public DialogueBox dialogue;

	override protected void clickObject() {
		Instantiate(dialogue);
	}
}
