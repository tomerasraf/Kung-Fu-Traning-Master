using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Game Over UI")]
    [SerializeField]
    GameObject _gameOverUI;
    [SerializeField]
    RectTransform _gameOverTitle;
    [SerializeField]
    RectTransform _tryAgainButton;

    [Header("Level Complete UI")]
    [SerializeField]
    GameObject _levelCompleteUI;
    [SerializeField]
    RectTransform _levelCompleteTitle;
    [SerializeField]
    RectTransform _nextLevelButton;

    [Header("Gameplay UI")]
    [SerializeField]
    RectTransform _gameplayUI;
    [SerializeField]
    Image _LevelSlider;

    [Header("Chances Text")]
    [SerializeField]
    private TextMeshProUGUI[] _chancesTexts;

    [Header("Score & Combo")]
    [SerializeField]
    TextMeshProUGUI _score;
    [SerializeField]
    TextMeshProUGUI _combo;

    [Header("Triggers")]
    [SerializeField]
    RectTransform _leftTrigger;
    [SerializeField]
    RectTransform _rightTrigger;

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

    private void OnEnable()
    {
        LevelManager.LevelComplete += LevelComplete;
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        LevelManager.LevelComplete -= LevelComplete;
        GameManager.OnGameOver -= OnGameOver;
    }

    void OnGameOver()
    {
        StartCoroutine(GameOverUI());
    }

    void LevelComplete()
    {
        StartCoroutine(LevelCompleteUI());
    }

    IEnumerator LevelCompleteUI()
    {
        DotweenUtils.MoveUIAndDisable(_gameplayUI, 450, 0.5f);
        _levelCompleteUI.SetActive(true);

        DotweenUtils.MoveUIAndEnable(_levelCompleteTitle, -750, 1.5f);
        DotweenUtils.MoveUIAndEnable(_nextLevelButton, 1000, 1.5f);

        _leftTrigger.gameObject.SetActive(false);
        _rightTrigger.gameObject.SetActive(false);

        yield return null;
    }

    IEnumerator GameOverUI()
    {
        DotweenUtils.MoveUIAndDisable(_gameplayUI, 450, 0.5f);
        _gameOverUI.SetActive(true);
        DotweenUtils.MoveUIAndEnable(_gameOverTitle, -750, 1.5f);
        DotweenUtils.MoveUIAndEnable(_tryAgainButton, 1000, 1.5f);

        _leftTrigger.gameObject.SetActive(false);
        _rightTrigger.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        foreach (var chance in _chancesTexts)
        {
            DotweenUtils.ReversePopoutScale(chance.transform, 1f, 0);
        }

        yield return null;
    }

    public void UpdateLevelSlider(float value)
    {
       _LevelSlider.fillAmount = value/100;
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
