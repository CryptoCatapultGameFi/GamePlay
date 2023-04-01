using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class Status
{
    public bool user_playing;
}

#if UNITY_WEBGL
public class WebLogin : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account;
    public static string Account;

    public async void OnLogin()
    {
        Web3Connect();
        await OnConnected();
    }

    async private Task OnConnected()
    {
        account = ConnectAccount();
        while (account == "")
        {
            await Task.Delay(1000);
            account = ConnectAccount();
        }
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        // reset login message
        SetConnectAccount("");
        // load next scene
        bool status = await FetchData(account);
        Account = account;
        Debug.Log(status);
        if (status)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnSkip()
    {
        // burner account for skipped sign in screen
        PlayerPrefs.SetString("Account", "");
        // move to next scene
    }
    
    async private Task<bool> FetchData(string account)
    {
        string url = "https://catapult-backend.herokuapp.com/user/status/" + account;
        using (var request = UnityWebRequest.Get(url))
        {
            await request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                return false;
            }
            else
            {
                Status status = JsonUtility.FromJson<Status>(request.downloadHandler.text);
                return status.user_playing;
            }
        }
    }
}
#endif
