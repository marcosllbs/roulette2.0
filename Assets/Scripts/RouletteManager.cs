using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;


public class RouletteManager : MonoBehaviour
{
    [SerializeField] GameObject rouletteGameObject;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform transformToInstantiate;
    bool isSpining = false;
    public int angles = 0;
    public int points = 0;
    private float rotationSpeed = 0;

    public List<ButtonBetScript> buttonBetScriptsList = new List<ButtonBetScript>();


    // Start is called before the first frame update
    void Start()

    {
        SetButtonsInstantiate();
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
        RotationSpeed();
        isSpining = true;
        rouletteGameObject.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);

    }
    public void SpinRouletteStop()
    {
        rouletteGameObject.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * 0.1f);
        isSpining = false;
        angles = (int)(rouletteGameObject.GetComponent<Transform>().localEulerAngles.z) / 45;
        Debug.Log($"O angulo e: {angles}");
    }

    public void SetButtonsInstantiate()
    {
        GameObject buttonsInstatiated;
        ButtonBetScript buttonsInstantiatedScript;
        for (int i = 0; i < 8; i++)
        {
            buttonsInstatiated = Instantiate(buttonPrefab, transformToInstantiate);
            buttonsInstantiatedScript = buttonsInstatiated.GetComponent<ButtonBetScript>();
            buttonBetScriptsList.Add(buttonsInstantiatedScript);
            InitializeButtons(buttonBetScriptsList[i].betButton, buttonBetScriptsList[i].betNumber, i);
        }
    }

    public void InitializeButtons(Button button, TMP_Text text, int i)
    {
        button.onClick.AddListener(() => SpinRoulette()); Invoke("SpinRouletteStop", Random.Range(0.5f, 1f));
        text.SetText(i.ToString());
    }

    public void SpinRouletteStopCallBack()
    {
        Invoke("SpinRouletteStop", Random.Range(0.5f, 1f));
    }
}
