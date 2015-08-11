﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Prise : MonoBehaviour 
{
    public enum PriseType
    {
        Defense,
        Partenaire,
        Petite,
        Garde,
        Garde_Sans,
        Garde_Contre,
    }
    public Score ScoreObject;
    public PriseType priseType = PriseType.Defense;
	// Use this for initialization
	void Start () 
    {
        GetComponentInChildren<Text>().text = priseType.ToString().Replace('_', ' ');
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click()
    {
        priseType = (PriseType)(((int)priseType + 1) % Enum.GetNames(typeof(PriseType)).Length);
        GetComponentInChildren<Text>().text = priseType.ToString();
    }
}
