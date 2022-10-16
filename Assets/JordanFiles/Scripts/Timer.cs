using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timer;
    private OreMover myMover;
    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
        myMover = FindObjectOfType<OreMover>();
    }

    void FixedUpdate()
    {
        //Take away from timer at a rate of time
        timer -= Time.deltaTime;
        //Round the timer to 2 decimal places
        timer = Mathf.Round(timer * 100f) / 100f;
        //Display the timer to the screen
        timerText.text = timer + "";

        //When the timer goes to 0 or below, transition to the buy screen
        if (timer <= 0)
            SceneTransition();
    }

    private void SceneTransition()
    {
        myMover.UpdateSavedInfo();
        //Load next scene in the index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
