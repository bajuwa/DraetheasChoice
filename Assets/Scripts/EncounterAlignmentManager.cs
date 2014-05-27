using UnityEngine;
using System.Collections;

public class EncounterAlignmentManager : AlignmentManager {
	
	public GameObject transitionOptions;

	public override void checkForAlignmentEvents() {
		// Check for mirror breaking conditions
		GameObject decisionDialogue = GameObject.FindWithTag("Decision");
		GameObject transitionOptionsInstance = GameObject.FindWithTag("Transition");
		if (decisionDialogue && !transitionOptionsInstance) {
			// insert new tiles
			Instantiate(transitionOptions);
		}
	}
}