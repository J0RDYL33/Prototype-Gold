using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Purchasing : MonoBehaviour
{
    public bool player1Turn;
    public TextMeshProUGUI totalText;
    public GameObject[] benCards;
    public GameObject[] detCards;
    public TextMeshProUGUI[] costTexts = new TextMeshProUGUI[8];
    public Image[] buttons;

    private SavedInfomation myInfo;

    private bool[] bought = new bool[8];

    private Vector2 slot1Pos;
    private Vector2 slot2Pos;
    private Vector2 slot3Pos;
    private Vector2 slot4Pos;

    // Start is called before the first frame update
    void Start()
    {
        myInfo = FindObjectOfType<SavedInfomation>();

        slot1Pos = new Vector2(-323, -36);
        slot2Pos = new Vector2(-111, -36);
        slot3Pos = new Vector2(111, -36);
        slot4Pos = new Vector2(323, -36);

        UpdatePrices();
        UpdateCostColors();
        StockShop();
        //ADD: Get cost of each one from myInfo and update the text with it
        //ADD: Rest of options
        //ADD: Randomly select 2 of each to move into frame, 0-3, save the first rand int, if second one is the same, + 1 and modulo it by 4 to not get same one
    }

    //Decide what the shop sells
    private void StockShop()
    {
        int firstBen = Random.Range(0, 4);
        int secondBen = Random.Range(0, 4);

        if(firstBen == secondBen)
        {
            secondBen++;
            secondBen = secondBen % 4;
        }

        benCards[firstBen].transform.localPosition = slot1Pos;
        benCards[secondBen].transform.localPosition = slot2Pos;

        int firstDet = Random.Range(0, 4);
        int secondDet = Random.Range(0, 4);

        if (firstDet == secondDet)
        {
            secondDet++;
            secondDet = secondDet % 4;
        }

        detCards[firstDet].transform.localPosition = slot3Pos;
        detCards[secondDet].transform.localPosition = slot4Pos;
    }

    private void UpdatePrices()
    {
        if (player1Turn == true)
        {
            for (int i = 0; i < 4; i++)
            {
                costTexts[i].text = "Cost: " + myInfo.player1BenefitsCosts[i] + " Gold";
            }

            for (int i = 4; i < 8; i++)
            {
                costTexts[i].text = "Cost: " + myInfo.player1DetrimentsCosts[i-4] + " Gold";
            }
        }
        else if (player1Turn == false)
        {
            for (int i = 0; i < 4; i++)
            {
                costTexts[i].text = "Cost: " + myInfo.player2BenefitsCosts[i] + " Gold";
            }

            for (int i = 4; i < 8; i++)
            {
                costTexts[i].text = "Cost: " + myInfo.player2DetrimentsCosts[i-4] + " Gold";
            }
        }
    }

    private void UpdateCostColors()
    {
        //Benefits costs
        if (player1Turn)
        {
            for (int i = 0; i < 4; i++)
            {
                if (myInfo.player1BenefitsCosts[i] <= myInfo.player1SavedGold)
                    costTexts[i].color = Color.green;
                else
                    costTexts[i].color = Color.red;
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (myInfo.player2BenefitsCosts[i] <= myInfo.player2SavedGold)
                    costTexts[i].color = Color.green;
                else
                    costTexts[i].color = Color.red;
            }
        }

        //Detriments costs
        if (player1Turn)
        {
            for (int i = 4; i < 8; i++)
            {
                if (myInfo.player1DetrimentsCosts[i - 4] <= myInfo.player1SavedGold)
                    costTexts[i].color = Color.green;
                else
                    costTexts[i].color = Color.red;
            }
        }
        else
        {
            for (int i = 4; i < 8; i++)
            {
                if (myInfo.player2DetrimentsCosts[i-4] <= myInfo.player2SavedGold)
                    costTexts[i].color = Color.green;
                else
                    costTexts[i].color = Color.red;
            }
        }
    }

    public void MakeButtonGreen(int buttonInt)
    {
        buttons[buttonInt].color = Color.green;
    }

    public void GoldBigger()
    {
        if(player1Turn == true && bought[0] == false)
        {
            if(myInfo.player1SavedGold >= myInfo.player1BenefitsCosts[0])
            {
                myInfo.player1Benefits[0] = true;
                myInfo.player1SavedGold -= myInfo.player1BenefitsCosts[0];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[0] = true;
                UpdateCostColors();
                MakeButtonGreen(0);
            }
        }
        else if (player1Turn == false && bought[0] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2BenefitsCosts[0])
            {
                myInfo.player2Benefits[0] = true;
                myInfo.player2SavedGold -= myInfo.player2BenefitsCosts[0];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[0] = true;
                UpdateCostColors();
                MakeButtonGreen(0);
            }
        }
    }

    public void DoubleGoldPatches()
    {
        if (player1Turn == true && bought[1] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1BenefitsCosts[1])
            {
                myInfo.player1Benefits[1] = true;
                myInfo.player1SavedGold -= myInfo.player1BenefitsCosts[1];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[1] = true;
                UpdateCostColors();
                MakeButtonGreen(1);
            }
        }
        else if (player1Turn == false && bought[1] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2BenefitsCosts[1])
            {
                myInfo.player2Benefits[1] = true;
                myInfo.player2SavedGold -= myInfo.player2BenefitsCosts[1];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[1] = true;
                UpdateCostColors();
                MakeButtonGreen(1);
            }
        }
    }

    public void DoublePointPatch()
    {
        if (player1Turn == true && bought[2] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1BenefitsCosts[2])
            {
                myInfo.player1Benefits[2] = true;
                myInfo.player1SavedGold -= myInfo.player1BenefitsCosts[2];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[2] = true;
                UpdateCostColors();
                MakeButtonGreen(2);
            }
        }
        else if (player1Turn == false && bought[2] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2BenefitsCosts[2])
            {
                myInfo.player2Benefits[2] = true;
                myInfo.player2SavedGold -= myInfo.player2BenefitsCosts[2];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[2] = true;
                UpdateCostColors();
                MakeButtonGreen(2);
            }
        }
    }

    public void ExtraTime()
    {
        if (player1Turn == true && bought[3] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1BenefitsCosts[3])
            {
                myInfo.player1Benefits[3] = true;
                myInfo.player1SavedGold -= myInfo.player1BenefitsCosts[3];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[3] = true;
                UpdateCostColors();
                MakeButtonGreen(3);
            }
        }
        else if (player1Turn == false && bought[3] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2BenefitsCosts[3])
            {
                myInfo.player2Benefits[3] = true;
                myInfo.player2SavedGold -= myInfo.player2BenefitsCosts[3];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[3] = true;
                UpdateCostColors();
                MakeButtonGreen(3);
            }
        }
    }

    public void DimScreen()
    {
        if (player1Turn == true && bought[4] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1DetrimentsCosts[0])
            {
                myInfo.player2Detriments[0] = true;
                myInfo.player1SavedGold -= myInfo.player1DetrimentsCosts[0];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[4] = true;
                UpdateCostColors();
                MakeButtonGreen(4);
            }
        }
        else if (player1Turn == false && bought[4] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2DetrimentsCosts[0])
            {
                myInfo.player1Detriments[0] = true;
                myInfo.player2SavedGold -= myInfo.player2DetrimentsCosts[0];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[5] = true;
                UpdateCostColors();
                MakeButtonGreen(4);
            }
        }
    }

    public void MoveGold()
    {
        if (player1Turn == true && bought[5] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1DetrimentsCosts[1])
            {
                myInfo.player2Detriments[1] = true;
                myInfo.player1SavedGold -= myInfo.player1DetrimentsCosts[1];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[5] = true;
                UpdateCostColors();
                MakeButtonGreen(5);
            }
        }
        else if (player1Turn == false && bought[5] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2DetrimentsCosts[1])
            {
                myInfo.player1Detriments[1] = true;
                myInfo.player2SavedGold -= myInfo.player2DetrimentsCosts[1];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[5] = true;
                UpdateCostColors();
                MakeButtonGreen(5);
            }
        }
    }

    public void ShrinkPatch()
    {
        if (player1Turn == true && bought[6] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1DetrimentsCosts[2])
            {
                myInfo.player2Detriments[2] = true;
                myInfo.player1SavedGold -= myInfo.player1DetrimentsCosts[2];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[6] = true;
                UpdateCostColors();
                MakeButtonGreen(6);
            }
        }
        else if (player1Turn == false && bought[6] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2DetrimentsCosts[2])
            {
                myInfo.player1Detriments[2] = true;
                myInfo.player2SavedGold -= myInfo.player2DetrimentsCosts[2];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[6] = true;
                UpdateCostColors();
                MakeButtonGreen(6);
            }
        }
    }

    public void FakePatch()
    {
        if (player1Turn == true && bought[7] == false)
        {
            if (myInfo.player1SavedGold >= myInfo.player1DetrimentsCosts[3])
            {
                myInfo.player2Detriments[3] = true;
                myInfo.player1SavedGold -= myInfo.player1DetrimentsCosts[3];
                totalText.text = "Total Gold: " + myInfo.player1SavedGold;
                bought[7] = true;
                UpdateCostColors();
                MakeButtonGreen(7);
            }
        }
        else if (player1Turn == false && bought[7] == false)
        {
            if (myInfo.player2SavedGold >= myInfo.player2DetrimentsCosts[3])
            {
                myInfo.player1Detriments[3] = true;
                myInfo.player2SavedGold -= myInfo.player2DetrimentsCosts[3];
                totalText.text = "Total Gold: " + myInfo.player2SavedGold;
                bought[7] = true;
                UpdateCostColors();
                MakeButtonGreen(7);
            }
        }
    }
}
