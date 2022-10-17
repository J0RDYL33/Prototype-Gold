using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfomation : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public int player1SavedGold;
    public int player2SavedGold;
    public int player1Lives;
    public int player2Lives;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void End1Round(int roundScore)
    {
        player1Score = roundScore;
        player1SavedGold += roundScore;
    }

    public void End2Round(int roundScore)
    {
        player2Score = roundScore;
        player2SavedGold += roundScore;
    }

    public int DecideWhoWins()
    {
        //Returns 0 if player 1 wins
        if (player1Score > player2Score)
            return 0;
        //Returns 1 if player 2 wins
        else if (player1Score < player2Score)
            return 1;
        //Returns 2 if its a draw
        else
            return 2;
    }
}