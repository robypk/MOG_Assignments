using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MOG.Roby
{
    public class DailyRewardCard : MonoBehaviour
    {
        [Header("Reward Data")]
        [SerializeField] Sprite RewardSprite;
        [SerializeField] int Day;
        [SerializeField] int RewardMultipler;


        [Header("Reward Referances")]
        [SerializeField] GameObject yellowBG;
        [SerializeField] GameObject greenBG;
        [SerializeField] TMP_Text dayText;
        [SerializeField] Image rewardImage;
        [SerializeField] TMP_Text rewardMultiplerText;
        [SerializeField] GameObject tickImage;

         void Awake()
        {
            Init();
        }

 

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        private void Init()
        {
            dayText.text = "Day " + Day;
            rewardMultiplerText.text = RewardMultipler + "X";
            rewardImage.sprite = RewardSprite;
        } 
    }
}
