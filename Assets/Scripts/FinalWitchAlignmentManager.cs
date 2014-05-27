using UnityEngine;
using System.Collections;

public class FinalWitchAlignmentManager : AlignmentManager {

	public GameObject mainGate;
	public GameObject statue;
	public DialogueBox attemptToKillEsterDialogue;

	public override void checkForAlignmentEvents() {
		// Check for conditions to swap mini gate image for full gate tile
		GameObject miniGate = GameObject.FindWithTag("MiniGate");
		GameObject study = GameObject.FindWithTag("Study");
		if (miniGate && study && 
			tileManagerScript.getPositionOfCoords(miniGate.transform.position) 
				!= tileManagerScript.getPositionOfCoords(study.transform.position)) {
			// insert new tiles
			GameObject mainGateInstance = (GameObject) Instantiate(mainGate);
			overwriteXYcoords(mainGateInstance, miniGate.transform.position);
			// delete old
			Object.Destroy(miniGate);
		}
		// Check for conditions to generate the statue behind Ester
		GameObject statueInstance = GameObject.FindWithTag("Statue");
		GameObject ester = GameObject.FindWithTag("Ester");
		if (ester && !statueInstance) {
			// insert new tiles
			statueInstance = (GameObject) Instantiate(statue);
			overwriteXYcoords(statueInstance, ester.transform.position);
		}
		// Check for the sacrifice
		GameObject dagger = GameObject.FindWithTag("Dagger");
		GameObject lover = GameObject.FindWithTag("Lover");
		GameObject sister = GameObject.FindWithTag("Sister");
		if (dagger) {
			if (sister && 
				sister.GetComponent<BoxCollider2D>().OverlapPoint(
					dagger.GetComponent<BoxCollider2D>().transform.TransformPoint(
						dagger.GetComponent<BoxCollider2D>().center
					)
				)
			) {
				Application.LoadLevel((int)ClickToLoadNextScene.sceneName.SAVED_LOVER);
			} else if (lover && 
				lover.GetComponent<BoxCollider2D>().OverlapPoint(
					dagger.GetComponent<BoxCollider2D>().transform.TransformPoint(
						dagger.GetComponent<BoxCollider2D>().center
					)
				)
			) {
				Application.LoadLevel((int)ClickToLoadNextScene.sceneName.SAVED_SISTER);
			} else if (ester && 
				tileManagerScript.getPositionOfCoords(ester.transform.position) 
					!= tileManagerScript.getPositionOfCoords(statueInstance.transform.position) && 
				ester.GetComponent<BoxCollider2D>().OverlapPoint(
					dagger.GetComponent<BoxCollider2D>().transform.TransformPoint(
						dagger.GetComponent<BoxCollider2D>().center
					)
				)
			) {
				dagger.transform.position = Camera.main.ScreenToWorldPoint(dagger.GetComponent<Draggable>().dragStartCoord);
				Instantiate(attemptToKillEsterDialogue);
			}
		}
	}
}
