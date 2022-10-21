using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackToMenu : MonoBehaviour
{
    public TextMeshProUGUI winText;
    private SavedInfomation myInfo;
    // Start is called before the first frame update
    void Start()
    {
        myInfo = FindObjectOfType<SavedInfomation>();

        if (myInfo.player1Lives > 0)
            winText.text = "Player 1 Wins!";
        else if (myInfo.player2Lives > 0)
            winText.text = "Player 2 Wins!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        Destroy(myInfo.gameObject);
        SceneManager.LoadScene(0);
    }
}
