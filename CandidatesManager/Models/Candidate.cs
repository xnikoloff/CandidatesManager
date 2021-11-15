using CandidatesManager.Common;
using CandidatesManager.Enumerables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesManager.Models
{
    public class Candidate
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Number { get; set; }

        [Required]
        [MinLength(ModelConstraints.NameMinLength)]
        [MaxLength(ModelConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ModelConstraints.EducationMinLength)]
        [MaxLength(ModelConstraints.EducationMaxLength)]
        public string Education { get; set; }

        [Required]
        [Range(ModelConstraints.ScoreMinValue, ModelConstraints.ScoreMaxValue)]
        public int Score { get; set; }

        //[Required]
        public Department Department { get; set; }

        /*[Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]*/
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(ModelConstraints.CodeMaxLength)]
        public string Code { get; set; }
    }
}
