using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] _levelPrefabs;

    public static LevelManager instance;
    public static event Action LevelComplete;
    public int Level { get; private set; }
    public bool IsLevelComplete { get; private set; } = false;

    private int _defaultLevel = 1;

    private void Awake()
    {
        instance = this;

        Level = ES3.Load<int>("Level", _defaultLevel);
       
    }

    private void Start()
    {
        Instantiate(_levelPrefabs[Level - 1]);
        UIManager.Instance.UpdateLevelText(Level);
    }

    public void ReloadLevel()
    {
        IsLevelComplete = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel()
    {
        IsLevelComplete = true;
        Level++;

        ES3.Save<int>("Level", Level);

        LevelComplete?.Invoke();
    }
}
