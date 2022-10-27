using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public OreMover myMover;

    private float timer;
    private float howMuchToAdd;
    private SavedInfomation myInfo;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15;
        timer += howMuchToAdd;
        myInfo = FindObjectOfType<SavedInfomation>();
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
        if (SceneManager.GetActiveScene().buildIndex == 6)
            SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void AddToTime(float timeToAdd)
    {
        howMuchToAdd = timeToAdd;
        Debug.Log("Timer is now " + timer);
    }
}
