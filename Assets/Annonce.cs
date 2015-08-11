﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Annonce : MonoBehaviour {

    public enum AnnonceType
    {
        Aucune_annonce,
        Poignée,
        Double_poignée,
        Triple_poignée,
    }
    public Score ScoreObject;
    public AnnonceType annonce = AnnonceType.Aucune_annonce;
    // Use this for initialization
    void Start()
    {
        Reset();
    }

    void Reset()
    {
        annonce = AnnonceType.Aucune_annonce;
        GetComponentInChildren<Text>().text = annonce.ToString().Replace('_', ' ');
    }

    public void Click()
    {
        annonce = (AnnonceType)(((int)annonce + 1) % Enum.GetNames(typeof(AnnonceType)).Length);
        GetComponentInChildren<Text>().text = annonce.ToString().Replace('_', ' ');
        ScoreObject.Recalculate();
    }
}
