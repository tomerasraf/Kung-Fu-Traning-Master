using UnityEngine;
using System;
using MoreMountains.Tools;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action OnGameOver;
    
    private const int MAX_CHANCES = 3;
    public int Chances { get; private set; } = MAX_CHANCES;
    public bool isGameOver { get; private set; } = false;

    private void Awake()
    {
       instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void DecreaseChances()
    {
        Chances--;
        UIManager.Instance.UpdateChancesText();
        
        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.FailSounds[Chances], MMSoundManagerPlayOptions.Default);
        
        if (Chances <= 0)
        {
            isGameOver = true;
            OnGameOver?.Invoke();
            return;
        }
    }

    public void ResetChances()
    {
        UIManager.Instance.UpdateResetChances();
        Chances = MAX_CHANCES;
    }
}
