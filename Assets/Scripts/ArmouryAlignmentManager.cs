using UnityEngine;
using System.Collections;

public class ArmouryAlignmentManager : AlignmentManager {
	
	protected MemoryManager memoryManagerScript;
	private bool hasGeneratedGarden = false;
	public bool hasTiltedShelf = false;
	
	public GameObject garden;
	public GameObject rubbleShelves;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		memoryManagerScript = GameObject.Find("Memory Manager").GetComponent<MemoryManager>();
	}
	
	public override void checkForAlignmentEvents() {
		GameObject prefabInstance;
		// Check for conditions to create the garden in the background of the armoury window
		GameObject windowedRoom = GameObject.FindWithTag("WindowArmouryAlign");
		if (!hasGeneratedGarden && windowedRoom) {
			Debug.Log(windowedRoom.transform.position.z);
			// insert new tiles
			prefabInstance = (GameObject) Instantiate(garden);
			overwriteXYcoords(prefabInstance, windowedRoom.transform.position);
			hasGeneratedGarden = true;
			Debug.Log(windowedRoom.transform.position.z);
		}
		// Check for conditions to break the shelf with the shield on it
		GameObject shelvingPlaceholder = GameObject.FindWithTag("ShieldShelfPlaceholder");
		GameObject rock = GameObject.FindWithTag("Rock");
		if (!Input.GetMouseButtonDown(0) && shelvingPlaceholder && rock &&
			shelvingPlaceholder.GetComponent<BoxCollider2D>().OverlapPoint(
				rock.GetComponent<BoxCollider2D>().transform.TransformPoint(
					rock.GetComponent<BoxCollider2D>().center
				)
			)
			) {
			GameObject shield = GameObject.FindWithTag("Shield");
			// insert new rubble tiles
			GameObject brokenShelves = (GameObject) Instantiate(rubbleShelves, shield.transform.parent.transform.position, Quaternion.identity);
			brokenShelves.transform.parent = shield.transform.parent;
			// delete rock and shelf
			Object.Destroy(shelvingPlaceholder);
			Object.Destroy(rock);
			Object.Destroy(GameObject.FindWithTag("ArmouryShieldShelf"));
			// allow the shield to fall
			shield.rigidbody2D.isKinematic = false;
		}
		// Check for conditions to tilt the shelves and roll the pin off
		GameObject shelfLeft = GameObject.FindWithTag("LeftShelf");
		GameObject shelfRight = GameObject.FindWithTag("RightShelf");
		if (shelfLeft && shelfRight && !hasTiltedShelf) {
			int leftTilePos = tileManagerScript.getPositionOfCoords(shelfLeft.transform.parent.position);
			int rightTilePos = tileManagerScript.getPositionOfCoords(shelfRight.transform.parent.position);
			if ((leftTilePos == 0 && rightTilePos == 1) || (leftTilePos == 2 && rightTilePos == 3)) {
				shelfLeft.animation.Play();
				shelfRight.animation.Play();
				GameObject.FindWithTag("Brooch").animation.Play();
				hasTiltedShelf = true;
			}
		}
	}
}
