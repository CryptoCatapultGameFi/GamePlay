using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class getBalanceOf : MonoBehaviour
{
    public Text tokenBalance;
    async void Start()
    {
        string chain = "polygon";
        Debug.Log("Work 1");
        string network = "mumbai";
        Debug.Log("Work 2");
        string contract = "0xf71aaD689A12DC5dAb8EC49C6e14314DBE3D6901";
        Debug.Log("Work 3");
        string account = PlayerPrefs.GetString("Account");
        Debug.Log("Work 4");

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        Debug.Log("Balance Of: " + balanceOf);
        tokenBalance.text = balanceOf.ToString();
    }
}
