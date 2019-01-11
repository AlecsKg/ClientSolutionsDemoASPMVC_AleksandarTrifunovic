namespace EfLib
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EfLib;

    public partial class ModelEF : DbContext
    {
        public ModelEF()
            : base("name=ModelEF")
        {
        }

        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<ProblemSolution> ProblemSolutions { get; set; }
        public virtual DbSet<TypeOfRequest> TypeOfRequests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        
    }
}
