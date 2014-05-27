using UnityEngine;
using System.Collections;

public class ClickToLoadNextScene : Clickable {

	public enum sceneName {
		TITLE,
		BEDROOM,
		FIRST_TRANSITION,
		ARMOURY,
		KITCHEN,
		FIRST_WITCH_ENCOUNTER,
		SECOND_TRANSITION,
		RUINS,
		CATHEDRAL,
		FINAL_ENCOUNTER,
		SAVED_LOVER,
		SAVED_SISTER
	}

	public sceneName nextScene;

	protected override void clickObject() {
		Application.LoadLevel((int)nextScene);
	}
}
