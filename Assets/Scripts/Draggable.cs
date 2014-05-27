using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {
	
	private PointerManager pointerManagerScript;

	// stored information about click n drag coords
	public Vector3 dragStartCoord;
	private Vector3 dragOffset;
	
	// Use this for initialization
	public virtual void Start () {
		pointerManagerScript = GameObject.Find("Pointer Manager").GetComponent<PointerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter() {
		pointerManagerScript.setDraggableCursor();
	}
	
	void OnMouseExit() {
		pointerManagerScript.setDefaultCursor();
	}
	
	 
	void OnMouseDown() {
		// Store the original coord of the object we are dragging
		dragStartCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		dragOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragStartCoord.z));
	}
	 
	void OnMouseDrag()
	{
		// Continuously update the position of the dragged object based on the mouse position
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragStartCoord.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + dragOffset;
		transform.position = curPosition;
	}
	
}
