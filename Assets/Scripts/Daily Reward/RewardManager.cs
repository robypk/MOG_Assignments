using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MOG.Roby
{
    public class RewardManager : MonoBehaviour
    {

        [SerializeField] List<DailyRewardCard> dailyRewardCards;
        [SerializeField] Button collectButton;
        string rewardLogPath;
        RewardData rewardLogData;
        DailyRewardCard todayRewadCard;

        void Awake()
        {
            Init();
        }

        void Init()
        {
            rewardLogPath = Path.Combine(Application.dataPath, "RewardLog.json");
            if (File.Exists(rewardLogPath))
            {
                string data = File.ReadAllText(rewardLogPath);
                rewardLogData = JsonUtility.FromJson<RewardData>(data);
                return;
            }
            RewardData rewardData = new RewardData();
            string json = JsonUtility.ToJson(rewardData, true);
            File.WriteAllText(rewardLogPath, json);
            rewardLogData = rewardData;
        }

        void Start()
        {
            ClaimedRewards(rewardLogData);
            TodayReward(rewardLogData);
        }

        void ClaimedRewards(RewardData rewardData)
        {
            if (rewardData.Rewards.Count == 0)
            {
                return;
            }
            foreach (Reward reward in rewardData.Rewards)
            {
                foreach (DailyRewardCard dailyRewardCard in dailyRewardCards)
                {
                    if (dailyRewardCard.Day == reward.Day)
                    {
                        dailyRewardCard.Rewardcollected();
                    }

                }
            }
        }

        void TodayReward( RewardData rewardData)
        {
            if (rewardData.Rewards.Count !=0) 
            {
                Reward previousReward = rewardData.Rewards[rewardData.Rewards.Count-1];
                DateTime rewardTime = DateTime.ParseExact(previousReward.Time, "yyyy-MM-dd HH:mm:ss", null);
                DateTime CurrentTime = DateTime.Now;   
                TimeSpan timeDiff = DateTime.Now - rewardTime;
                if (timeDiff.TotalHours <= 24)
                {
                    collectButtonInteraction("COME BACK EVERY DAY TO COLLECT YOUR REWARDS", false);
                    return;
                }
            }

            collectButtonInteraction("TAB TO COLLECT", true);
            //rewardData.Rewards.Sort((currentDay, previousDay) => previousDay.Day.CompareTo(currentDay.Day));
            todayRewadCard = dailyRewardCards[rewardData.Rewards.Count];
            todayRewadCard.TodayReward();
        }


        public void onCollectRewardButtonClick()
        {
            RewardData newRewardData = new RewardData();
            newRewardData = rewardLogData;
            newRewardData.Rewards.Add(new Reward 
            { 
              Day = rewardLogData.Rewards.Count +1 , 
              Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") 
            });
            todayRewadCard.Rewardcollected();

            string json = JsonUtility.ToJson(newRewardData,true);
            File.WriteAllText(rewardLogPath, json);

            collectButtonInteraction("COME BACK EVERY DAY TO COLLECT YOUR REWARDS", false);
        }



        void collectButtonInteraction(string ButtonStr, bool Interaction)
        {
            collectButton.interactable = Interaction;
            collectButton.GetComponentInChildren<TMP_Text>().text = ButtonStr;

        }

        
    }
}
