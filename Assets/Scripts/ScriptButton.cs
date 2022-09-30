using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptButton : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private int _numberItem;
    [SerializeField] private TextMeshProUGUI _itemName;

    private void Awake()
    {
        foreach (var item in _items)
        {
            if (item.enabled)
            {
                _itemName.text = item.Name;
                break;
            }
        }
    }
    public void SpawnItem()
    {
        foreach (var item in _items)
        {
            item.gameObject.SetActive(false);
        }
        
        _items[_numberItem-1].gameObject.SetActive(true);
        _items[_numberItem-1].StartAnimation();
        _itemName.text = _items[_numberItem - 1].Name;
    }

    public void SetText()
    {
        foreach (var item in _items)
        {
            if (item.gameObject.activeSelf)
            {
                _itemName.text = item.Name;
                break;
            }
        }
    }
}
