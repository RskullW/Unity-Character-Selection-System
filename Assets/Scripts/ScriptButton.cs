using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptButton : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private int _numberItem;
    
    public void SpawnItem()
    {
        foreach (var item in _items)
        {
            item.gameObject.SetActive(false);
        }
        
        _items[_numberItem-1].gameObject.SetActive(true);
        _items[_numberItem-1].StartAnimation();
    }
}
