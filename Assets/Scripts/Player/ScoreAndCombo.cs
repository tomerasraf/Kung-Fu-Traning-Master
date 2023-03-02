using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndCombo : MonoBehaviour
{
    public static ScoreAndCombo instance;

    public int Score { get; private set; } = 0;
    public int Combo { get; private set; } = 1;
    public int PlayerHits { get; private set; } = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int _score)
    {
        PlayerHits++;
        Score += _score * Combo;
    }

    public void ResetCombo()
    {
        PlayerHits = 0;
        Combo = 1;
    }

    public  void IncreaseCombo()
    {
        if(PlayerHits >= 5)
        Combo++;
    }

}
