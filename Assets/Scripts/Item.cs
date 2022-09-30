using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Transform _endPosition;
    private Vector3 _spawnPosition;
    
    public string Name => _name;

    private void Awake()
    {
        _spawnPosition = transform.position;
    }

    public void StartAnimation()
    {
        var sequence = DOTween.Sequence();
        transform.position = _spawnPosition;
        sequence.Append(transform.DOMove(_endPosition.position, 0.6f));
        
        // sequence.Kill();
    }

    public void StopAnimation()
    {
    }
}