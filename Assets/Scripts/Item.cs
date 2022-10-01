using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private bool _isLocked;
    [SerializeField] private GameObject _lockedLable;
    [SerializeField] private GameObject _selectButton;
    private bool _isSelected;
    
    private Vector3 _spawnPosition;

    public string Name => _name;
    public bool IsLocked => _isLocked;

    private void Awake()
    {
        _spawnPosition = transform.position;
    }

    public void ChangeItem()
    {
        StartAnimation();
        _lockedLable.SetActive(IsLocked);
        _selectButton.SetActive(false);

        if (!_isLocked)
        {
            _selectButton.SetActive(true);

            if (_isSelected)
            {
                _selectButton.SetActive(false);
            }
        }
    }
    
    private void StartAnimation()
    {
        var sequence = DOTween.Sequence();
        transform.position = _spawnPosition;
        
        sequence.Append(transform.DOMove(_endPosition.position, 0.6f));

       
    }

    public void SetPosition()
    {
        transform.position = _endPosition.position;
    }

    public void SetIsSelected(bool isSelected)
    {
        _isSelected = isSelected;
    }
}