using System;
using System.Collections.Generic;
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
        BodyWeight,
        Athlete,
        Recreational,
        CrossFit,
        Walker,
        NoTime
    }
    public enum Lifestyle
    {
        SedentaryParent = 1,
        ActiveParent,
        Student,
        YoungProfessional,
        Elderly,
        Party,
        Bodybuilder,
        Model,
        StayHomeMom,
        Single
    }
    public enum Goals
    {
        FatLoss = 1,
        BuildMuscle,
        Maintain,
        Compete,
        Tone,
        GainWeight,
        Performance
    }
}
