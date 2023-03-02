using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreAndCombo
{
    public static int score = 0;
    public static int combo = 1;

    public static void AddScore(int score)
    {
        score += score * combo;
    }

    public static void ResetCombo()
    {
        combo = 1;
    }

    public static void IncreaseCombo()
    {
        combo++;
    }

}
