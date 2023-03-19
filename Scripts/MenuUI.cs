using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;
using UnityEngine.UI;
public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button OK_Button;
    [SerializeField] private InputField SH_Input;
    [SerializeField] private InputField Distance_Input;
    [Header("Info")]
    [SerializeField] private Text text_1;
    [SerializeField] private Text text_2;

    private void Start()
    {
        OK_Button.onClick.AddListener(InputInfo);
    }

    private void InputInfo()
    {
        text_1.text = "Distance:" + Distance_Input.text;
        text_2.text = "SH: " + SH_Input.text;

        Distance_Input.text = "";
        SH_Input.text = "";
    }
    
}
