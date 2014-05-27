using UnityEngine;
using System.Collections;

public class RuinsAlignmentManager : AlignmentManager {

	public GameObject tileToAddAfterBreakingMirror;
	public GameObject updatedHallwayTile;
	public GameObject pedistalRoom;
	
	private bool hasGeneratedPedestalRoom = false;
	
	public override void checkForAlignmentEvents() {
		GameObject instance;
		// Check for mirror breaking conditions
		GameObject mirrorRoom = GameObject.FindWithTag("MirrorAlign");
		GameObject hallway = GameObject.FindWithTag("HallwayAlign");
		if (mirrorRoom && hallway && 
			tileManagerScript.getPositionOfCoords(mirrorRoom.transform.position) 
				== tileManagerScript.getPositionOfCoords(hallway.transform.position)) {
			// insert new tiles
			instance = (GameObject) Instantiate(tileToAddAfterBreakingMirror);
			overwriteXYcoords(instance, hallway.transform.position);
			instance = (GameObject) Instantiate(updatedHallwayTile);
			overwriteXYcoords(instance, hallway.transform.position);
			// delete old tiles
			Object.Destroy(mirrorRoom);
			Object.Destroy(hallway);
		}
		
		// Check for conditions to create the platform room in the background of the hallway
		GameObject cellRoom = GameObject.FindWithTag("CellroomAlign");
		GameObject hallwayWithShards = GameObject.FindWithTag("HallwayShardsAlign");
		if (!hasGeneratedPedestalRoom && cellRoom && hallwayWithShards && 
			tileManagerScript.getPositionOfCoords(cellRoom.transform.position) 
				!= tileManagerScript.getPositionOfCoords(hallwayWithShards.transform.position)) {
			// insert new tiles
			instance = (GameObject) Instantiate(pedistalRoom);
			overwriteXYcoords(instance, hallwayWithShards.transform.position);
			hasGeneratedPedestalRoom = true;
		}
	}
}
