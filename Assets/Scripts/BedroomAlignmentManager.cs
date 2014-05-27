using UnityEngine;
using System.Collections;

public class BedroomAlignmentManager : AlignmentManager {

	public GameObject dragTile;
	public GameObject clickTile;
	
	protected MemoryManager memoryManagerScript;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		memoryManagerScript = GameObject.Find("Memory Manager").GetComponent<MemoryManager>();
		Instantiate(dragTile, tileManagerScript.getCoordsOfPosition(3), Quaternion.identity);
	}
	
	public override void checkForAlignmentEvents() {
		GameObject windowFrame = GameObject.FindWithTag("WindowFrame");
		GameObject doorFrame = GameObject.FindWithTag("DoorFrame");
		GameObject dragTileInstance = GameObject.FindWithTag("DragTile");
		if (dragTileInstance && windowFrame && doorFrame && 
			tileManagerScript.getPositionOfCoords(windowFrame.transform.position) 
				!= tileManagerScript.getPositionOfCoords(doorFrame.transform.position)) {
			// remove old tutorial hint
			Object.Destroy(dragTileInstance);
			// insert new hint for ransom note
			Instantiate(clickTile, tileManagerScript.getCoordsOfPosition(3), Quaternion.identity);
		}
		GameObject clickTileInstance = GameObject.FindWithTag("ClickTile");
		if (clickTileInstance && memoryManagerScript.isActivated(MemoryManager.memory.RANSOM_NOTE)) {
			// remove old tutorial hint
			Object.Destroy(clickTileInstance);
		}
	}
}
