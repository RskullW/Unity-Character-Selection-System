using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Item> _itemsSkins;
    [SerializeField] private List<Item> _itemsStands;
    [SerializeField] private List<ScriptButton> _buttonsSkins;
    [SerializeField] private List<ScriptButton> _buttonsStands;
    
    [SerializeField] private SaveButton _saveButton;
    [SerializeField] private TextMeshProUGUI _itemName;
    
    [SerializeField] private Sprite _spriteLockedActive;
    [SerializeField] private Sprite _spriteLockedNotActive;
    [SerializeField] private Sprite _spriteNotActive;
    [SerializeField] private Sprite _spriteActive;

    [SerializeField] private GameObject _prefabMark;

    private GameObject _gameObjectMark;
    void Start()
    {
        LoadData();
        
        foreach (var button in _buttonsSkins)
        {
            button.OnClick += ChangeBackgroundButtons;
        }
        
        foreach (var button in _buttonsStands)
        {
            button.OnClick += ChangeBackgroundButtons;
        }

        ChangeBackgroundButtons();
    }
    void LoadData()
    {
        if (PlayerPrefs.HasKey("itemName"))
        {
            string itemSkin = PlayerPrefs.GetString("itemsSkins");
            string itemStand = PlayerPrefs.GetString("itemsStands");

            _itemName.text = itemSkin;
            foreach (var item in _itemsSkins)
            {
                _saveButton.OnSave += SaveData;
                item.SetIsSelected(false);
                
                if (item.Name == itemSkin)
                {
                    item.gameObject.SetActive(true);
                    item.SetPosition();
                    item.SetIsSelected(true);
                }
            }

            foreach (var item in _itemsStands)
            {
                _saveButton.OnSave += SaveData;
                item.SetIsSelected(false);

                if (item.Name == itemStand)
                {
                    item.gameObject.SetActive(true);
                    item.SetPosition();
                    item.SetIsSelected(true);
                }
            }
            
            _saveButton.gameObject.SetActive(false);
        }
    }
    void SaveData()
    {
        ushort index = 0;
        
        foreach (var item in _itemsSkins)
        {
            item.SetIsSelected(false);
            if (item.gameObject.activeSelf && !item.IsLocked)
            {
                PlayerPrefs.SetString("itemsSkins", item.Name);
                item.SetIsSelected(true);

                if (_buttonsSkins[index].gameObject.activeSelf)
                {
                    if (_gameObjectMark)
                    {
                        Destroy(_gameObjectMark);
                        _gameObjectMark = _buttonsSkins[index].SpawnMark(_prefabMark);
                    }

                    else
                    {
                        _gameObjectMark = _buttonsSkins[index].SpawnMark(_prefabMark);
                    }
                }
            }
            
            index++;
        }
        
        index = 0;

        foreach (var item in _itemsStands)
        {
            item.SetIsSelected(false);
            if (item.gameObject.activeSelf && !item.IsLocked)
            {
                PlayerPrefs.SetString("itemsStands", item.Name);

                if (_buttonsStands[index].gameObject.activeSelf)
                {
                    if (_gameObjectMark)
                    {
                        Destroy(_gameObjectMark);
                        _gameObjectMark = _buttonsStands[index].SpawnMark(_prefabMark);
                    }

                    else
                    {
                        _gameObjectMark = _buttonsStands[index].SpawnMark(_prefabMark);
                    }
                }

                item.SetIsSelected(true);
            }
            
            index++;

        }
    }
    void ChangeBackgroundButtons()
    {
        if (_buttonsSkins[0].gameObject.activeSelf)
        {
            
            for (ushort i = 0; i < _buttonsSkins.Count; ++i)
            {
                var button = _buttonsSkins[i];
                var item = _itemsSkins[i];

                if (item.IsLocked)
                {
                    button.SetSprite(_spriteLockedNotActive);

                    if (item.gameObject.activeSelf)
                    {
                        button.SetSprite(_spriteLockedActive);
                    }
                }

                else
                {
                    button.SetSprite(_spriteNotActive);

                    if (item.gameObject.activeSelf)
                    {
                        button.SetSprite(_spriteActive);
                    }
                }
            }
        }

        if (_buttonsStands[0].gameObject.activeSelf)
        {
            for (ushort i = 0; i < _buttonsStands.Count; ++i)
            {
                var button = _buttonsStands[i];
                var item = _itemsStands[i];

                if (item.IsLocked)
                {
                    button.SetSprite(_spriteLockedNotActive);

                    if (item.gameObject.activeSelf)
                    {
                        button.SetSprite(_spriteLockedActive);
                    }
                }

                else
                {
                    button.SetSprite(_spriteNotActive);
                    
                    if (item.gameObject.activeSelf)
                    {
                        button.SetSprite(_spriteActive);
                    }
                }
            }
        }
    }
}
