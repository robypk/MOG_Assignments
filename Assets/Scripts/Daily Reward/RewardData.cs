using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOG.Roby
{

    [Serializable]
    public struct Reward
    {
        public int Day;
        public string Time;
    }

    [Serializable]
    public class RewardData
    {
        public List<Reward> Rewards = new List<Reward>();  
    }


}
