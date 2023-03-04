using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static event Action LevelComplete;
    public int Level { get; private set; } = 1;
    public bool IsLevelComplete { get; private set; } = false;
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

    public void CompleteLevel()
    {
        IsLevelComplete = true;
        Level++;
        LevelComplete?.Invoke();
    }
}
