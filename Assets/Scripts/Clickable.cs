using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
	
	private PointerManager pointerManagerScript;

	// Use this for initialization
	protected virtual void Start () {
		pointerManagerScript = GameObject.Find("Pointer Manager").GetComponent<PointerManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter() {
		if (this.enabled) pointerManagerScript.setClickableCursor();
	}
	
	void OnMouseExit() {
		if (this.enabled) pointerManagerScript.setDefaultCursor();
	}
	
	void OnMouseOver() {
		if (this.enabled && Input.GetMouseButtonDown(0)) { 
			clickObject();
		}
	}
	
	virtual protected void clickObject() {
		// Override this!
	}
}
