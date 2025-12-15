
using Fantasy;
using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using UnityEngine;

public class Player : Entity
{
    public string PlayerName = FantasyManager.Instance.localPlayer.playerName;
    public Vector3 PlayerPos => FantasyManager.Instance.localPlayer.transform.position;
}

public class PlayerUpdateSystem : UpdateSystem<Player>
{
    private const float MessageSendInterval = 1 / 60f;
    private float _timer;
    private Vector3 _playerOldPos;
    
    protected override void Update(Player self)
    {
        if (self == null) return;
        _timer += Time.deltaTime;
        if (_timer <= MessageSendInterval || _playerOldPos == self.PlayerPos) return;
        
        Runtime.Session.PlayerDataMessage(
            FantasyManager.Instance.localPlayer.clientID,
            self.PlayerName,
            new Vector3_Position { x = self.PlayerPos.x, y = self.PlayerPos.y, z = self.PlayerPos.z, }
            );
        
        _playerOldPos = self.PlayerPos;
        _timer = 0;
    }
}