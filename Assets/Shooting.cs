using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour {

    public Text scoreText;
    private int Score = 0;

    public Text timerText;
    public float timeLimit = 10f;
    private float currentTimeLeft;

    public GameObject gameEndPanel;
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        
        Time.timeScale = 1f;
        currentTimeLeft = timeLimit;
    }
	// Update is called once per frame
	void Update () {

        

        currentTimeLeft -= Time.deltaTime;
        if(currentTimeLeft <= 0)
        {
            gameEndPanel.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseMethod();
        }

        if (isPaused)
            return;

        timerText.text = "Time : " + ((int)currentTimeLeft).ToString();

        scoreText.text = "Score : " + Score.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousPos, Vector3.forward, 20f);

            if(hit.collider != null)
            {
                hit.rigidbody.gravityScale = 3f;
                hit.transform.GetComponent<Animator>().enabled = false;
                hit.transform.GetComponent<BirdFly>().enabled = false;
                Score++;
            }

        }
	}

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    private void PauseMethod()
    {
        if(isPaused == true)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            
        }
        else
        {
            Resume();
        }
    }
}
