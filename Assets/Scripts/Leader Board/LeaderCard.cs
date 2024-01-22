using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MOG.Roby
{
    public struct PlayerDetails
    {
        public string Name;
        public int Score;
        public int Rank;
    }
    public class LeaderCard : MonoBehaviour
    {

        public PlayerDetails PlayerDetails = new PlayerDetails();
        [SerializeField] TMP_Text rankText;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text nameText;
        public Toggle CardSelecteingToggle;
        [HideInInspector] public string PlayerName { private set; get; }
        [HideInInspector]public int PlayerScore;

        void Start ()
        {
            CardSelecteingToggle.onValueChanged.AddListener(onCardSlected);
        }
        private void OnEnable()
        {
            EventManager.LeaderCardSelected_Event += onLeaderCardSelected;
        }
        private void OnDisable()
        {
            EventManager.LeaderCardSelected_Event -= onLeaderCardSelected;
        }


        private void onCardSlected(bool isSelected)
        {
            EventManager.onLeaderCardSelected(this ,isSelected);
        }


        private void onLeaderCardSelected(LeaderCard card, bool isSelected)
        {
            if (card != this)
            {
                CardSelecteingToggle.interactable = !isSelected;
            }
        }


        public void SetPlayerRank(int rank)
        {
            rankText.text =  rank.ToString();
            PlayerDetails.Rank = rank;
        }

        public void SetScore(int score) 
        {
            scoreText.text = "Score:" + score.ToString();
            PlayerScore = score;
            PlayerDetails.Score = score;
        }
        
        public void SetPlayerName(string name)
        {
            nameText.text = name.ToString();
            PlayerName = name;
            PlayerDetails.Name = name;
        }
    }
}
