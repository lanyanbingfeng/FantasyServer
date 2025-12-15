
using Fantasy;
using Fantasy.Entitas;
using TMPro;
using UnityEngine;
public class InputFieldManager : MonoBehaviour
{
    private TMP_InputField _inputField;
    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onSubmit.AddListener(SendLoginRequest);
    }

    private async void SendLoginRequest(string content)
    {
        LoginResponse loginResponse = await Runtime.Session.LoginRequest(content);
        if (loginResponse.isLogin)
        {
            Debug.Log("登录成功");
            GameObject playerObj = Instantiate(FantasyManager.Instance.playerPrefab);
            FantasyManager.Instance.localPlayer = playerObj.GetComponent<PlayerObj>();
            FantasyManager.Instance.clientID = FantasyManager.Instance.localPlayer.clientID = loginResponse.id;
            FantasyManager.Instance.localPlayer.playerName = content;
            Entity.Create<Player>(Runtime.Scene,true,true);
        }
    }
}
