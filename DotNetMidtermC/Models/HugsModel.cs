namespace DotNetMidtermC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HugsModel : DbContext
    {
        public HugsModel()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Hug> Hugs { get; set; }
        public virtual DbSet<HugType> HugTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hug>()
                .Property(e => e.Hugee)
                .IsUnicode(false);

            modelBuilder.Entity<HugType>()
                .Property(e => e.HugType1)
                .IsUnicode(false);
        }
    }
}
