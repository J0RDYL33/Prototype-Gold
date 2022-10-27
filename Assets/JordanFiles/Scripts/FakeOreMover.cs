using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FakeOreMover : MonoBehaviour
{
    public bool player1Turn;
    public ScreenShake rockShaker;
    public ScreenShake cameraShaker;
    public GameObject nuggetParticles;
    public Sprite basicNugget;
    public Sprite rareNugget;

    private SpriteRenderer mySprite;
    private GameObject particleTemp;
    private SavedInfomation savedInfo;
    private Vector2 xBounds;
    private Vector2 yBounds;

    // Start is called before the first frame update
    void Start()
    {
        savedInfo = FindObjectOfType<SavedInfomation>();

        if (player1Turn)
        {
            if(savedInfo.player1Detriments[3] == false)
            {
                Destroy(this.gameObject);
            }
        }
        else if (!player1Turn)
        {
            if (savedInfo.player2Detriments[3] == false)
            {
                Destroy(this.gameObject);
            }
        }
        xBounds.x = -3.1f;
        xBounds.y = 3.2f;
        yBounds.x = 1.1f;
        yBounds.y = -2.6f;

        mySprite = this.GetComponent<SpriteRenderer>();

        //Move nugget detriment
        if (player1Turn == true && savedInfo.player1Detriments[1] == true)
        {
            StartCoroutine(MoveTheNugget1());
        }
        else if (player1Turn == true && savedInfo.player1Detriments[1] == true)
        {
            StartCoroutine(MoveTheNugget2());
        }

        //Bigger Gold Nugget Benefit
        if (player1Turn == true && savedInfo.player1Benefits[0] == true)
        {
            Debug.Log("Making Bigger!");
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * 1.5f, this.gameObject.transform.localScale.y * 1.5f);
        }
        else if (player1Turn == false && savedInfo.player2Benefits[0] == true)
        {
            Debug.Log("Making Bigger!");
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * 1.5f, this.gameObject.transform.localScale.y * 1.5f);
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
    }

    IEnumerator MoveTheNugget1()
    {
        while (savedInfo.player1Detriments[1] == true)
        {
            yield return new WaitForSeconds(1.5f);
            MoveFaker();
        }
    }

    IEnumerator MoveTheNugget2()
    {
        while (savedInfo.player2Detriments[1] == true)
        {
            yield return new WaitForSeconds(1.5f);
            MoveFaker();
        }
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

        //Decide if the next nugget will be a rare one
        if (player1Turn)
        {
            if (savedInfo.player1Benefits[2])
            {
                int decideRare = Random.Range(0, 5);
                if (decideRare == 0)
                {
                    mySprite.sprite = rareNugget;
                }
                else
                {
                    mySprite.sprite = basicNugget;
                }
            }
        }

        //Move the nugget
        float newX = Random.Range(xBounds.y, xBounds.x + 0.1f);
        float newy = Random.Range(yBounds.y, yBounds.x + 0.1f);
        this.gameObject.transform.position = new Vector2(newX, newy);
    }

    public void MoveFaker()
    {
        //Move the nugget
        float newX = Random.Range(xBounds.y, xBounds.x + 0.1f);
        float newy = Random.Range(yBounds.y, yBounds.x + 0.1f);
        this.gameObject.transform.position = new Vector2(newX, newy);
    }
}
