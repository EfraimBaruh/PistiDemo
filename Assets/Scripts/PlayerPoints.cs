using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int playerID;

    public void OnEnable()
    {
        int playerCount = (int)AppManager.Instance.playerCount;

        gameObject.SetActive(playerCount > playerID);
    }
}
