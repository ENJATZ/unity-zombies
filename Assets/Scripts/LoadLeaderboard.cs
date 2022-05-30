using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadLeaderboard : MonoBehaviour
{
    public Transform tableContent;
    public GameObject rowItem;
    public DatabaseManager databaseManager;

    void OnEnable()
    {
        DestroyPreviousItems();
        LoadPlayer();
    }
    private async void LoadPlayer() 
    {
        List<Player> playersList = await databaseManager.GetPlayers();
        foreach (Player player in playersList) {
            GameObject newRowItem = Instantiate(rowItem, tableContent);
            newRowItem.tag = "ScoreboardItem";
            TextMeshProUGUI name = newRowItem.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI score = newRowItem.transform.Find("Score").GetComponent<TextMeshProUGUI>();
            name.SetText(player.playerName);
            score.SetText(player.score.ToString());
        }
    }
    private void DestroyPreviousItems() {
        GameObject[] items = GameObject.FindGameObjectsWithTag("ScoreboardItem");
        foreach(GameObject item in items)
            GameObject.Destroy(item); 
    }
}
