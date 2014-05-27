using UnityEngine;
using System.Collections;

public class DestoryOnClick : Clickable {

	public GameObject destroyOnClick;

	override protected void clickObject() {
		Object.Destroy(destroyOnClick);
	}
}
