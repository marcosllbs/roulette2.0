using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RouletteManager : MonoBehaviour
{
    [SerializeField] GameObject rouletteGameObject;
    bool isSpining = false;
    public int angles = 0;
    private float rotationSpeed = 0;


    // Start is called before the first frame update
    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSpining)
        {
            SpinRoulette();
        }
    }
    public void Angles()
    {


    }

    public void RotationSpeed()
    {
        rotationSpeed = Random.Range(100f, 300f) * Time.deltaTime;
    }
    public void SpinRoulette()
    {
        //rouletteGameObject.transform.DORotate(new Vector3(0, 0, Mathf.PingPong(0,360)), rotationDuration, RotateMode.FastBeyond360);
        RotationSpeed();

        isSpining = true;

        rouletteGameObject.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);

        //rouletteGameObject.transform.Rotate()

        Invoke("SpinRouletteStop", Random.Range(0.8f, 1.8f));

    }
    public void SpinRouletteStop()
    {
        angles = (int)(rouletteGameObject.GetComponent<Transform>().localEulerAngles.z)/45;
        isSpining = false;
        Debug.Log($"O angulo e: {angles}");
        rouletteGameObject.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * 0.1f);
    }

    public void SpinRoulletStopCallBack()
    {
        
    }
}
