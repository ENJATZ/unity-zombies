using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public static class GlobalVariables{
    public static string playerName;
    public static int score = 0; 

    public static void SetPlayerName(string name) {
        playerName = name;
    }
 }