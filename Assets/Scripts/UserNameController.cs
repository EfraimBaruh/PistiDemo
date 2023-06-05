using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class UserNameController : MonoBehaviour
{
    public UnityEvent onFirstSession;

    // Start is called before the first frame update
    void Awake()
    {
        if (!File.Exists(Application.persistentDataPath
                       + "/PlayerData.dat"))
            onFirstSession.Invoke();
    }

    public void UpdateUserName(string name)
    {
        AppData.SetPlayerName(name);
    }

}
