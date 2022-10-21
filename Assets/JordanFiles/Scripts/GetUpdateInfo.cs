using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GetUpdateInfo : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private SavedInfomation myInfo;
    // Start is called before the first frame update
    void Start()
    {
        myInfo = FindObjectOfType<SavedInfomation>();
        if(SceneManager.GetActiveScene().buildIndex == 2)
            UpdateGoldText();
        else if(SceneManager.GetActiveScene().buildIndex == 5)
            UpdateGoldText2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGoldText()
    {
        goldText.text = "Total Gold: " + myInfo.player1SavedGold;
    }

    public void UpdateGoldText2()
    {
        goldText.text = "Total Gold: " + myInfo.player2SavedGold;
    }
}
