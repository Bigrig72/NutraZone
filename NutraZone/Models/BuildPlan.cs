using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone.Models
{
    public class BuildPlan
    {
        public int ID { get; set; }
        public string UserEmailID { get; set; }
        public string BodyType { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public FitnessStyle WorkoutStyle { get; set; }
        public Lifestyle LivingStyle { get; set; }
        public Goals Healthgoals { get; set; }
        public int Calories { get; set; }
        public string MedicalHistory { get; set; }
        public List<Recipe> Recipies { get; set; }
    }
    public enum FitnessStyle
    {
        Weights =1,
        Endurance,
        [Display(Name = "Body Weight")]
        BodyWeight,
        Athlete,
        Recreational,
        CrossFit,
        Walker,
        NoTime
    }
    public enum Lifestyle
    {
        [Display(Name = "Sedentary Parent")]
        SedentaryParent = 1,
        [Display(Name = "Active Parent")]
        ActiveParent,
        Student,
        [Display(Name = "Young Professional")]
        YoungProfessional,
        Elderly,
        Party,
        [Display(Name = "Body Builder")]
        Bodybuilder,
        Model,
        [Display(Name = "Stay at home mom")]
        StayHomeMom,
        Single
    }
    public enum Goals
    {
        FatLoss = 1,
        [Display(Name = "Build Muscle")]
        BuildMuscle,
        Maintain,
        Compete,
        Tone,
        [Display(Name = "Gain Weight")]
        GainWeight,
        Performance
    }
}
