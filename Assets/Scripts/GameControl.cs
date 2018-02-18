using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public static GameControl instance;

	public GameObject gameOverText;
	public Text scoreText;
	[HideInInspector]
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;

	private int score = 0;

	void Awake () {
		if (!instance) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void BirdScored () {
		if (gameOver) {
			return;
		}
		
		score++;
		scoreText.text = "Score: " + score;
	}

	public void BirdDied () {
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
