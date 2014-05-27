using UnityEngine;
using System.Collections;

public class FlickerDestroyOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetType() == typeof(CircleCollider2D)) StartCoroutine(animateAndDestroy());
	}
	
	IEnumerator animateAndDestroy() {
		animation.Play();
		yield return new WaitForSeconds(2);
		Object.Destroy(this.gameObject);
	}
}
