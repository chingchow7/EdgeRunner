using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerScript : MonoBehaviour {
	private GameObject lastUnitPlaced;

	void Start () {
		lastUnitPlaced = GameObject.Find ("StageUnit3");
	}


	private void OnTriggerEnter (Collider other) {
		Debug.Log ("Collision!");
		//
		// Translate the collided unit to the end of the last unit placed
		//
		other.gameObject.transform.position = new Vector3 (lastUnitPlaced.transform.position.x - lastUnitPlaced.transform.lossyScale.x, lastUnitPlaced.transform.position.y, lastUnitPlaced.transform.position.z);

		other.GetComponent<StageUnitScript> ().setupBlocks ();

		lastUnitPlaced = other.gameObject;
	}
}
