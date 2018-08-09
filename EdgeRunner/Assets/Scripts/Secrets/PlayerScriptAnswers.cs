using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptAnswers : MonoBehaviour {

    public float speed = .25f;

    private float rotationLerp;

    // Update is called once per frame
    void Update() {

        if (Input.GetKey("a")) {
            moveLeft();
            rotateLeft();
        }

        if (Input.GetKey("d")) {
            moveRight();
            rotateRight();
        }

        notMoving();

    }


    void moveLeft() {
        this.gameObject.transform.Translate(Vector3.back * speed);
        return;
    }

    void rotateLeft() {
        rotationLerp = Mathf.Lerp(rotationLerp, -15f, .1f);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationLerp, 0f, 90f));
    }

    void moveRight() {
        this.gameObject.transform.Translate(Vector3.forward * speed);
        return;
    }

    void rotateRight() {
        rotationLerp = Mathf.Lerp(rotationLerp, 15f, .1f);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationLerp, 0f, 90f));
    }

    void notMoving() {
        rotationLerp = Mathf.Lerp(rotationLerp, 0, .1f);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationLerp, 0f, 90f));
    }
}
