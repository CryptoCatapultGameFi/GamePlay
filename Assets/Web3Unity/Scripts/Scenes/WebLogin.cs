using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.Numerics;


public class Status
{
    public bool user_playing;
}

public class UserNFT
{
    public string catapult_power;

    public string bullet_power;
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
    public static string rewardTextShow;
    public string url = "https://catapult-backend.herokuapp.com/user/nft/";
    private string catapultPower;
    private string bulletPower;

    public bool isOnConnected = false;

    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get(url+account);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            // Debug.Log(www.error);
        }
        else {
            UserNFT userNFT = new UserNFT();
            userNFT = JsonUtility.FromJson<UserNFT>(www.downloadHandler.text);
            catapultPower = userNFT.catapult_power;
            bulletPower = userNFT.bullet_power;
            // Show results as text
            // Debug.Log("Over here");
            // Debug.Log(www.downloadHandler.text);
            // Debug.Log("This is my hope " + testFetch);
            // Debug.Log(www.downloadHandler[0]);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            
        }
    }


    public async void OnLogin()
    {
        Web3Connect();
        await OnConnected();
        StartCoroutine(GetText());
    }

    async private Task OnConnected()
    {
        if(!isOnConnected) {
            
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
            await GetText();
            int randomNumber = Random.Range(5, 8);
            int reward = (Int16.Parse(bulletPower) + Int16.Parse(catapultPower)) * randomNumber;
            rewardTextShow = reward.ToString();

            Debug.Log(status);
            if(!isOnConnected) {
                if (status)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                        isOnConnected = true;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    isOnConnected = true;
                }
            } 
            
        } else {
            Debug.Log("Else");
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
