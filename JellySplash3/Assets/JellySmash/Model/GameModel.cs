using JellySmash.Model.Interface;
using UnityEngine;

namespace JellySmash.Model
{
    public class GameModel : MonoBehaviour, IGameModel
    {
        public int CurrentLevel { get; set; }
        public int TargetScore { get; private set; }
        public int PlayerScore { get; private set; }

        public bool IsTargetAchieved
        {
            get
            {
                return (PlayerScore >= TargetScore);
            }
        }

        public void SavePlayerScore(int score)
        {
            PlayerScore = score;
        }

        public void SaveLevelTargetScore(int targetScore)
        {
            TargetScore = targetScore;
        }
    }
}
