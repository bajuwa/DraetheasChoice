using UnityEngine;
using System.Collections;

public class MemoryTriggerClick : Clickable {

	private MemoryManager memoryManagerScript;
	public MemoryManager.memory memoryToTrigger;
	
	// Use this for initialization
	protected new void Start () {
		base.Start();
		memoryManagerScript = GameObject.Find("Memory Manager").GetComponent<MemoryManager>();
	}

	override protected void clickObject() {
		memoryManagerScript.activateMemory(memoryToTrigger);
	}
}
