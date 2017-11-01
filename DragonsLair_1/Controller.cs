using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        TournamentRepo tournamentRepo = new TournamentRepo();

       
        public void ShowScore(string tournamentName)
        {
            int winnerPoint = 1;
          
          
           Tournament t = tournamentRepo.GetTournament(tournamentName);          
          
            Dictionary<string, int> teamDictionary = new Dictionary<string, int>();

            for (int i = 0; i < t.GetNumberOfRounds(); i++)
            {
                Round currentRound = t.GetRound(i);
                List<Team> winningTeams = currentRound.GetWinningTeams();
                List<Team> loosingTeams = t.GetRound(0).GetLosingTeams();

                foreach (Team winningTeam in winningTeams)
                {
                    
                    if (teamDictionary.ContainsKey(winningTeam.name))
                    {
                        if (teamDictionary.TryGetValue(winningTeam.name, out int number))
                        {
                            winnerPoint = number + 1;
                            teamDictionary.Remove(winningTeam.name);
                        }
                    }
                    teamDictionary.Add(winningTeam.name, winnerPoint);
                }
           
            }

            
            
            Console.WriteLine("Scoreboard");
            var sortedList = teamDictionary.OrderByDescending(x => x.Value);

            foreach (var key in sortedList)
            {
                Console.WriteLine("{1}  {0}", key.Key, key.Value);
            }

        }
        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            Tournament t = tournamentRepo.GetTournament(tournamentName);
            int numberOfRound = t.GetNumberOfRounds();

            if (numberOfRound == 0)
            {
                List<Team> teams = t.GetTeams();

            }
            else
            {
                 Round lastRound = t.GetRound(numberOfRound - 1);
                bool isRoundFinished = lastRound.IsRoundFinished();

                if (isRoundFinished == true)
                {
                    List<Team> teams = lastRound.GetWinningTeams();
                    if (teams.Count >= 2)
                    {

                        var rnd = new Random();
                        rnd.NextDouble();
                        Dictionary<Team, double> RandomList = new Dictionary<Team, double>();

                        foreach (Team team in lastRound.GetWinningTeams())
                        {
                            RandomList.Add(team, rnd.NextDouble());
                        }
                        RandomList.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                        List<Team> randomList = RandomList.Keys.ToList();

                        Round newRound = new Round();
                        if (teams.Count % 2 == 1)
                        {

                           Team newFreeRider = randomList.Min();
                            Team oldFreeRider = newRound.GetFreeRider();
                            do {
                                newFreeRider = randomList.Min();

                                randomList.Remove(newFreeRider);
                            }
                            while (oldFreeRider == newFreeRider);

                            newRound.NewFreeRider = newFreeRider;
                        }
                        int noMatches = teams.Count / 2;

                        for (int i = 1; i <= noMatches; i++)
                        {
                            Match match = new Match();
                            foreach (Team team in randomList)
                            {
                                Team first;
                                Team second;



                                first = team;
                                randomList.Remove(team);
                                second = team;
                                randomList.Remove(team);
                                match.FirstOpponent = first;
                                match.SecondOpponent = second;
                                newRound.AddMatch(match);
                            }
                        }
                       
                        t.addRound(newRound);

                        Console.WriteLine("Ny runde tilføjet");
                        Console.ReadKey();
                    }
                    else
                        t.SetStatusFinished(true);
                    Console.WriteLine("Turneringen er overstået");
                    Console.ReadKey();
                    //test


                }
            }
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}

