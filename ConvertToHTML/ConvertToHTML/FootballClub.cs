using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToHTML
{
    class FootballClub
    {
        public string FootballClubName { get; set; }
        public int ClubEstablishmentYear { get; set; }
        public int LocalChampionshipWinner { get; set; }
        public int ChampionsLigueWinner { get; set; }

        public FootballClub(string club, int year, int localwins, int champLiguewins)
        {
            FootballClubName = club;
            ClubEstablishmentYear = year;
            LocalChampionshipWinner = localwins;
            ChampionsLigueWinner = champLiguewins;
        }

        public override string ToString()
        {
            return string.Format($"Name: {FootballClubName} " +
                $"\nYear: {ClubEstablishmentYear} " +
                $"\nLocal Championship Winner: {LocalChampionshipWinner} " +
                $"\nChampions Ligue Winner: {ChampionsLigueWinner}");
        }
    }
}
