using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RouletteManager : MonoBehaviour
{
    [SerializeField] GameObject rouletteGameObject;
    bool isSpining = false;


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
    public void SpinRoulette()
    {
        //rouletteGameObject.transform.DORotate(new Vector3(0, 0, Mathf.PingPong(0,360)), rotationDuration, RotateMode.FastBeyond360);
        float angles = rouletteGameObject.GetComponent<Transform>().localEulerAngles.z;
        isSpining = true;

        rouletteGameObject.transform.DORotate(new Vector3(0, 0, 45), 45f);

    }
}
