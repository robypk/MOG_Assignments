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
        [SerializeField] public int Day;
        [SerializeField] int RewardMultipler;


        [Header("Reward Referances")]
        [SerializeField] GameObject yellowBG;
        [SerializeField] GameObject greenBG;
        [SerializeField] TMP_Text dayText;
        [SerializeField] Image rewardImage;
        [SerializeField] TMP_Text rewardMultiplerText;
        [SerializeField] GameObject tickImage;

        float scaleSpeed = 1.0f;
        float minScale = 0.5f;
        float maxScale = .8f;
        Coroutine ImageScaleCoroutine;

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


        public void TodayReward()
        {
            greenBG.SetActive(true);
            ImageScaleCoroutine =  StartCoroutine(ScaleImage(rewardImage.gameObject));
        }

        public void Rewardcollected()
        {
            tickImage.SetActive(true);
            if(ImageScaleCoroutine != null)
            {
                StopCoroutine(ImageScaleCoroutine);
            }

        }

        IEnumerator ScaleImage( GameObject imageObject)
        {
            while (true)
            {
                // Scale in
                while (imageObject.transform.localScale.x < maxScale )
                {
                    imageObject.transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;
                    yield return null;
                }

                // Scale out
                while (imageObject.transform.localScale.x > minScale)
                {
                    imageObject.transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;
                    yield return null;
                }
            }
            
            
        }
    }
}
