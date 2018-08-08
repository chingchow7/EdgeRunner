using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = .25f;

    private float rotationLerp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a")) {
            rotationLerp = Mathf.Lerp(rotationLerp, -15f, .1f);
            this.gameObject.transform.Translate(Vector3.back * speed);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationLerp, 0f, 90f));
            return;
        }

        if (Input.GetKey("d")) {
            rotationLerp = Mathf.Lerp(rotationLerp, 15f, .1f);
            this.gameObject.transform.Translate(Vector3.forward * speed);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationLerp, 0f, 90f));
            return;
        }
        rotationLerp = Mathf.Lerp(rotationLerp, 0, .1f);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationLerp, 0f, 90f));
    }
}
