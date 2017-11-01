    using System;
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Round
    {

        private List<Match> matches = new List<Match>();

        public Team oldFreeRider { get; set; }
        public Team NewFreeRider { get; set; }

        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            // TODO: Implement this method
            return null;
        }

        public bool IsRoundFinished()
        {
            for (int i = 0; i < matches.Count; i++)
            {
                
                if (matches[i].Winner == null)
                {
                    return false;
                }
            }
            return true;
        }
        
        public List<Team> GetWinningTeams()
        {
            List<Team> WinningTeams = new List<Team>(); // Kører for antal matches i liste
            for (int i = 0; i < matches.Count; i++)
            {
                WinningTeams.Add(matches[i].Winner);
            }
            return WinningTeams;


        }
      

        

        public List<Team> GetLosingTeams() //Fjern/Rediger eller flyt
        {
            List<Team> Result = new List<Team>(); // Kører for antal matches i liste
            for (int i = 0; i < matches.Count; i++)
            {
                if(matches[i].Winner == matches[i].FirstOpponent)
                {
                    Result.Add(matches[i].SecondOpponent);
                   
                }
                else
                {
                    Result.Add(matches[i].FirstOpponent);
                }
                    
            }

            return Result;
        }

        public Team GetFreeRider()
        {
             
            oldFreeRider = NewFreeRider;



            return oldFreeRider;
        }
    }
}
