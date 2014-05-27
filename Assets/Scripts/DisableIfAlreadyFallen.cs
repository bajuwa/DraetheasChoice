using UnityEngine;
using System.Collections;

public class DisableIfAlreadyFallen : MonoBehaviour {

	private ArmouryAlignmentManager alignmentManager;

	// Use this for initialization
	void Start () {
		alignmentManager = GameObject.Find("Alignment Manager").GetComponent<ArmouryAlignmentManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (alignmentManager.hasTiltedShelf) renderer.enabled = false;
	}
}
