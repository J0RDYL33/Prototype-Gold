using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetParticleController : MonoBehaviour
{
    private ParticleSystem myParticles;
    // Start is called before the first frame update
    void Start()
    {
        myParticles = this.gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(StartStopParticles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartStopParticles()
    {
        yield return new WaitForSeconds(0.25f);
        myParticles.Stop();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
