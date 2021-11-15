using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesManager.Common
{
    public static class ModelConstraints
    {
        //Student Model
        public const int NumberMinValue = 1;
        public const int NumberMaxValue = 100;

        public const int NameMinLength = 3;
        public const int NameMaxLength = 45;

        public const int EducationMinLength = 3;
        public const int EducationMaxLength = 20;

        public const int ScoreMinValue = 0;
        public const int ScoreMaxValue = 10;

        public const int CodeMaxLength = 10;
    }
}
