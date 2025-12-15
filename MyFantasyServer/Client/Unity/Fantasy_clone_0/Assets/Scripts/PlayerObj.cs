
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    public int clientID;
    public string playerName;
    void Update()
    {
        if (FantasyManager.Instance.localPlayer != this) return;
        transform.Translate(Vector3.forward * (Time.deltaTime * 5 * Input.GetAxis("Vertical")));
        transform.Translate(Vector3.right * (Time.deltaTime * 5 * Input.GetAxis("Horizontal")));
    }
}
