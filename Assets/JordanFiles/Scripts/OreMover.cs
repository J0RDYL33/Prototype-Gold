using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OreMover : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public bool player1Turn;
    public ScreenShake rockShaker;
    public ScreenShake cameraShaker;
    public GameObject nuggetParticles;
    public GameObject dupeNugget;
    public bool isDupe;
    public Sprite basicNugget;
    public Sprite rareNugget;
    public FakeOreMover fakeNugget;

    private Timer myTimer;
    private SpriteRenderer mySprite;
    private bool isRareNugget;
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
        mySprite = this.GetComponent<SpriteRenderer>();
        myTimer = FindObjectOfType<Timer>();

        UpdateScore();

        //Reset score in savedInfo
        if (player1Turn)
            savedInfo.player1Score = 0;
        else
            savedInfo.player2Score = 0;

        //Bigger Gold Nugget Benefit
        if(player1Turn == true && savedInfo.player1Benefits[0] == true)
        {
            Debug.Log("Making Bigger!");
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * 1.5f, this.gameObject.transform.localScale.y * 1.5f);
        }
        else if (player1Turn == false && savedInfo.player2Benefits[0] == true)
        {
            Debug.Log("Making Bigger!");
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * 1.5f, this.gameObject.transform.localScale.y * 1.5f);
        }

        //Double gold nugget Benefit
        if (player1Turn == true && savedInfo.player1Benefits[1] == false)
        {
            Debug.Log("destroy dupe!");
            Destroy(dupeNugget);
        }
        else if (player1Turn == false && savedInfo.player2Benefits[1] == false)
        {
            Debug.Log("destroy dupe!");
            Destroy(dupeNugget);
        }

        //Add to timer benefit
        if (player1Turn == true && savedInfo.player1Benefits[3] == true && isDupe == false)
        {
            Debug.Log("Adding Time!");
            myTimer.AddToTime(3.0f);
        }
        else if (player1Turn == false && savedInfo.player2Benefits[3] == true && isDupe == false)
        {
            Debug.Log("Adding Time!");
            myTimer.AddToTime(3.0f);
        }

        //Shrink nugget detriment
        if (player1Turn == true && savedInfo.player1Detriments[2] == true)
        {
            Debug.Log("Making Smaller!");
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x / 1.5f, this.gameObject.transform.localScale.y / 1.5f);
        }
        else if (player1Turn == false && savedInfo.player2Detriments[2] == true)
        {
            Debug.Log("Making Smaller!");
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x / 1.5f, this.gameObject.transform.localScale.y / 1.5f);
        }

        //Move nugget detriment
        if(player1Turn == true && savedInfo.player1Detriments[1] == true)
        {
            StartCoroutine(MoveTheNugget1());
        }
        else if (player1Turn == true && savedInfo.player1Detriments[1] == true)
        {
            StartCoroutine(MoveTheNugget2());
        }
    }

    IEnumerator MoveTheNugget1()
    {
        while (savedInfo.player1Detriments[1] == true)
        {
            yield return new WaitForSeconds(1.5f);
            MoveNug();
        }
    }

    IEnumerator MoveTheNugget2()
    {
        while (savedInfo.player2Detriments[1] == true)
        {
            yield return new WaitForSeconds(1.5f);
            MoveNug();
        }
    }

    public void MoveNug()
    {
        //Move the nugget
        float newX = Random.Range(xBounds.y, xBounds.x + 0.1f);
        float newy = Random.Range(yBounds.y, yBounds.x + 0.1f);
        this.gameObject.transform.position = new Vector2(newX, newy);
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
        if(player1Turn)
        {
            savedInfo.player1Score++;
        }
        else
        {
            savedInfo.player2Score++;
        }

        //If the nugget clicked is a rare one, add an extra point
        if (isRareNugget)
        {
            if (player1Turn)
            {
                savedInfo.player1Score++;
            }
            else
            {
                savedInfo.player2Score++;
            }
        }

        //Decide if the next nugget will be a rare one & move fake nugget if enabled
        if(player1Turn)
        {
            if(savedInfo.player1Benefits[2])
            {
                int decideRare = Random.Range(0, 5);
                if (decideRare == 0)
                {
                    mySprite.sprite = rareNugget;
                    isRareNugget = true;
                }
                else
                {
                    mySprite.sprite = basicNugget;
                    isRareNugget = false;
                }
            }

            if(savedInfo.player1Detriments[3])
            {
                fakeNugget.MoveFaker();
            }
        }
        else if (!player1Turn)
        {
            if (savedInfo.player2Benefits[2])
            {
                int decideRare = Random.Range(0, 5);
                if (decideRare == 0)
                {
                    mySprite.sprite = rareNugget;
                    isRareNugget = true;
                }
                else
                {
                    mySprite.sprite = basicNugget;
                    isRareNugget = false;
                }
            }

            if (savedInfo.player2Detriments[3])
            {
                fakeNugget.MoveFaker();
            }
        }



        //Edit the score displayed on screen
        UpdateScore();

        //Move the nugget
        float newX = Random.Range(xBounds.y, xBounds.x + 0.1f);
        float newy = Random.Range(yBounds.y, yBounds.x + 0.1f);
        this.gameObject.transform.position = new Vector2(newX, newy);
    }

    private void UpdateScore()
    {
        if(player1Turn)
            scoreText.text = "Score: " + savedInfo.player1Score;
        else
            scoreText.text = "Score: " + savedInfo.player2Score;
    }

    public void UpdateSavedInfo()
    {
        if (!isDupe)
        {
            if(SceneManager.GetActiveScene().buildIndex == 2 && savedInfo.player1Score > 5)
            {
                savedInfo.player1Score -= 5;
            }

            if (player1Turn)
            {
                savedInfo.End1Round();
            }
            else
            {
                savedInfo.End2Round();
            }
        }
    }
}
