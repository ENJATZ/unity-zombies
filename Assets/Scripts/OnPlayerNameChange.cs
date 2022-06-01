using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnPlayerNameChange : MonoBehaviour
{
    void Start() {
        gameObject.GetComponent<TMP_InputField>().text = GlobalVariables.playerName;
    }
    public void SetPlayerName(String _) {
        string name = gameObject.GetComponent<TMP_InputField>().text;
        GlobalVariables.playerName = name;
    }

}
