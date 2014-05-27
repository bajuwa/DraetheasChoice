using UnityEngine;
using System.Collections;

public class MemoryManager : MonoBehaviour {

	public enum memory {
		RANSOM_NOTE = 0,
		URN,
		DATE_PHOTO,
		SHIELD,
		BROOCH,
		JAM,
		FIREPLACE,
		MIRROR,
		RUINED_BOOK,
		STATUE,
		STAINED_GLASS
	};
	public bool[] activatedMemories;
	
	public DialogueBox ransomNote;
	public DialogueBox urn;
	public DialogueBox datePhoto;
	public DialogueBox shield;
	public DialogueBox brooch;
	public DialogueBox jam;
	public DialogueBox fireplace;
	public DialogueBox mirror;
	public DialogueBox ruinedBook;
	public DialogueBox statue;
	public DialogueBox stainedGlass;

	// Use this for initialization
	void Start () {
		activatedMemories = new bool[System.Enum.GetNames(typeof(memory)).Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool isActivated(memory mem) {
		return activatedMemories[(int)mem];
	}
	
	public bool areActivated(memory[] mem) {
		for (int i=0; i<mem.Length; i++) {
			if (!activatedMemories[(int)mem[i]]) return false;
		}
		return true;
	}
	
	public void activateMemory(memory mem) {
		switch (mem) {
			case memory.RANSOM_NOTE:
				Instantiate(ransomNote);
				break;
			case memory.URN:
				Instantiate(urn);
				break;
			case memory.DATE_PHOTO:
				Instantiate(datePhoto);
				break;
			case memory.SHIELD:
				Instantiate(shield);
				break;
			case memory.BROOCH:
				Instantiate(brooch);
				break;
			case memory.JAM:
				Instantiate(jam);
				break;
			case memory.FIREPLACE:
				Instantiate(fireplace);
				break;
			case memory.MIRROR:
				Instantiate(mirror);
				break;
			case memory.RUINED_BOOK:
				Instantiate(ruinedBook);
				break;
			case memory.STATUE:
				Instantiate(statue);
				break;
			case memory.STAINED_GLASS:
				Instantiate(stainedGlass);
				break;
		}
		activatedMemories[(int)mem] = true;
	}
}
