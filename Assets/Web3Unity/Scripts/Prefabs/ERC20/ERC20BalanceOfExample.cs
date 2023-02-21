using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC20BalanceOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "Mumbai Testnet";
        string network = "Testnet";
        string contract = "0xf71aaD689A12DC5dAb8EC49C6e14314DBE3D6901";
        string account = PlayerPrefs.GetString("Account");

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf); 
    }
}
