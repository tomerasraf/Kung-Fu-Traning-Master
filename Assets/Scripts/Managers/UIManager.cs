using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Chances Text")]
    [SerializeField]
    private TextMeshProUGUI[] _chancesTexts;

    [Header("Score & Combo")]
    [SerializeField]
    TextMeshProUGUI _score;
    [SerializeField]
    TextMeshProUGUI _combo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore()
    {
        _score.text = ScoreAndCombo.instance.score.ToString();
    }

    public void UpdateCombo()
    {
        _combo.text = ScoreAndCombo.instance.combo.ToString();
    }

    public void UpdateResetChances()
    {
        for (int i = 0; i < _chancesTexts.Length; i++)
        {
            DotweenUtils.ReversePopoutScale(_chancesTexts[i].transform, 0.5f, 0f);
        }
    }

    public void UpdateChancesText()
    {
        DotweenUtils.ScalePopout(_chancesTexts[GameManager.instance.Chances].transform, 0.5f, 1f);
        _chancesTexts[GameManager.instance.Chances].gameObject.SetActive(true);
    }
}
