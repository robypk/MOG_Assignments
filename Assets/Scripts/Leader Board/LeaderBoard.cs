using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MOG.Roby
{
    public class LeaderBoard : MonoBehaviour
    {
        public int NumberOfPlayers;
        [SerializeField] GameObject leaderCardPreFab;
        [SerializeField] Transform leaderBoardParent;
        [SerializeField] TMP_Text selectedPlayerName;
        [SerializeField] TMP_Text slectedPlayerScore;

        LeaderCard currentLeaderCard;
        List<LeaderCard> leaderCards = new List<LeaderCard>();


        void Start()
        {
            List<int> randomNumbers = GenerateRandomNumbers(NumberOfPlayers, 10000, 100000);
            randomNumbers.Sort((CurrentNum, PreviousNum ) => PreviousNum.CompareTo(CurrentNum));
            foreach (int number in randomNumbers)
            {
                var newLeadercadGO = Instantiate(leaderCardPreFab ,leaderBoardParent);
                LeaderCard newleaderCard = newLeadercadGO.GetComponent<LeaderCard>();
                leaderCards.Add(newleaderCard);
                newleaderCard.SetPlayerRank(randomNumbers.IndexOf(number) +1);
                newleaderCard.SetScore(number);
                newleaderCard.SetPlayerName("Player " + (randomNumbers.IndexOf(number) +1).ToString());
            }
        }


        private void OnEnable()
        {
            EventManager.LeaderCardSelected_Event += onLeaderCardSelected;
        }
        private void OnDisable()
        {
            EventManager.LeaderCardSelected_Event -= onLeaderCardSelected;
        }



        private void onLeaderCardSelected(LeaderCard currentCard, bool isSelected)
        {

            if (isSelected)
            {
                selectedPlayerName.text = currentCard.PlayerName;
                slectedPlayerScore.text = currentCard.PlayerScore .ToString();
                currentLeaderCard = currentCard;
            }
            else
            {
                selectedPlayerName.text = "None";
                slectedPlayerScore.text = "00000";
                currentLeaderCard = null;
            }

        }

        List<int> GenerateRandomNumbers(int count, int min, int max)
        {
            List<int> randomNumbers = new List<int>();
            System.Random random = new System.Random();

            for (int i = 0; i < count; i++)
            {
                randomNumbers.Add(random.Next(min, max + 1));
            }
            return randomNumbers;
        }


        public void ScoreIncreaseButton()
        {
            if (currentLeaderCard != null)
            {
                currentLeaderCard.PlayerScore += 100;
                currentLeaderCard.SetScore(currentLeaderCard.PlayerScore);
                slectedPlayerScore.text = currentLeaderCard.PlayerScore.ToString();
                if( leaderCards.IndexOf(currentLeaderCard) != 0)
                {
                    LeaderCard aboveLeader = leaderCards[leaderCards.IndexOf(currentLeaderCard) - 1];
                    if (aboveLeader.PlayerScore < currentLeaderCard.PlayerScore)
                    {
                        updateLeaderBoard(aboveLeader);
                    }
                }
            }


        }
        public void ScoreDecreaseButton()
        {
            if (currentLeaderCard != null)
            {
                currentLeaderCard.PlayerScore -= 100;
                currentLeaderCard.SetScore(currentLeaderCard.PlayerScore);
                slectedPlayerScore.text = currentLeaderCard.PlayerScore.ToString();
                if (leaderCards.IndexOf(currentLeaderCard) != leaderCards.Count - 1)
                {
                    LeaderCard aboveLeader = leaderCards[leaderCards.IndexOf(currentLeaderCard) + 1];
                    if (aboveLeader.PlayerScore > currentLeaderCard.PlayerScore)
                    {
                        updateLeaderBoard(aboveLeader) ;
                    }
                }
            }
        }


        private void updateLeaderBoard(LeaderCard aboveLeader)
        {
            currentLeaderCard.transform.SetSiblingIndex(leaderCards.IndexOf(aboveLeader));
            leaderCards.Sort((CurrentNum, PreviousNum) => PreviousNum.PlayerScore.CompareTo(CurrentNum.PlayerScore));
            currentLeaderCard.SetPlayerRank(currentLeaderCard.transform.GetSiblingIndex() + 1);
            aboveLeader.SetPlayerRank(aboveLeader.transform.GetSiblingIndex() + 1);
        }
    }
}
