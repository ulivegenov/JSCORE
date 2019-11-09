namespace P03_FootballBetting.Data.Models
{
    using P03_FootballBetting.Data.Models.Enums;
    using System;

    //BetId, Amount, Prediction, DateTime, UserId, GameId

    public class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public BetPrediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
