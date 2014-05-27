using UnityEngine;
using System.Collections;

public class DraggableToArea : Draggable {
	public string[] tagsOfAcceptedAreas;
	
	void OnMouseUp() {
		BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
		Collider2D[] collidersWithinRange = Physics2D.OverlapPointAll(collider.transform.TransformPoint(collider.center));
		bool isWithinAcceptableRange = false;
		for (int i=0; i<collidersWithinRange.Length; i++) {
			Debug.Log(collidersWithinRange[i].gameObject.tag);
			for (int j=0; j<tagsOfAcceptedAreas.Length; j++) {
				if (collidersWithinRange[i].gameObject.tag == tagsOfAcceptedAreas[j]) isWithinAcceptableRange = true;
			}
		}
		if (!isWithinAcceptableRange) this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(dragStartCoord);
	}
}
