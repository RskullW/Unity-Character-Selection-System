using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public event Action OnSave;
    
    public void ClickSelect()
    {
        OnSave?.Invoke();

        gameObject.SetActive(false);
    }
}
