using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerScript : MonoBehaviour {
	private GameObject lastUnitPlaced;

	void Start () {
		lastUnitPlaced = GameObject.Find ("StageUnit5");
	}


	private void OnTriggerEnter (Collider other) {
		//Debug.Log ("Collision!");
        //
        // Translate the collided unit to the end of the last unit placed
        //
        if (other.tag == "stageBlock") {
            other.gameObject.transform.position = new Vector3(lastUnitPlaced.transform.position.x - lastUnitPlaced.transform.lossyScale.x, -1f, 0);

            other.GetComponent<StageUnitScript>().setupBlocks();

            lastUnitPlaced = other.gameObject;
        }
	}
}
