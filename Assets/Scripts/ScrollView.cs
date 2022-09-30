using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollView : MonoBehaviour
{
    [SerializeField] private string _groupName;
    [SerializeField] private GameObject _firstScrollView;
    [SerializeField] private GameObject _secondScrollView;
    [SerializeField] private TextMeshProUGUI _groupTextMesh;

    private void Awake()
    {
        if (_firstScrollView.activeSelf)
        {
            _groupTextMesh.text = _groupName;
        }
    }

    public void SetScrollView()
    {
        _secondScrollView.SetActive(false);
        _firstScrollView.SetActive(true);
        _groupTextMesh.text = _groupName;

    }
}
