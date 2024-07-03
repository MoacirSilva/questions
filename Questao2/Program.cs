using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json.Nodes;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    
    public static int getTotalScoredGoals(string team, int year)
    {
        int total = 0;
        //Home and Guest
        for (int i = 1; i <= 2; i++)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team{i}={team}"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            dynamic partidas = JsonConvert.DeserializeObject(jsonString);
            int json = 0;
            int totalTeam = 0;
            int pages = 0;
            pages = partidas.total_pages;
            for (int j = 1; j <= pages; j++)
            {
                WebReq = (HttpWebRequest)WebRequest.Create(string.Format($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team{i}={team}&page={j}"));

                WebReq.Method = "GET";

                WebResp = (HttpWebResponse)WebReq.GetResponse();

                using (Stream stream = WebResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                partidas = JsonConvert.DeserializeObject(jsonString);
                foreach (dynamic item in partidas.data)
                {
                    json = i == 1?item.team1goals: item.team2goals;
                    totalTeam += json;
                }
            }
            total += totalTeam; 
        }              

        return total;
    }

}