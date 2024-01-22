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
        string RewardLogPath;
        RewardData RewardLogData;
        DailyRewardCard TodayRewadCard;

        void Awake()
        {
            Init();
        }

        void Init()
        {
            RewardLogPath = Path.Combine(Application.dataPath, "RewardLog.json");
            if (File.Exists(RewardLogPath))
            {
                string data = File.ReadAllText(RewardLogPath);
                RewardLogData = JsonUtility.FromJson<RewardData>(data);
                return;
            }
            RewardData rewardData = new RewardData();
            string json = JsonUtility.ToJson(rewardData, true);
            File.WriteAllText(RewardLogPath, json);
            RewardLogData = rewardData;
        }

        void Start()
        {
            ClaimedRewards(RewardLogData);
            TodayReward(RewardLogData);
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
            TodayRewadCard = dailyRewardCards[rewardData.Rewards.Count];
            TodayRewadCard.TodayReward();
        }


        public void onCollectRewardButtonClick()
        {
            RewardData newRewardData = new RewardData();
            newRewardData = RewardLogData;
            newRewardData.Rewards.Add(new Reward 
            { 
              Day = RewardLogData.Rewards.Count +1 , 
              Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") 
            });
            TodayRewadCard.Rewardcollected();

            string json = JsonUtility.ToJson(newRewardData,true);
            File.WriteAllText(RewardLogPath, json);

            collectButtonInteraction("COME BACK EVERY DAY TO COLLECT YOUR REWARDS", false);
        }



        void collectButtonInteraction(string ButtonStr, bool Interaction)
        {
            collectButton.interactable = Interaction;
            collectButton.GetComponentInChildren<TMP_Text>().text = ButtonStr;

        }

        
    }
}
