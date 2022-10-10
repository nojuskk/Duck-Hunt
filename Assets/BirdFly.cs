using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {

    public Rigidbody2D rb2d;

    public float speed = 2f;

	// Update is called once per frame
	void Update () {
        rb2d.velocity = Vector2.right * speed;
	}
}
