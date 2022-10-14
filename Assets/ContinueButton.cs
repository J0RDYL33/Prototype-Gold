using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ContinueToScores ()
    {
        global::System.Object value = SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
