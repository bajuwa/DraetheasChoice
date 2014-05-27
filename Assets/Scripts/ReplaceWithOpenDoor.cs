using UnityEngine;
using System.Collections;

public class ReplaceWithOpenDoor : MonoBehaviour {

	private MemoryManager memoryManager;
	
	public Sprite openDoor;
	public MemoryManager.memory[] prerequisiteMemories;
	
	// Use this for initialization
	void Start () {
		memoryManager = GameObject.Find("Memory Manager").GetComponent<MemoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject && this.gameObject.GetComponent<SpriteRenderer>() 
			&& memoryManager.areActivated(prerequisiteMemories)) {
			GetComponent<SpriteRenderer>().sprite = openDoor;
			GetComponent<ClickToLoadNextScene>().enabled = true;
			GetComponent<TriggerDialogue>().enabled = false;
		}
	}
}
