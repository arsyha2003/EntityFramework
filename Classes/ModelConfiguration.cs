using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Classes
{
    internal class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> modelBuilder)
        {
            ////параметры полей
            //modelBuilder.ToTable("NewGames");//поменять название таблицы
            //modelBuilder.Property(p => p.Style).HasColumnName("TypeOfGame");//поменять название определенного поля
            //modelBuilder.Ignore(p => p.CountOfCopies);//игнорировать поле в базе данных
            //modelBuilder.Property(p => p.CountOfCopies).IsRequired();//исключить Nullable значения по переменной
            //modelBuilder.HasKey(p => p.Id);//установить первичный ключ любому полю
            //modelBuilder.Property(p => p.NameOfGame).HasField("nameOfGame");//настройка взаимодействия readonly полей

            ////ограничения полей (constraint)
            //modelBuilder.Property(p => p.Style).HasDefaultValue("DefaultStyle");//установление дефолтного значения
            //modelBuilder.Property(p => p.Style).HasMaxLength(30);//установление ограничения длины строкового значения
            //modelBuilder.HasAlternateKey(p => p.GameMode);//вторичный ключ (unique)
            //modelBuilder.ToTable(p => p.HasCheckConstraint("CountOfCopies", "CountOfCopies>50"));//check constraint

            //заполнение таблицы
            modelBuilder.HasData(new Model()
            {
                Id = 1,
                NameOfGame = "NewGame",
                Company = "GamesINC",
                Style = "Shooter",
                DateOfPublication = DateTime.Now,
                GameMode = "Multiplayer",
                CountOfCopies = 100
            });
            modelBuilder.HasData(new Model()
            {
                Id = 2,
                NameOfGame = "UltraKill",
                Company = "TopGames",
                Style = "Shooter",
                DateOfPublication = DateTime.Now,
                GameMode = "SinglePlayer/MultiPlayer",
                CountOfCopies = 1000
            });modelBuilder.HasData(new Model()
            {
                Id = 3,
                NameOfGame = "Ultraqweqweqwe",
                Company = "TopGames",
                Style = "Shooter",
                DateOfPublication = DateTime.Now,
                GameMode = "SinglePlayer",
                CountOfCopies = 1500
            });
        }
    }
}
