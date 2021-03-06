using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class OnPlayerDiedScreen : MonoBehaviour
{
    public DatabaseManager databaseManager;
    void OnEnable()
    {
        databaseManager.InsertPlayer(GlobalVariables.playerName, GlobalVariables.score);
        GlobalVariables.score = 0;
    }
    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
