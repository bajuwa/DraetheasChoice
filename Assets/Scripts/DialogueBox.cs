using UnityEngine;
using System.Collections;

public class DialogueBox : Clickable {
	
	// Change this stuff on setup!
	public GameObject backgroundImage;
	private GameObject backgroundImageInstance;
	public DialogueManager.character whoIsTalking;
	public bool picOnLeft = true;
	public bool destroyOnceComplete = true;
	public string[] script;
	public DialogueBox nextDialogue;
	
	public GameObject imagePlaceholder;
	public GameObject dialoguePlaceholder;
	public TextMesh dialogueText;
	
	private int scriptIndex = 0;
	
	private AlignmentManager alignmentManager;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		if (backgroundImage) backgroundImageInstance = (GameObject) Instantiate(backgroundImage);
		alignmentManager = GameObject.Find("Alignment Manager").GetComponent<AlignmentManager>();
		DialogueManager manager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
		switch (whoIsTalking) {
			case DialogueManager.character.PROTAGONIST:
				imagePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.protagImage;
				dialoguePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.protagDialogue;
				break;
			case DialogueManager.character.SISTER:
				imagePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.sisterImage;
				dialoguePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.sisterDialogue;
				break;
			case DialogueManager.character.LOVER:
				imagePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.loverImage;
				dialoguePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.loverDialogue;
				break;
			case DialogueManager.character.WITCH:
				imagePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.witchImage;
				dialoguePlaceholder.GetComponent<SpriteRenderer>().sprite = manager.witchDialogue;
				break;
		}
		dialogueText.text = script[scriptIndex];
		if (!picOnLeft) {
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
			temp = dialogueText.transform.localScale;
			temp.x *= -1;
			dialogueText.transform.localScale = temp;
		}
	}
	
	protected override void clickObject() {
		// users can click to advance dialogue
		scriptIndex++;
		if (scriptIndex < script.Length) {
			dialogueText.text = script[scriptIndex];
		} else {
			if (nextDialogue) Instantiate(nextDialogue, this.transform.position, Quaternion.identity);
			if (destroyOnceComplete) {
				if (backgroundImageInstance) Object.Destroy(backgroundImageInstance);
				Object.Destroy(this.gameObject);
			}
		}
		alignmentManager.checkForAlignmentEvents();
	}
}
