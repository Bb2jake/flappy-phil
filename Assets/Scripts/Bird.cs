using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;

    private void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

    private void Update () {
		if (isDead) {
			return;
		}

	    if (GameControl.instance.gamePaused)
	    {
	        if (rb2d.simulated)
	            rb2d.simulated = false;
	        return;
	    } else if (!rb2d.simulated)
	        rb2d.simulated = true;

		if (Input.GetMouseButtonDown (0)) {
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (new Vector2 (0, upForce));
			anim.SetTrigger ("Flap");
		}
	}

    private void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Sky") {
			return;
		}
		
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}
