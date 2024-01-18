using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MOG.Roby
{
    public class LeaderCard : MonoBehaviour
    {
        [SerializeField] TMP_Text rankText;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text nameText;
        public Toggle cardSelecteingToggle;
        public string PlayerName { private set; get; }
        public int PlayerScore;

       void Start ()
        {
            cardSelecteingToggle.onValueChanged.AddListener(onCardSlected);
        }
        private void OnEnable()
        {
            EventManager.LeaderCardSelected_Event += onLeaderCardSelected;
        }
        private void OnDisable()
        {
            EventManager.LeaderCardSelected_Event -= onLeaderCardSelected;
        }


        private void onCardSlected(bool arg0)
        {
            EventManager.onLeaderCardSelected(this ,arg0);
        }


        private void onLeaderCardSelected(LeaderCard card, bool toggleState)
        {
            if (card != this)
            {
                cardSelecteingToggle.interactable = !toggleState;
            }
        }


        public void SetPlayerRank(int rank)
        {
            rankText.text =  rank.ToString();
        }

        public void SetScore(int score) 
        {
            scoreText.text = "Score:" + score.ToString();
            PlayerScore = score;
        }
        
        public void SetPlayerName(string name)
        {
            nameText.text = name.ToString();
            PlayerName = name;
        }
    }
}
