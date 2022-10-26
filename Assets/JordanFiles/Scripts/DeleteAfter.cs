using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteCorout());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeleteCorout()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
