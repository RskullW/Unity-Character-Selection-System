using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] [NotNull] private List<Item> _itemsSkins;
    [SerializeField] [NotNull] private List<Item> _itemsStands;
    [SerializeField] [NotNull] private List<ScriptButton> _buttonsSkins;
    [SerializeField] [NotNull] private List<ScriptButton> _buttonsStands;
    
    [SerializeField] [NotNull] private SaveButton _saveButton;
    [SerializeField] [NotNull] private TextMeshProUGUI _itemName;
    
    [SerializeField] [NotNull] private Sprite _spriteLockedActive;
    [SerializeField] [NotNull] private Sprite _spriteLockedNotActive;
    [SerializeField] [NotNull] private Sprite _spriteNotActive;
    [SerializeField] [NotNull] private Sprite _spriteActive;

    [SerializeField] [NotNull] private GameObject _prefabMark;

    private GameObject _gameObjectMarkStand;
    private GameObject _gameObjectMarkSkins;
    void Start()
    {
        _saveButton.OnSave += SaveData;

        LoadData();
        SaveData();
        
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
        if (PlayerPrefs.HasKey("itemsSkins"))
        {
            string itemSkin = PlayerPrefs.GetString("itemsSkins");
            string itemStand = PlayerPrefs.GetString("itemsStands");

            _itemName.text = itemSkin;
            foreach (var item in _itemsSkins)
            {
                
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
                    if (_gameObjectMarkSkins)
                    {
                        Destroy(_gameObjectMarkSkins);
                        _gameObjectMarkSkins = _buttonsSkins[index].SpawnMark(_prefabMark);

                    }

                    else
                    {
                        _gameObjectMarkSkins = _buttonsSkins[index].SpawnMark(_prefabMark);
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
                    if (_gameObjectMarkStand)
                    {
                        Destroy(_gameObjectMarkStand);
                        _gameObjectMarkStand = _buttonsStands[index].SpawnMark(_prefabMark);
                    }

                    else
                    {
                        _gameObjectMarkStand = _buttonsStands[index].SpawnMark(_prefabMark);

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
