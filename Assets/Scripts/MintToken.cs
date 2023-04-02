using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class UserNFT
{
    public string catapult_power;

    public string bullet_power;
}

#if UNITY_WEBGL
public class MintToken : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Close();

    public string url = "https://catapult-backend.herokuapp.com/user/nft/";
    public string urlPost = "https://catapult-backend.herokuapp.com/user/finish/";
    private string account = WebLogin.Account;
    public string catapultPower;
    public string rewardText;
    public static string rewardTextShow;
    public string bulletPower;
    private bool isComplete = false;
    private bool isMinting = false; 
    private int reward;


    void Start() {
        
        StartCoroutine(GetText());
        GetText();
    }

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
            int randomNumber = Random.Range(6, 7);
            reward = (Int16.Parse(bulletPower) + Int16.Parse(catapultPower)) * randomNumber;
            rewardText = reward.ToString();
            Debug.Log("Here");

            rewardTextShow = rewardText;
            Debug.Log(rewardTextShow);
        }
    }

    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post(url+account, form);
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Data sent");
        }
    }
    
    async public void OnSendContract()
    {
        Debug.Log("This is contract part now");
        await GetText();

        string openBraclet = "[";
        string closeBraclet = "]";
        // smart contract method to call
        string method = "giveAmount";
        // abi in json format
        string abi = "[ { \"inputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"constructor\"}, {\"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"owner\", \"type\": \"address\"}, {\"indexed\": true, \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\"} ], \"name\": \"Approval\", \"type\": \"event\"}, {\"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\"}, {\"indexed\": true, \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\"}, {\"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\"} ], \"name\": \"Transfer\", \"type\": \"event\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"owner\", \"type\": \"address\"}, {\"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"} ], \"name\": \"allowance\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"approve\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"account\", \"type\": \"address\"} ], \"name\": \"balanceOf\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"burn\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"decimals\", \"outputs\": [ { \"internalType\": \"uint8\", \"name\": \"\", \"type\": \"uint8\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"subtractedValue\", \"type\": \"uint256\"} ], \"name\": \"decreaseAllowance\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"giveAmount\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"giveMeTen\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"ad\", \"type\": \"address\"} ], \"name\": \"giveTo\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"addedValue\", \"type\": \"uint256\"} ], \"name\": \"increaseAllowance\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"name\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"symbol\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"totalSupply\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"transfer\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\"}, {\"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"transferFrom\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"} ]";
        // address of contract
        string contract = "0xC3f68624cAe56dBCDBfFe1A13d63EB43079B85d1";
        // array of arguments for contract
        string args = openBraclet+rewardText+closeBraclet;
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to update contract state
        if(isMinting) return ;

        if(!isMinting) {
            isMinting = true;

            try {
                
                string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
                isComplete = true;
                            
            } catch (Exception e) {
                Debug.LogException(e, this);
            }
            if(isComplete) {
                await PostRequest(urlPost);
                Close();
            }
        }
        
        
    }

}
#endif