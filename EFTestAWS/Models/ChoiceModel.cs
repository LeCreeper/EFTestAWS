namespace EFTestAWS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChoiceModel : DbContext
    {
        public ChoiceModel()
            : base("name=ChoiceModel")
        {
        }

        public virtual DbSet<ButtonData> ButtonData { get; set; }
        public virtual DbSet<PageData> PageData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageData>()
                .HasMany(e => e.ButtonData)
                .WithOptional(e => e.PageData1)
                .HasForeignKey(e => e.PageData);
        }
    }
}
