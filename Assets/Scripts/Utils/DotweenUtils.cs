using DG.Tweening;
using TMPro;
using UnityEngine;
using ES3Internal;

public static class DotweenUtils
{
    public static void ScalePopout(Transform target, float duration, float scale)
    {
        target.localScale = Vector3.zero;
        target.DOScale(scale, duration).SetEase(Ease.OutBack);
    }

    public static void ReversePopoutScale(Transform target, float duration, float scale)
    {
        target.DOScale(scale, duration).OnComplete(() => { target.gameObject.SetActive(false); });
    }

    public static void MoveUpFadeOut(TextMeshProUGUI textMeshPro, float duration, Vector3 screenPosition)
    {
        textMeshPro.DOFade(1, 0);
        textMeshPro.transform.DOMove(screenPosition, 0).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.transform.DOMoveY(screenPosition.y + 100, duration).SetEase(Ease.InOutQuad);

            textMeshPro.DOFade(0, duration).OnComplete(() =>
            {
                textMeshPro.gameObject.SetActive(false);
            });
        });
    }

    public static void MoveUIAndDisable(RectTransform UI, RectTransform targetPos ,float duration)
    {
        UI.DOMove(targetPos.position, duration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            UI.gameObject.SetActive(false);
        });
    }

    public static void MoveUIAndEnable(RectTransform UI, RectTransform targetPos, float duration)
    {
        UI.DOMove(targetPos.position, duration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            UI.gameObject.SetActive(true);
        });
    }

    public static void ScoreComboUIFormSide(RectTransform UI, RectTransform targetPos, float duration, TextMeshProUGUI score, TextMeshProUGUI combo)
    {
        UI.DOMove(targetPos.position, duration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            score.DOCounter(0, ScoreAndCombo.instance.Score, 1f).OnComplete(() =>
            {
                combo.DOCounter(0, ES3.Load<int>("BestCombo", 1), 1f).OnUpdate(() =>
                {
                    combo.text = combo.text + "X";
                });
            });
            
        });
    }

}
