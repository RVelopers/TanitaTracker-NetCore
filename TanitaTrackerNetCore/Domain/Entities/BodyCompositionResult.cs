namespace Domain.Entities
{
    public class BodyCompositionResult : SoftDeletableEntity
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { get; set; } 

        public User User { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public decimal Weight { get; set; } 

        /// <summary>
        /// Gets or sets the bmi.
        /// </summary>
        /// <value>The bmi.</value>
        public decimal BMI { get; set; }

        /// <summary>
        /// Gets or sets the BMIL evel.
        /// </summary>
        /// <value>The BMIL evel.</value>
        public Level BMILevel { get; set; }

        /// <summary>
        /// Gets or sets the fat percentage.
        /// </summary>
        /// <value>The fat percentage.</value>
        public decimal FatPercentage { get; set; }

        /// <summary>
        /// Gets or sets the fat level.
        /// </summary>
        /// <value>The fat level.</value>
        public Level FatLevel { get; set; }

        /// <summary>
        /// Gets or sets the muscle percentage.
        /// </summary>
        /// <value>The muscle percentage.</value>
        public decimal MusclePercentage { get; set; }

        /// <summary>
        /// Gets or sets the muscle level.
        /// </summary>
        /// <value>The muscle level.</value>
        public Level MuscleLevel { get; set; }

        /// <summary>
        /// Gets or sets the viceral fat.
        /// </summary>
        /// <value>The viceral fat.</value>
        public int ViceralFat { get; set; }

        /// <summary>
        /// Gets or sets the viceral fat level.
        /// </summary>
        /// <value>The viceral fat level.</value>
        public Level ViceralFatLevel { get; set; }

        /// <summary>
        /// Gets or sets the rm kcal.
        /// </summary>
        /// <value>The rm kcal.</value>
        public int RmKcal { get; set; }

        /// <summary>
        /// Gets or sets the metabolic age.
        /// </summary>
        /// <value>The metabolic age.</value>
        public int MetabolicAge { get; set; }
    }
}
