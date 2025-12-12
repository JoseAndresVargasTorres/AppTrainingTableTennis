namespace TableTennisApi.Models

{
    public class Exercise
    {
        
        public int Id{get;set;}
        public string Name {get;set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Category {get;set;}  = string.Empty;
        public int DurationMinutes {get;set;} 
        public string DifficultyLevel {get;set;} = string.Empty;
        public string? AdditionalNotes {get;set;} 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();


    }



}