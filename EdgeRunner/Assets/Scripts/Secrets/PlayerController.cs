using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidbody_;

	// Use this for initialization
	void Start () {
        rigidbody_ = this.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        rigidbody_.velocity = new Vector3(-10f, 0, 0);

    }
}
