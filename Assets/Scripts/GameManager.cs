using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Item> _itemsSkins;
    [SerializeField] private List<Item> _itemsStands;
    [SerializeField] private SaveButton _saveButton;
    [SerializeField] private TextMeshProUGUI _itemName;
    void Start()
    {
        LoadData();
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
        foreach (var item in _itemsSkins)
        {
            item.SetIsSelected(false);
            if (item.gameObject.activeSelf && !item.IsLocked)
            {
                PlayerPrefs.SetString("itemsSkins", item.Name);
                item.SetIsSelected(true);

            }
        }
        
        foreach (var item in _itemsStands)
        {
            item.SetIsSelected(false);
            if (item.gameObject.activeSelf && !item.IsLocked)
            {
                PlayerPrefs.SetString("itemsStands", item.Name);
                item.SetIsSelected(true);
            }
        }
    }
}
