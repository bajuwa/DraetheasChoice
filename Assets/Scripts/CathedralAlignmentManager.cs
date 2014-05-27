using UnityEngine;
using System.Collections;

public class CathedralAlignmentManager : AlignmentManager {

	public GameObject wallTorch;

	public override void checkForAlignmentEvents() {
		GameObject torch;
		// Check for creating the addition painting behind frame
		GameObject wallTorchInstance = GameObject.FindWithTag("WallWithTorch");
		GameObject paintingFrame = GameObject.FindWithTag("CathedralPaintingFrame");
		if (paintingFrame && !wallTorchInstance) {
			// insert new tiles
			wallTorchInstance = (GameObject) Instantiate(wallTorch);
			overwriteXYcoords(wallTorchInstance, paintingFrame.transform.position);
		}
		// Check for burning the curtain
		GameObject curtain = GameObject.FindWithTag("Curtain");
		torch = GameObject.FindWithTag("Torch");
		if (curtain && torch && 
			curtain.GetComponent<BoxCollider2D>().OverlapPoint(
				torch.GetComponent<BoxCollider2D>().transform.TransformPoint(
					torch.GetComponent<BoxCollider2D>().center
				)
			)
			) {
			// destory the torch and curtain
			Object.Destroy(curtain);
			Object.Destroy(torch);
		}
		// Check if the torch was used to burn the curtain, need to delete painting (or creates a gamebreak)
		wallTorchInstance = GameObject.FindWithTag("WallWithTorch");
		torch = GameObject.FindWithTag("Torch");
		if (wallTorchInstance && !torch) {
			Object.Destroy(wallTorchInstance);
		}
		// Check for combining painting and stained glass
		GameObject stainedGlass = GameObject.FindWithTag("StainedGlass");
		GameObject paintCan = GameObject.FindWithTag("PaintCan");
		if (stainedGlass && paintCan && 
			stainedGlass.GetComponent<CircleCollider2D>().OverlapPoint(
				paintCan.GetComponent<BoxCollider2D>().transform.TransformPoint(
					paintCan.GetComponent<BoxCollider2D>().center
				)
			)
			) {
			// enable sprite and collider of the glass
			stainedGlass.GetComponent<SpriteRenderer>().enabled = true;
			stainedGlass.GetComponent<MemoryTriggerClick>().enabled = true;
			// destory old tiles
			Object.Destroy(paintCan);
		}
	}
}
