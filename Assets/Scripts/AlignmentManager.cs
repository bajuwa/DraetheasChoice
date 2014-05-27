using UnityEngine;
using System.Collections;

public class AlignmentManager : MonoBehaviour {

	protected TileManager tileManagerScript;

	// Use this for initialization
	protected virtual void Start () {
		tileManagerScript = GameObject.Find("Tile Manager").GetComponent<TileManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public virtual void checkForAlignmentEvents() {
		// Override this for each scene!
	}
	
	protected void overwriteXYcoords(GameObject objToMove, Vector3 newPos) {
		Vector3 temp = objToMove.transform.position;
		temp.x = newPos.x;
		temp.y = newPos.y;
		objToMove.transform.position = temp;
	}
}
