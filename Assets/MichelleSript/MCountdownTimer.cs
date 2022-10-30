using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MCountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 3;
    }

    void FixedUpdate()
    {
        //Take away from timer at a rate of time
        countdown -= Time.deltaTime;
        //Round the timer to 2 decimal places
        countdown = Mathf.Round(countdown * 100f) / 100f;
        //Display the timer to the screen
        timerText.text = countdown + "";

        //When the timer goes to 0 or below, transition to the gameplay screen
        if (countdown <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
