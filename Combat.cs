using System;
using System.Collections.Generic;
using System.Text;

namespace Pokeapp
{
    public class Combat
    {
        private static Combat log = new Combat();
        private Combat() { }

        public static Combat Log
        {
            get => log;
        }

        //string combatLog = "";

        List<string> combatLogEntries;
        int entryNumber = 1;

        public void StartNewRound()
        {
            combatLogEntries = new List<string>(); //Liste! :-) Ikke array. Javascript har ikke arrays. 
        }

        public void AddToLog(string newLogEntry)
        {
            string nextEntry = entryNumber.ToString() + ": " + newLogEntry;
            combatLogEntries.Add(nextEntry); //Legger til ny entry hver gang noen attacker eller tar skade
            entryNumber++;
        }

        public void PrintLogToConsole()
        {
            foreach (string entry in combatLogEntries)
                Console.WriteLine(entry);
        }

        public void AddLogLineBreak(int numberOfLineBreaks)
        {
            for (int i = 0; i < numberOfLineBreaks; i++)
                combatLogEntries.Add(" ");            
        }
        
        public void WinnerLog(string winMessage)
        {
            AddLogLineBreak(2);
            combatLogEntries.Add("######################");
            combatLogEntries.Add(winMessage);
            combatLogEntries.Add("######################");
        }
    }
}
