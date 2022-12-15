using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonBetScript : MonoBehaviour
{
    public TMP_Text betNumber;
    public Button betButton;
    public int numberChoice;

    public int ReturnValue()
    {
        return numberChoice;
    }

}
