using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Item> _itemsSkins;
    [SerializeField] private List<Item> _itemsStands;
    [SerializeField] private TextMeshProUGUI _groupName;
    [SerializeField] private TextMeshProUGUI _itemName;
    void Start()
    {
        LoadData();
    }

    void Update()
    {
        SaveData();
    }
    
    void LoadData()
    {
        if (PlayerPrefs.HasKey("itemName"))
        {
            _itemName.text = PlayerPrefs.GetString("itemName");
            _groupName.text = PlayerPrefs.GetString("groupName");

            string itemSkin = PlayerPrefs.GetString("itemsSkins");
            string itemStand = PlayerPrefs.GetString("itemsStands");

            foreach (var item in _itemsSkins)
            {
                if (item.Name == itemSkin)
                {
                    item.gameObject.SetActive(true);
                    item.SetPosition();
                }
            }

            foreach (var item in _itemsStands)
            {
                if (item.Name == itemStand)
                {
                    item.gameObject.SetActive(true);
                    item.SetPosition();
                }
            }
        }
    }

    void SaveData()
    {
        PlayerPrefs.SetString("itemName", _itemName.text);
        PlayerPrefs.SetString("groupName", _groupName.text);

        foreach (var item in _itemsSkins)
        {
            if (item.gameObject.activeSelf)
            {
                PlayerPrefs.SetString("itemsSkins", item.Name);
                break;
            }
        }
        
        foreach (var item in _itemsStands)
        {
            if (item.gameObject.activeSelf)
            {
                PlayerPrefs.SetString("itemsStands", item.Name);
                break;
            }
        }
    }
}
