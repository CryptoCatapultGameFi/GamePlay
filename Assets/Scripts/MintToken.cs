using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Numerics;

public class Bullet
{
    public string name;
    public string description;
    public string power;
    public string image;
}

#if UNITY_WEBGL
public class MintToken : MonoBehaviour
{
    public string url = "https://gateway.pinata.cloud/ipfs/QmTSmHJ89pJQYxjq9PxgP246DB1t5TFTMHMfMjSHukKTcB?_gl=1*8sg97w*_ga*MTY2MzA3NTMwLjE2Nzc2NjQzOTQ.*_ga_5RMPXG14TE*MTY3NzY2NDM5NS4xLjEuMTY3NzY2NDU4NC40OS4wLjA.";
    public int testValue;
    public string testFetch;

    void Start() {
        StartCoroutine(GetText());
    }

    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            // Debug.Log(www.error);
        }
        else {
            Bullet bullet = new Bullet();
            bullet = JsonUtility.FromJson<Bullet>(www.downloadHandler.text);
            testFetch = bullet.power;
            // Show results as text
            // Debug.Log("Over here");
            // Debug.Log(www.downloadHandler.text);
            // Debug.Log("This is my hope " + testFetch);
            // Debug.Log(www.downloadHandler[0]);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    
    async public void OnSendContract()
    {
        Debug.Log("This is contract part now");
        await GetText();
        Debug.Log(testFetch);
        // int testValue = 7;
        string openBraclet = "[";
        string closeBraclet = "]";
        // smart contract method to call
        string method = "giveAmount";
        // abi in json format
        string abi = "[ { \"inputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"constructor\"}, {\"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"owner\", \"type\": \"address\"}, {\"indexed\": true, \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\"} ], \"name\": \"Approval\", \"type\": \"event\"}, {\"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\"}, {\"indexed\": true, \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\"}, {\"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\"} ], \"name\": \"Transfer\", \"type\": \"event\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"owner\", \"type\": \"address\"}, {\"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"} ], \"name\": \"allowance\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"approve\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"account\", \"type\": \"address\"} ], \"name\": \"balanceOf\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"decimals\", \"outputs\": [ { \"internalType\": \"uint8\", \"name\": \"\", \"type\": \"uint8\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"subtractedValue\", \"type\": \"uint256\"} ], \"name\": \"decreaseAllowance\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"giveAmount\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"giveMeTen\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"ad\", \"type\": \"address\"} ], \"name\": \"giveTenTo\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"addedValue\", \"type\": \"uint256\"} ], \"name\": \"increaseAllowance\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"name\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"symbol\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [], \"name\": \"totalSupply\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\"} ], \"stateMutability\": \"view\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"transfer\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"}, {\"inputs\": [ { \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\"}, {\"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\"}, {\"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\"} ], \"name\": \"transferFrom\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\"} ], \"stateMutability\": \"nonpayable\", \"type\": \"function\"} ]";
        // address of contract
        string contract = "0x76d7d4a62dE48579C103ff3a6dec0cb73a1C67Be";
        // array of arguments for contract
        string args = openBraclet+testFetch+closeBraclet;
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to update contract state
        try {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
            Debug.Log(response);
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
}
#endif