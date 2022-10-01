using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScrollView : MonoBehaviour
{
    [SerializeField] private string _groupName;
    [SerializeField] private GameObject _firstScrollView;
    [SerializeField] private GameObject _secondScrollView;
    [SerializeField] private TextMeshProUGUI _groupTextMesh;

    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private Sprite _spriteDisable;
    
    private Image _imageBackground;
    private void Awake()
    {
        _imageBackground = GetComponent<Image>();
        
        _imageBackground.sprite = _spriteDisable;
        
        if (_firstScrollView.activeSelf)
        {
            _groupTextMesh.text = _groupName;
            _imageBackground.sprite = _spriteActive;
        }
    }

    public void SetScrollView()
    {
        _secondScrollView.SetActive(false);
        _firstScrollView.SetActive(true);
        _groupTextMesh.text = _groupName;
        _imageBackground.sprite = _spriteActive;
    }

    public void SetActive(bool isActive)
    {
        _imageBackground.sprite = _spriteDisable;
        
        if (isActive)
        {
            _imageBackground.sprite = _spriteActive;
        }
    } 
}
