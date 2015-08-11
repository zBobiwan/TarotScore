using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Petit : MonoBehaviour {

    public enum PetitType
    {
        Pas_de_petit,
        Petit_au_bout,
    }
    public Score ScoreObject;
    public PetitType annonce = PetitType.Pas_de_petit;
    // Use this for initialization
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        annonce = PetitType.Pas_de_petit;
        GetComponentInChildren<Text>().text = annonce.ToString().Replace('_', ' ');
        GetComponent<Image>().color = Color.white;
    }

    public void Click()
    {
        annonce = (PetitType)(((int)annonce + 1) % Enum.GetNames(typeof(PetitType)).Length);
        GetComponentInChildren<Text>().text = annonce.ToString().Replace('_', ' ');
        GetComponent<Image>().color = annonce == PetitType.Pas_de_petit ? Color.white : Color.yellow;
        ScoreObject.Recalculate();
    }
}
