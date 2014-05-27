using UnityEngine;
using System.Collections;

public class KitchenAlignmentManager : AlignmentManager {

	private bool hasGeneratedCabin = false;

	public GameObject cabin;
	
	public override void checkForAlignmentEvents() {		
		// Check for conditions to create the cabin in the background of the painting
		GameObject paintingFrame = GameObject.FindWithTag("KitchenPaintingFrame");
		if (!hasGeneratedCabin && paintingFrame) {
			// insert new tiles
			Instantiate(cabin);
			overwriteXYcoords(cabin, paintingFrame.transform.position);
			hasGeneratedCabin = true;
		}
		// Check for conditions to use the wood to stoke the fire
		GameObject fireplace = GameObject.FindWithTag("Fireplace");
		GameObject wood = GameObject.FindWithTag("Wood");
		if (!Input.GetMouseButtonDown(0) && fireplace && wood &&
			fireplace.GetComponent<BoxCollider2D>().OverlapPoint(
				wood.GetComponent<BoxCollider2D>().transform.TransformPoint(
					wood.GetComponent<BoxCollider2D>().center
				)
			)
			) {
			// enable upgraded fire
			fireplace.GetComponent<SpriteRenderer>().enabled = true;
			fireplace.GetComponent<MemoryTriggerClick>().enabled = true;
			// delete the wood
			Object.Destroy(wood);
		}
		// Check for conditions to place the jam in the cupboard
		GameObject cupboard = GameObject.FindWithTag("KitchenCupboard");
		GameObject jam = GameObject.FindWithTag("Jam");
		if (!Input.GetMouseButtonDown(0) && cupboard && jam &&
			cupboard.GetComponent<BoxCollider2D>().OverlapPoint(
				jam.GetComponent<BoxCollider2D>().transform.TransformPoint(
					jam.GetComponent<BoxCollider2D>().center
				)
			)
			) {
			// realign jam to be in the proper place
			jam.transform.position = cupboard.transform.position;
			// disable the jam draggable script and enable the memory script
			jam.GetComponent<DraggableToArea>().enabled = false;
			jam.GetComponent<MemoryTriggerClick>().enabled = true;
		}
	}
	
}
