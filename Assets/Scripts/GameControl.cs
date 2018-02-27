using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public static GameControl instance;

	public GameObject gameOverText;
	public Text scoreText;
    public GameObject startupBackground;
    public Text startupTimerText;
	[HideInInspector] public bool gameOver = false;
	public float scrollSpeed = -1.5f;
    [HideInInspector] public bool gamePaused = false;

	private int score = 0;

	private void Awake () {
		if (!instance) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

	    StartCoroutine(StartTimer());
	}

	private IEnumerator StartTimer() {
		startupBackground.SetActive(true);
	    gamePaused = true;
	    var timer = 3;
	    while (timer > 0)
	    {
	        startupTimerText.text = timer.ToString();
	        timer--;
            yield return new WaitForSeconds(1);
	    }

	    gamePaused = false;
        startupBackground.SetActive(false);
	}
	
	// Update is called once per frame
    private void Update () {
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
