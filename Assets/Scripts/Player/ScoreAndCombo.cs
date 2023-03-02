using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndCombo : MonoBehaviour
{
    public static ScoreAndCombo instance;

    public int score { get; private set; } = 0;
    public int combo { get; private set; } = 0;

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
        score += _score * combo;
    }

    public void ResetCombo()
    {
        combo = 0;
    }

    public  void IncreaseCombo()
    {
        combo++;
    }

}
