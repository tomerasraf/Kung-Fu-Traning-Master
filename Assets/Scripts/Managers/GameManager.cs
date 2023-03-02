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
        if (Chances <= 0)
        {
            isGameOver = true;
            return;
        }

        Chances--;
        UIManager.Instance.UpdateChancesText();
    }

    public void ResetChances()
    {
        Chances = MAX_CHANCES;
    }
}
