using UnityEngine;
using System.Collections;

public class ReallignIfShelfTilted : MonoBehaviour {
	
	private ArmouryAlignmentManager alignmentManager;

	// Use this for initialization
	void Start () {
		alignmentManager = GameObject.Find("Alignment Manager").GetComponent<ArmouryAlignmentManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (alignmentManager.hasTiltedShelf) {
			Vector3 temp = this.transform.localPosition;
			temp.y = -1.8f;
			this.transform.localPosition = temp;
		}
	}
}
