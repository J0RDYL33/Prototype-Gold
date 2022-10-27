using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private SavedInfomation myinfo;

    private void Start()
    {
        myinfo = FindObjectOfType<SavedInfomation>();
    }

    // Start is called before the first frame update
    public void ContinueToScores ()
    {
        if(myinfo.hasResetFirst == false)
        {
            myinfo.player1SavedGold = 0;
            myinfo.hasResetFirst = true;
        }    

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
