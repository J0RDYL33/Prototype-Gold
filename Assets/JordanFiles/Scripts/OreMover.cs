using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OreMover : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public bool player1Turn;
    public ScreenShake rockShaker;
    public ScreenShake cameraShaker;
    public GameObject nuggetParticles;

    private GameObject particleTemp;
    private SavedInfomation savedInfo;
    private Vector2 xBounds;
    private Vector2 yBounds;
    // Start is called before the first frame update
    void Start()
    {
        xBounds.x = -3.1f;
        xBounds.y = 3.2f;
        yBounds.x = 1.1f;
        yBounds.y = -2.6f;

        savedInfo = FindObjectOfType<SavedInfomation>();

        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Transform currentPos = this.gameObject.transform;
        //Spawn a particle system when the nugget is clicked
        particleTemp = Instantiate(nuggetParticles, currentPos);
        particleTemp.transform.parent = null;
        //Shake the camera and rock when the nugget is clicked
        cameraShaker.ShakeCamera(0.1f);
        rockShaker.ShakeCamera(0.1f);

        //Increase the score by 1 when the nugget is clicked
        playerScore++;

        //Edit the score displayed on screen
        UpdateScore();

        //Move the nugget
        float newX = Random.Range(xBounds.y, xBounds.x + 0.1f);
        float newy = Random.Range(yBounds.y, yBounds.x + 0.1f);
        this.gameObject.transform.position = new Vector2(newX, newy);
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void UpdateSavedInfo()
    {
        if(player1Turn)
        {
            savedInfo.End1Round(playerScore);
        }
        else
        {
            savedInfo.End2Round(playerScore);
        }
    }
}
