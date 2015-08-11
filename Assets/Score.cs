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
	}
	
	public void Recalculate()
    {

    }
}
