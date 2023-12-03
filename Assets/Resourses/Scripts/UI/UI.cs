using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] private TMP_Text shootCount;
    [SerializeField] private Text shootCountText;
    [HideInInspector] public UnityEvent<string> shootCountChanged = new UnityEvent<string>();

    public void Initialize()
    {
        shootCountChanged.AddListener(OnShootCountChanged);
    }

    private void OnShootCountChanged(string count)
    {
        print(count);
        shootCount.text = $"{count}";
        shootCountText.text = count;
    }
}
