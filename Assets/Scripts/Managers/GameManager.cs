using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const int MAX_CHANCES = 3;
    public int Chances { get; private set; } = MAX_CHANCES;
    public bool isGameOver { get; private set; } = false;

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

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void DecreaseChances()
    {
        Chances--;
        UIManager.Instance.UpdateChancesText();


        if (Chances <= 0)
        {
            isGameOver = true;
            return;
        }
    }

    public void ResetChances()
    {
        UIManager.Instance.UpdateResetChances();
        Chances = MAX_CHANCES;
    }
}
