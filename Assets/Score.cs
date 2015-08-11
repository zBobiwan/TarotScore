using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public List<Text> SubScore;
    public List<Text> TotalScore;
    public InputField Oudler;
    public InputField Points;
    public List<Prise> Prises;
    public List<Annonce> Annonces;
    public List<Petit> Petits;

	// Use this for initialization
	void Start () 
    {
        foreach (Prise p in Prises)
            p.ScoreObject = this;
        foreach (Annonce p in Annonces)
            p.ScoreObject = this;
        foreach (Petit p in Petits)
            p.ScoreObject = this;

        Oudler.text = "0";
        Points.text = "56";
	}
	
	public void Recalculate()
    {
        if (!internalRecalculate())
        {
            for (int i = 0; i < SubScore.Count; ++i)
            {
                SubScore[i].text = "0";
            }
        }
    }

    bool internalRecalculate()
    {
        int preneur = -1;
        int soutient = -1;
        int pointFait = 0;
        int pointAFaire = 56;
        int baseScore = 0;
        for (int i = 0; i <  Prises.Count; ++i)
        {
            Prise p = Prises[i];
            if (p.priseType != Prise.PriseType.Defense && p.priseType != Prise.PriseType.Partenaire)
            {
                if (preneur == -1)
                    preneur = i;
                else
                    return false;
            }
            if (p.priseType == Prise.PriseType.Partenaire)
            {
                if (soutient == -1)
                    soutient = i;
                else
                    return false;
            }
                
        }
        if (preneur == -1)
            return false;
        pointAFaire = int.Parse(Oudler.text) == 0 ? 56 : int.Parse(Oudler.text) == 1 ? 51 : int.Parse(Oudler.text) == 2 ? 41 : 36;
        pointFait = int.Parse(Points.text);

        int diffscore  = pointFait - pointAFaire;
        baseScore = diffscore + ((diffscore >= 0) ? 25 : -25);

        bool found = false;
        //Petit au bout
        for (int i = 0; i < Petits.Count; ++i)
        {
            Petit petit = Petits[i];
            if (petit.annonce == Petit.PetitType.Petit_au_bout)
            {
                if (found)
                    return false;
                baseScore += (i == preneur || i == soutient) ? 10 : -10;
                found = true;
            }
        }

        int mult = Prises[preneur].priseType == Prise.PriseType.Petite ? 1 : Prises[preneur].priseType == Prise.PriseType.Garde ? 2 : Prises[preneur].priseType == Prise.PriseType.Garde_Sans ? 4 : 6;
        baseScore *= mult;

        //poignée
        for (int i = 0; i < Annonces.Count; ++i)
        {
            Annonce ann = Annonces[i];
            if (ann.annonce != Annonce.AnnonceType.Aucune_annonce)
            {
                int annScore = ann.annonce == Annonce.AnnonceType.Poignée ? 20 : ann.annonce == Annonce.AnnonceType.Double_poignée ? 30 : 40;
                    baseScore += diffscore >= 0 ? annScore : -annScore;
            } 
        }


        for (int i = 0; i < SubScore.Count; ++i)
        {
            if (i == preneur)
                SubScore[i].text = (baseScore * (soutient == -1 ? 4 : 2)).ToString();
            else if (i == soutient)
                SubScore[i].text = baseScore.ToString();
            else
                SubScore[i].text = (-baseScore).ToString();

        }
        return true;
    }
    public void Add()
    {
        for (int i = 0; i < SubScore.Count; ++i)
        {
            TotalScore[i].text = (int.Parse(SubScore[i].text) + int.Parse(TotalScore[i].text)).ToString();
            SubScore[i].text = "0";
        }
        foreach (Prise p in Prises)
            p.Reset();
        foreach (Annonce p in Annonces)
            p.Reset();
        foreach (Petit p in Petits)
            p.Reset();

        Oudler.text = "0";
        Points.text = "56";
        Recalculate();
    }
}
