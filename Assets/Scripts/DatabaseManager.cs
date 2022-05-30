using Firebase.Database;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour
{
    private DatabaseReference _db;
    string userId;
    void Start()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        _db = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public async void InsertPlayer(string playerName, int score) {
        Player player = new Player(playerName, score, userId);
        string json = JsonUtility.ToJson(player);

        if(_db == null) {
            _db = FirebaseDatabase.DefaultInstance.RootReference;
            userId = SystemInfo.deviceUniqueIdentifier;
        }
        var snapshot = await _db.Child("leaderboard").Child(playerName).GetValueAsync();
        Player dbPlayer = JsonUtility.FromJson<Player>(snapshot.GetRawJsonValue());
        if(snapshot.ChildrenCount > 0) {
            if(score > dbPlayer.score) {
                _db.Child("leaderboard").Child(playerName).RemoveValueAsync();
            }
        }
        _db.Child("leaderboard").Child(playerName).SetRawJsonValueAsync(json);
    }

    public async Task<List<Player>> GetPlayers() {
        if(_db == null) {
            _db = FirebaseDatabase.DefaultInstance.RootReference;
        }
        var snapshot = await _db.Child("leaderboard").OrderByChild("score").LimitToLast(7).GetValueAsync();
        Debug.Log(snapshot.GetRawJsonValue());
        List<Player> players = new List<Player>();
        foreach(var child in snapshot.Children.Reverse())
        {
            Player player = JsonUtility.FromJson<Player>(child.GetRawJsonValue());
            players.Add(player);
        }
        return players;
    }
}
