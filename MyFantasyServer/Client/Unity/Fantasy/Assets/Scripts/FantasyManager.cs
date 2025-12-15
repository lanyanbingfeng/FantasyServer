
using System.Collections.Generic;
using UnityEngine;

public class FantasyManager : MonoBehaviour
{
    private static FantasyManager instance;
    public static FantasyManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    
    public int clientID;
    public GameObject playerPrefab;
    public PlayerObj localPlayer;
    
    public Dictionary<int,PlayerObj> OtherPlayerDic = new();
}
