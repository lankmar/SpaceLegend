
namespace SpaceLegend
{
    public class PlayerData
    {
        PlayerResourse playerResourse;
        PlayerAchievement playerAchievement;
        PlayerStat playerStat;

        public PlayerResourse PlayerResourse { get => playerResourse; set => playerResourse = value; }
        public PlayerAchievement PlayerAchievement { get => playerAchievement; set => playerAchievement = value; }
        public PlayerStat PlayerStat { get => playerStat; set => playerStat = value; }

        public PlayerData()
        {
            playerResourse = new PlayerResourse();
            playerAchievement = new PlayerAchievement();
            playerStat = new PlayerStat();

            playerStat.Hp = 100;
        }
    }
}