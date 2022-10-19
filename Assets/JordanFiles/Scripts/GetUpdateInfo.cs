using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetUpdateInfo : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private SavedInfomation myInfo;
    // Start is called before the first frame update
    void Start()
    {
        myInfo = FindObjectOfType<SavedInfomation>();

        UpdateGoldText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGoldText()
    {
        goldText.text = "Total Gold: " + myInfo.player1SavedGold;
    }
}
