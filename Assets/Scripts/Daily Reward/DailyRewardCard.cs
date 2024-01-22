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
        [SerializeField] Sprite rewardSprite;
        [SerializeField] public int Day;
        [SerializeField] int rewardMultipler;


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
        Coroutine imageScaleCoroutine;

        void Awake()
        {
            Init();
        }

        private void Init()
        {
            dayText.text = "Day " + Day;
            rewardMultiplerText.text = rewardMultipler + "X";
            rewardImage.sprite = rewardSprite;
        } 


        public void TodayReward()
        {
            greenBG.SetActive(true);
            imageScaleCoroutine =  StartCoroutine(ScaleImage(rewardImage.gameObject));
        }

        public void Rewardcollected()
        {
            tickImage.SetActive(true);
            if(imageScaleCoroutine != null)
            {
                StopCoroutine(imageScaleCoroutine);
            }

        }

        IEnumerator ScaleImage( GameObject imageObject)
        {
            while (true)
            {
                while (imageObject.transform.localScale.x < maxScale )
                {
                    imageObject.transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;
                    yield return null;
                }

                while (imageObject.transform.localScale.x > minScale)
                {
                    imageObject.transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;
                    yield return null;
                }
            }
            
            
        }
    }
}
