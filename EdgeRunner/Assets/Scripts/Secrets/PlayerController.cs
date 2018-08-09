using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidbody_;
    private GameObject shipPrefab;
    private string deathEffect = "FX/PurpleUltimateNova";
    public float speed = 10f;
    public bool dead = false;

	// Use this for initialization
	void Start () {
        rigidbody_ = this.GetComponent<Rigidbody>();
        shipPrefab = this.gameObject.transform.root.Find("ShipPrefab").gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        rigidbody_.velocity = new Vector3(-speed, rigidbody_.velocity.y, 0);

        // Destory ship if we fall too far
        if (this.transform.position.y <= -5f) {
            playerDeath();
        }
    }

    // Destroy ship on collision
    void OnCollisionEnter(Collision collision) {

        if (collision.collider.tag == "obstacle") {
           playerDeath();
        }
    }


    public void playerDeath() {
        dead = true;
        shipPrefab.SetActive(false);
        Instantiate(Resources.Load(deathEffect), this.transform);
        speed = 0f;
        this.GetComponent<PlayerScript>().speed = 0f;
    }

    }
