using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getReward : MonoBehaviour
{
    public Text myReward;
    // Start is called before the first frame update
    void Start()
    {
        string reward = MintToken.rewardTextShow;
        myReward.text = reward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
