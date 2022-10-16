using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float zCoord;

    private float shakeAmount = 0.15f;
    private float shakeTimer;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            this.gameObject.transform.localPosition = Random.insideUnitCircle * shakeAmount;
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, zCoord);
            shakeTimer -= Time.deltaTime;
        }
        if (shakeTimer <= 0 && this.gameObject.transform.localPosition.x != 0)
            this.gameObject.transform.localPosition = startPosition;
    }

    public void ShakeCamera(float shake)
    {
        shakeTimer = shake;
    }
}
