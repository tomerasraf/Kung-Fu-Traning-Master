using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES3Internal;

public class ScoreAndCombo : MonoBehaviour
{
    public static ScoreAndCombo instance;

    public int Score { get; private set; } = 0;
    public int Combo { get; private set; } = 1;
    public int BestCombo { get; private set;}
    public int PlayerHits { get; private set; } = 0;

    private void Awake()
    {
       instance = this;
    }

    public void AddScore(int _score)
    {
        PlayerHits++;
        Score += _score * Combo;
    }

    public void ResetCombo()
    {
        BestComboSaver();
        PlayerHits = 0;
        Combo = 1;
    }

    private void BestComboSaver()
    {
        if (Combo > ES3.Load<int>("BestCombo", 1))
        {
            BestCombo = Combo;
            ES3.Save("BestCombo", BestCombo);
        }
    }

    public  void IncreaseCombo()
    {
        if(PlayerHits >= 5)
        Combo++;
        BestComboSaver();
    }

}
