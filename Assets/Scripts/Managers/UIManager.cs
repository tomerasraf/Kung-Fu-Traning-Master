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
    [SerializeReference]
    RectTransform comboTextRectTransform;


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
        _score.text = ScoreAndCombo.instance.Score.ToString();
    }

    public void UpdateCombo(Transform brokenObjectTransform)
    {
        if (ScoreAndCombo.instance.PlayerHits >= 5)
        {
            Vector3 worldPosition = brokenObjectTransform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            _combo.text = ScoreAndCombo.instance.Combo.ToString() + "X";
            DotweenUtils.MoveUpFadeOut(_combo, 0.5f, screenPosition);
        }
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
