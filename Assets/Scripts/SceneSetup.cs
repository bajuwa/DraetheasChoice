using UnityEngine;
using System.Collections;

public class SceneSetup : MonoBehaviour {

	public GameObject[] tiles;
	public int[] positions;

	// Use this for initialization
	void Start () {
		TileManager tileManagerScript = GameObject.Find("Tile Manager").GetComponent<TileManager>();
		for (int i=0; i<tiles.Length; i++) {
			GameObject instance = (GameObject) Instantiate(tiles[i]);
			Vector3 temp = instance.transform.position;
			temp.x = tileManagerScript.getCoordsOfPosition(positions[i]).x;
			temp.y = tileManagerScript.getCoordsOfPosition(positions[i]).y;
			instance.transform.position = temp;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
