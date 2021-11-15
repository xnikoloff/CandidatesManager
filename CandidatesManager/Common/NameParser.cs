using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesManager.Common
{
    public class NameParser
    {
        public static string[] ParseCandidateName(string fullName)
        {
            string[] parsedNames = fullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return parsedNames;
        }

        public static string GetMiddleInitial(string middleName)
        {
            string firstLetter = middleName.Substring(0, 1);
            string middleInitial = firstLetter + ".";

            return middleInitial;
        }
    }
}
