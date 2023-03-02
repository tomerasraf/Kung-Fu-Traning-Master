using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
}
