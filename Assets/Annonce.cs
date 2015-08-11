using UnityEngine;
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

    public void Reset()
    {
        annonce = AnnonceType.Aucune_annonce;
        GetComponentInChildren<Text>().text = annonce.ToString().Replace('_', ' ');
        GetComponent<Image>().color  = Color.white;
    }

    public void Click()
    {
        annonce = (AnnonceType)(((int)annonce + 1) % Enum.GetNames(typeof(AnnonceType)).Length);
        GetComponentInChildren<Text>().text = annonce.ToString().Replace('_', ' ');
        GetComponent<Image>().color = annonce == AnnonceType.Aucune_annonce ? Color.white : Color.yellow;
        ScoreObject.Recalculate();
    }
}
