using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScriptButton : MonoBehaviour
{
    public event Action OnClick;
    
    [SerializeField] private List<Item> _items;
    [SerializeField] private int _numberItem;
    [SerializeField] private TextMeshProUGUI _itemName;

    [SerializeField] Image _backgroundImage;
    [SerializeField] private Vector3 _positionMark;
    
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
        _items[_numberItem-1].ChangeItem();
        _itemName.text = _items[_numberItem - 1].Name;
        
        OnClick?.Invoke();
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
    public void SetSprite(Sprite sprite)
    {
        _backgroundImage.sprite = sprite;
    }

    public GameObject SpawnMark(GameObject prefab)
    {
        GameObject gameObject1 = Instantiate(prefab, prefab.transform.position, Quaternion.identity, this.transform);
        gameObject1.transform.localPosition = _positionMark;
        return gameObject1;
    }

}
