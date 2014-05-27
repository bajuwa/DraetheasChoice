using UnityEngine;
using System.Collections;

public class Tile : Draggable {

	private TileManager tileManagerScript;
	private AlignmentManager alignmentManagerScript;
	
	// Use this for initialization
	public override void Start () {
		base.Start();
		tileManagerScript = GameObject.Find("Tile Manager").GetComponent<TileManager>();
		if (GameObject.Find("Alignment Manager")) alignmentManagerScript = GameObject.Find("Alignment Manager").GetComponent<AlignmentManager>();
	}
	
	// Update is called once per frame
	void Update() {
		// If the player clicked/held down over a tile and possibly moved it, make sure to put it in to a valid position
		if (!Input.GetMouseButton(0)) {
			transform.position = tileManagerScript.getClosestValidPosition(transform.position);
			if (alignmentManagerScript) alignmentManagerScript.checkForAlignmentEvents();
		}
	}
	
}
