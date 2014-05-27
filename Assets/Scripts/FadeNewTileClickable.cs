using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FadeNewTileClickable : Clickable {

	public GameObject currentTile;
	public GameObject[] nextTiles;
	private float fadeSeconds = 1f;
	
	override protected void clickObject() {
		GameObject newTile;
		SpriteRenderer newSprite;
		for (int i=0; i<nextTiles.Length; i++) {
			// create the new tiles, but make sure they are invisible
			newTile = (GameObject) Instantiate(nextTiles[i]);
			Vector3 newTilePos = newTile.transform.position;
			newTilePos.x = currentTile.transform.position.x;
			newTilePos.y = currentTile.transform.position.y;
			newTile.transform.position = newTilePos;
			
			// fade in the new tile ...
			newSprite = newTile.GetComponent<SpriteRenderer>();
			fadeWithChildren(newSprite, 0f, 1f, fadeSeconds);
		}
		// fade out the old tile
		fadeWithChildren(currentTile.GetComponent<SpriteRenderer>(), 1f, 0f, fadeSeconds);
		
		// delete the old tile
		StartCoroutine(DestroyAfterSeconds(currentTile, fadeSeconds));
	}
	
	private void fadeWithChildren(SpriteRenderer objToFade, float startingAlpha, float endingAlpha, float timeToFade) {
		StartCoroutine(fade(objToFade, startingAlpha, endingAlpha, timeToFade));
		SpriteRenderer[] childSprites = objToFade.GetComponentsInChildren<SpriteRenderer>();
		for (int j=0; j<childSprites.Length; j++) {
			StartCoroutine(fade(childSprites[j], startingAlpha, endingAlpha, timeToFade));
		}
	}
	
	private IEnumerator fade(SpriteRenderer objToFade, float startingAlpha, float endingAlpha, float timeToFade) {
		float elapsedTime = 0;
		float changeInAlpha = endingAlpha - startingAlpha;
		float fadeValue = startingAlpha;
		while (elapsedTime <= timeToFade) {
			elapsedTime += Time.deltaTime;
			fadeValue += changeInAlpha * (Time.deltaTime / timeToFade);
			objToFade.color = new Color(1,1,1, fadeValue);
			yield return null;
		}
	}
	
	private IEnumerator DestroyAfterSeconds(GameObject obj, float seconds) {
		yield return new WaitForSeconds(seconds);
		Object.Destroy(obj);
	}
}
