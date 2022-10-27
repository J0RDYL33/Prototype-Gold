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

    public bool[] player1Benefits = new bool[4];
    public int[] player1BenefitsCosts = new int[4];
    public bool[] player2Benefits = new bool[4];
    public int[] player2BenefitsCosts = new int[4];

    public bool[] player1Detriments = new bool[4];
    public int[] player1DetrimentsCosts = new int[4];
    public bool[] player2Detriments = new bool[4];
    public int[] player2DetrimentsCosts = new int[4];

    public bool hasResetFirst;

    //ADD: Detriments
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void End1Round()
    {
        player1SavedGold += player1Score;

        for(int i = 0; i < player1Benefits.Length; i++)
        {
            player1Benefits[i] = false;
        }

        for (int i = 0; i < player1Detriments.Length; i++)
        {
            player1Detriments[i] = false;
        }
    }

    public void End2Round()
    {
        player2SavedGold += player2Score;

        for (int i = 0; i < player2Benefits.Length; i++)
        {
            player2Benefits[i] = false;
        }

        for (int i = 0; i < player2Detriments.Length; i++)
        {
            player2Detriments[i] = false;
        }
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
