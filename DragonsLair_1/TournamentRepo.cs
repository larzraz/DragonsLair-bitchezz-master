using System.Collections.Generic;

namespace DragonsLair_1
{
    class TournamentRepo
    {
        public Tournament winterTournament = new Tournament("Vinter Turnering");
        
        public Tournament GetTournament(string name)
        {
            if (name == "Vinter Turnering")
            {
                return winterTournament;
            }
            return null;
        }
    }
}