using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine.UI;


#if UNITY_WEBGL
public class MintToken : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Close();

    
    public string urlPost = "https://catapult-backend.herokuapp.com/user/finish/";
    private string account = WebLogin.Account;

    public string rewardText;

    private bool isComplete = false;
    private bool isMinting = false; 

    void Start() {
         
        
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
        rewardText = WebLogin.rewardTextShow;
        Debug.Log("Here");

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