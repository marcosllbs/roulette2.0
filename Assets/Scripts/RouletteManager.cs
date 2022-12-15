using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class RouletteManager : MonoBehaviour
{
    [SerializeField] GameObject rouletteGameObject;
    [SerializeField] ButtonBetScript buttonPrefab;
    [SerializeField] Transform transformToInstantiate;
    [SerializeField] TMP_Text pointsDisplay;
    public float spinVelocity = 0.0f;
    public int angles = 1;
    public int points = 0;

    public List<ButtonBetScript> buttonBetScriptsList = new List<ButtonBetScript>();
    public ButtonBetScript clickedButton;

    // Start is called before the first frame update
    void Start()

    {
        SetButtonsInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        if (spinVelocity > 0)
        {
            SpinRoulette();
        }
        
    }
    public void StartSpin()
    {
        if (spinVelocity > 0)
            return;
        spinVelocity = Random.Range(250f,500f);
    }

    public void SpinRoulette()
    {
        rouletteGameObject.transform.Rotate(Vector3.forward, spinVelocity * Time.deltaTime);
        spinVelocity -= 100f * Time.deltaTime;
        if (spinVelocity <= 0)
        {
            angles = (int)((rouletteGameObject.GetComponent<Transform>().localEulerAngles.z) / 45) + 1;
            Debug.Log($"O angulo e: {angles}");
            
            if (angles == clickedButton.numberChoice)
            {
                points += 50;
                pointsDisplay.SetText(points.ToString());
            }
            else
            {
                points -= 10;
                pointsDisplay.SetText(points.ToString());
                Debug.Log(clickedButton.numberChoice);
            }
        }
        angles = 0;
    }

    public void SetButtonsInstantiate()
    {
        GameObject buttonsInstatiated;
        ButtonBetScript buttonsInstantiatedScript;
        
        
        for (int i = 0; i < 8; i++)
        {
            buttonsInstatiated = Instantiate(buttonPrefab.gameObject, transformToInstantiate);
            buttonsInstantiatedScript = buttonsInstatiated.GetComponent<ButtonBetScript>();
            buttonBetScriptsList.Add(buttonsInstantiatedScript);
            InitializeButtons(buttonsInstantiatedScript.betButton, buttonsInstantiatedScript.betNumber, i);
            buttonsInstantiatedScript.numberChoice = (i+1);
            Debug.Log($"O numberChoice e: {i + 1}");
        }
    }

    public int LastHope(int i)
    {
       
        return i;
    }


    public void InitializeButtons(Button button, TMP_Text text, int i)
    {
        button.onClick.AddListener(() => { StartSpin(); clickedButton = buttonBetScriptsList[i]; });
        text.SetText((i+1).ToString());
    }

}
