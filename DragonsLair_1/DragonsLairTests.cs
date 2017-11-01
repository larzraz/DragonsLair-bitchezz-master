﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonsLair_1
{
    [TestClass]
    public class DragonsLairTests
    {
        Tournament currentTournament;
        

        [TestInitialize]
        public void SetupForTest()
        {
            currentTournament = new Tournament("Vinter Turnering");
            
        }

        [TestMethod]
        public void TournamentHasEvenNumberOfTeams()
        {
            int numberOfTeams = currentTournament.GetTeams().Count;
            Assert.AreEqual(0, numberOfTeams % 2);
        }

        [TestMethod]
        public void EqualNumberOfWinnersAndLosersPerRound()
        {
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds -1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
                int numberOfLosingTeams = currentRound.GetLosingTeams().Count();
                Assert.AreEqual(numberOfWinningTeams, numberOfLosingTeams);
            }
        }

        [TestMethod]
        public void OneWinnerInLastRound()
        {
            // Verifies there is exactly one winner in last round
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            Round currentRound = currentTournament.GetRound(numberOfRounds - 1);
            int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
            Assert.AreEqual(1, numberOfWinningTeams);
        }

        [TestMethod]
        public void AllMatchesInPreviousRoundsFinished()
        {
            bool matchesFinished = true;
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds - 1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                if (currentRound.IsRoundFinished() == false)
                    matchesFinished = false;
            }
            Assert.AreEqual(true, matchesFinished);
        }
        [TestMethod]
        public void ShouldSayAllRoundsAreFinished()
        {
            Controller controller = new Controller();
            
            controller.ScheduleNewRound("Vinter Turnering", true);
        
            Assert.AreEqual(true,currentTournament.SetStatusFinished(status));
        }
    }
}