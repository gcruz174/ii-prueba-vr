using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    private TMP_Text _text;
    private int _points;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        SpiderTrigger.OnKilled += OnKillSpider;
    }

    private void OnDestroy()
    {
        SpiderTrigger.OnKilled -= OnKillSpider;
    }

    private void OnKillSpider()
    {
        _points += 10;
        _text.text = $"Points: {_points}";
    }
}
