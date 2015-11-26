namespace SharePointProviderHostedWeb.Models
{
    public class Rootobject
    {
        public Abstractcachewebrootelement abstractCacheWebRootElement { get; set; }
    }

    public class Abstractcachewebrootelement
    {
        public Totalscorers totalScorers { get; set; }
        public Leaguetable leagueTable { get; set; }
        public object competitionId { get; set; }
        public Staticdata staticData { get; set; }
    }

    public class Totalscorers
    {
        public Stat[] stats { get; set; }
        public int competitionId { get; set; }
        public object staticData { get; set; }
    }

    public class Stat
    {
        public Value[] values { get; set; }
        public string statName { get; set; }
    }

    public class Value
    {
        public string value { get; set; }
        public int rank { get; set; }
        public string statName { get; set; }
        public object nation { get; set; }
        public int playerId { get; set; }
        public string displayPlayerMobileName { get; set; }
        public string displayPlayerDesktopName { get; set; }
        public string clubURLName { get; set; }
        public string displayTeamName { get; set; }
        public string displayTeamShortname { get; set; }
    }

    public class Leaguetable
    {
        public Entry[] entries { get; set; }
        public int competitionId { get; set; }
        public object staticData { get; set; }
    }

    public class Entry
    {
        public Total total { get; set; }
        public Home home { get; set; }
        public int rank { get; set; }
        public int lastRank { get; set; }
        public string clubURLName { get; set; }
        public string movement { get; set; }
        public Away away { get; set; }
        public string displayTeamName { get; set; }
        public string displayTeamShortname { get; set; }
        public string displayTeamFullname { get; set; }
    }

    public class Total
    {
        public int points { get; set; }
        public int played { get; set; }
        public int won { get; set; }
        public int lost { get; set; }
        public int drawn { get; set; }
        public int goalDifference { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
    }

    public class Home
    {
        public int points { get; set; }
        public int played { get; set; }
        public int won { get; set; }
        public int lost { get; set; }
        public int drawn { get; set; }
        public int goalDifference { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
    }

    public class Away
    {
        public int points { get; set; }
        public int played { get; set; }
        public int won { get; set; }
        public int lost { get; set; }
        public int drawn { get; set; }
        public int goalDifference { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
    }

    public class Staticdata
    {
        public int seasonId { get; set; }
        public int competitionId { get; set; }
        public string seasonName { get; set; }
        public object[] languageMappings { get; set; }
        public string i18NLanguage { get; set; }
        public object startYear { get; set; }
        public object endYear { get; set; }
        public int currentGameWeek { get; set; }
        public string generatedDate { get; set; }
        public string seasonLongName { get; set; }
    }

}
