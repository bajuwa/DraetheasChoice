using UnityEngine;
using System.Collections;

public class PointerManager : MonoBehaviour {

	// basic cursor to return to
	public Texture2D defaultCursor;
	// cursor to show up when hovering over a draggable object
	public Texture2D clickableCursor;
	// cursor to show up when hovering over a draggable object
	public Texture2D dragCursor;
	// since the 'point' of the drag cursor is in the center, we need to calculate and apply an offset
	private Vector2 dragCursorOffset;
	
	public void setDefaultCursor() {
		Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
	}
	
	public void setClickableCursor() {
		Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.Auto);
	}
	
	public void setDraggableCursor() {
		Cursor.SetCursor(dragCursor, dragCursorOffset, CursorMode.Auto);
	}

	// Use this for initialization
	void Start () {
		dragCursorOffset = new Vector2(dragCursor.width/2, dragCursor.height/2);
		setDefaultCursor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
