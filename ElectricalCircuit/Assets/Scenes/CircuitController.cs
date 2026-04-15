using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircuitController : MonoBehaviour
{
    //game components
    //UI components
    [Header("UI References")]
    public Button switch1Button;
    public Button switch2Button;
    public SpriteRenderer bulbImage;
    public TextMeshProUGUI statusText;

    //colors
    [Header("Colors")]
    public Color bulbOnColor = Color.yellow;
    public Color bulbOffColor = Color.gray;

    //switch states
    private bool switch1On = false;
    private bool switch2On = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCircuit();
    }

    // called from Button 1 OnClick event
    public void ToggleSwitch1()
    {
        switch1On = !switch1On;
        UpdateCircuit();
    }
    // called from Button 2 OnClick event
    public void ToggleSwitch2()
    {
        switch2On = !switch2On;
        UpdateCircuit();
    }
    //evaluate current circuit state and update visuals
    private void UpdateCircuit()
    {
        //Define complete circuit
        bool circuitComplete = switch1On && switch2On;
        //update bulb color
        bulbImage.color = circuitComplete ? bulbOnColor : bulbOffColor;
        //update status text
        if (circuitComplete) 
        {
            statusText.text = "Circuit Complete!";
            statusText.color = Color.green;
        }
        else
        {
            statusText.text = "Circuit Open";
            statusText.color = Color.red;
        }
        //update button labels
        switch1Button.GetComponentInChildren<TextMeshProUGUI>().text =
            "Switch 1: " + (switch1On ? "ON" : "OFF");
        switch2Button.GetComponentInChildren<TextMeshProUGUI>().text =
            "Switch 2: " + (switch2On ? "ON" : "OFF");
    }
}
