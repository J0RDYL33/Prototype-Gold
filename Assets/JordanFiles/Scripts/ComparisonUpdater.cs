using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ComparisonUpdater : MonoBehaviour
{
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Score;
    public TextMeshProUGUI player1Lives;
    public TextMeshProUGUI player2Lives;
    public TextMeshProUGUI player1Total;
    public TextMeshProUGUI player2Total;
    private SavedInfomation myInfo;
    // Start is called before the first frame update
    void Start()
    {
        myInfo = FindObjectOfType<SavedInfomation>();

        player1Score.text = myInfo.player1Score + "";
        player2Score.text = myInfo.player2Score + "";

        if (myInfo.player1Score > myInfo.player2Score)
            myInfo.player2Lives--;
        else if (myInfo.player1Score < myInfo.player2Score)
            myInfo.player1Lives--;

        player1Lives.text = "Lives Left: " + myInfo.player1Lives;
        player2Lives.text = "Lives Left: " + myInfo.player2Lives;

        player1Total.text = "Total Gold: " + myInfo.player1SavedGold;
        player2Total.text = "Total Gold: " + myInfo.player2SavedGold;
    }

    public void ChooseNextScene()
    {
        if(myInfo.player1Lives == 0 || myInfo.player2Lives == 0)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
