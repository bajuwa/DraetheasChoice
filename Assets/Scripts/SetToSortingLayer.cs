using UnityEngine;
using System.Collections;

public class SetToSortingLayer : MonoBehaviour {

	public int sortingLayerId;

	// Use this for initialization
	void Start () {
		renderer.sortingLayerID = sortingLayerId;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
