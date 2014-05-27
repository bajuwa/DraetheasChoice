using UnityEngine;
using System.Collections;

public class ClickToAnimate : Clickable {

	public string[] tagsOfOtherObjectsToAnimate;
	public GameObject[] objectsToAnimate;

	protected override void clickObject() {
		animation.Play();
		GameObject objectToAnimate;
		for (int i=0; i<tagsOfOtherObjectsToAnimate.Length; i++) {
			objectToAnimate = GameObject.FindWithTag(tagsOfOtherObjectsToAnimate[i]);
			if (objectToAnimate) objectToAnimate.animation.Play();
			else Debug.Log("Did not find an object by that tag!");
		}
		for (int i=0; i<objectsToAnimate.Length; i++) {
			objectsToAnimate[i].animation.Play();
		}
	}
}
