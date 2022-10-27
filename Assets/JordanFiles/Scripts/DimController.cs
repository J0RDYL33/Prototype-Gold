using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimController : MonoBehaviour
{
    public GameObject dimCanvas;
    public OreMover mainMover;

    private SavedInfomation myInfo;
    // Start is called before the first frame update
    void Start()
    {
        myInfo = FindObjectOfType<SavedInfomation>();

        if(mainMover.player1Turn == true && myInfo.player1Detriments[0] == false)
        {
            dimCanvas.SetActive(false);
        }
        else if (mainMover.player1Turn == false && myInfo.player2Detriments[0] == false)
        {
            dimCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
