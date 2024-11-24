using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public InputField nameInput;
    public Text nameText;
    private string _currentName;
    void Start()
    {
        _currentName = PlayerPrefs.GetString("currentName", string.Empty);
        Debug.Log(_currentName);
        nameInput.text = _currentName;
        nameText.text = _currentName;
    }

    public void ReadStringInput(string s)
    {
        _currentName = s;
        PlayerPrefs.SetString("currentName", _currentName);
    }
}
