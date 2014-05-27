using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {

	// The valid coords where tiles can be placed (the CENTER of the tile)
	private Vector3[] validTileCoords;
	
	// Given a certain coord, find the closest valid (ie unoccupied) coordinate 
	public Vector3 getClosestValidPosition(Vector3 coord) {
		Vector3 closestCoord = validTileCoords[0];
		for (int i=1; i<validTileCoords.Length; i++) {
			if (Vector3.Distance(coord, validTileCoords[i]) < Vector3.Distance(coord, closestCoord)) {
				closestCoord = validTileCoords[i];
			}
		}
		return new Vector3(closestCoord.x, closestCoord.y, coord.z);
	}
	
	public Vector3 getCoordsOfPosition(int positionIndex) {
		if (validTileCoords == null || validTileCoords.Length == 0) instantiateCoords();
		return validTileCoords[positionIndex];
	}
	
	public int getPositionOfCoords(Vector3 coords) {
		for (int i=0; i<validTileCoords.Length; i++) {
			if (validTileCoords[i].x == coords.x && validTileCoords[i].y == coords.y) {
				return i;
			}
		}
		return -1;
	}
	
	// Use this for initialization
	void Start () {
		instantiateCoords();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void instantiateCoords() {
		validTileCoords = new Vector3[4];
		validTileCoords[0] = new Vector3(-2.249f, 2.249f, 0);
		validTileCoords[1] = new Vector3(2.249f, 2.249f, 0);
		validTileCoords[2] = new Vector3(-2.249f, -2.249f, 0);
		validTileCoords[3] = new Vector3(2.249f, -2.249f, 0);
	}
}
