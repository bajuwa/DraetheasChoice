using UnityEngine;
using System.Collections;

public class FirstWitchAlignmentManager : AlignmentManager {

	public GameObject brokenFence;
	public GameObject bridge;
	public GameObject combinedCliff;

	public override void checkForAlignmentEvents() {		
		// Check for conditions to replace the destroyed fence with rubble
		GameObject openingScene = GameObject.FindWithTag("FirstWitchOpeningScene");
		GameObject fence = GameObject.FindWithTag("Fence");
		GameObject brokenFenceInstance = GameObject.FindWithTag("BrokenFence");
		if (!fence && !brokenFenceInstance && openingScene) {
			// insert the rubble for the destroyed fence
			brokenFenceInstance = (GameObject) Instantiate(brokenFence);
			overwriteXYcoords(brokenFenceInstance, openingScene.transform.position);
			brokenFenceInstance.transform.parent = openingScene.transform;
			// activate the collider to allow player to advance
			GameObject nextSceneColliderPlaceholder = GameObject.FindWithTag("FWOS-NextSceneCollider");
			nextSceneColliderPlaceholder.GetComponent<BoxCollider2D>().enabled = true;
		}
		// Check for conditions to add the bridge tile on top of the bridge walkway
		GameObject bridgeInstance = GameObject.FindWithTag("Bridge");
		GameObject bridgeWalkway = GameObject.FindWithTag("BridgeWalkway");
		if (bridgeWalkway && !bridgeInstance) {
			// insert the rubble for the destroyed fence
			bridgeInstance = (GameObject) Instantiate(bridge);
			overwriteXYcoords(bridgeInstance, bridgeWalkway.transform.position);
		}
		// Check for conditions to use the bridge to make way to next tile on cliff
		GameObject cliff = GameObject.FindWithTag("Cliff");
		if (cliff && bridgeInstance && 
			tileManagerScript.getPositionOfCoords(cliff.transform.position) 
				== tileManagerScript.getPositionOfCoords(bridgeInstance.transform.position)) {
			// create the new combined tile
			GameObject combinedCliffInstance = (GameObject) Instantiate(combinedCliff);
			overwriteXYcoords(combinedCliffInstance, cliff.transform.position);
			// destroy the old two tiles
			Object.Destroy(cliff);
			Object.Destroy(bridgeInstance);
		}
	}
}
