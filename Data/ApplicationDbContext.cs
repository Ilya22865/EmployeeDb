using System;
using Microsoft.EntityFrameworkCore;
using ProjectPractika.Models;

namespace ProjectPractika.Data;

public class ApplicationDbContext : DbContext {
    public DbSet<Employee>? Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source = Employee.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, FirstName = "Ilya", LastName = "Gribanov", Department = "Develop", Salary = 2000, DateOfBirth = new DateTime(2007, 09, 18), DateOfEmployment = new DateTime(2025, 11, 18), Email = "hribanov444@gmail.com" },
new Employee { Id = 2, FirstName = "Anna", LastName = "Petrova", Department = "HR", Salary = 1850, DateOfBirth = new DateTime(1995, 04, 12), DateOfEmployment = new DateTime(2023, 06, 01), Email = "anna.petrova@company.ru" },
new Employee { Id = 3, FirstName = "Mikhail", LastName = "Sokolov", Department = "Develop", Salary = 3200, DateOfBirth = new DateTime(1990, 11, 25), DateOfEmployment = new DateTime(2021, 03, 15), Email = "mikhail.sokolov@company.ru" },
new Employee { Id = 4, FirstName = "Daria", LastName = "Kuznetsova", Department = "Design", Salary = 2400, DateOfBirth = new DateTime(1998, 07, 30), DateOfEmployment = new DateTime(2024, 02, 10), Email = "daria.kuznetsova@company.ru" },
new Employee { Id = 5, FirstName = "Alexei", LastName = "Orlov", Department = "Develop", Salary = 2800, DateOfBirth = new DateTime(1993, 02, 14), DateOfEmployment = new DateTime(2022, 09, 05), Email = "alexei.orlov@company.ru" },
new Employee { Id = 6, FirstName = "Ekaterina", LastName = "Morozova", Department = "HR", Salary = 1950, DateOfBirth = new DateTime(1996, 08, 22), DateOfEmployment = new DateTime(2023, 11, 20), Email = "ekaterina.morozova@company.ru" },
new Employee { Id = 7, FirstName = "Pavel", LastName = "Volkov", Department = "Design", Salary = 2600, DateOfBirth = new DateTime(1994, 05, 17), DateOfEmployment = new DateTime(2022, 07, 12), Email = "pavel.volkov@company.ru" },
new Employee { Id = 8, FirstName = "Sofia", LastName = "Lebedeva", Department = "Develop", Salary = 3500, DateOfBirth = new DateTime(1989, 12, 03), DateOfEmployment = new DateTime(2020, 04, 28), Email = "sofia.lebedeva@company.ru" },
new Employee { Id = 9, FirstName = "Igor", LastName = "Fedorov", Department = "HR", Salary = 1750, DateOfBirth = new DateTime(2001, 01, 09), DateOfEmployment = new DateTime(2025, 03, 15), Email = "igor.fedorov@company.ru" },
new Employee { Id = 10, FirstName = "Viktoria", LastName = "Nikolaeva", Department = "Design", Salary = 2300, DateOfBirth = new DateTime(1997, 10, 26), DateOfEmployment = new DateTime(2024, 08, 01), Email = "viktoria.nikolaeva@company.ru" },
new Employee { Id = 11, FirstName = "Nikolai", LastName = "Smirnov", Department = "Develop", Salary = 3100, DateOfBirth = new DateTime(1991, 06, 14), DateOfEmployment = new DateTime(2021, 10, 05), Email = "nikolai.smirnov@company.ru" },
new Employee { Id = 12, FirstName = "Alina", LastName = "Popova", Department = "Design", Salary = 2250, DateOfBirth = new DateTime(1999, 03, 28), DateOfEmployment = new DateTime(2024, 05, 17), Email = "alina.popova@company.ru" },
new Employee { Id = 13, FirstName = "Roman", LastName = "Kozlov", Department = "HR", Salary = 1800, DateOfBirth = new DateTime(1997, 09, 11), DateOfEmployment = new DateTime(2023, 08, 22), Email = "roman.kozlov@company.ru" },
new Employee { Id = 14, FirstName = "Tatiana", LastName = "Vasilieva", Department = "Develop", Salary = 2950, DateOfBirth = new DateTime(1994, 12, 07), DateOfEmployment = new DateTime(2022, 11, 30), Email = "tatiana.vasilieva@company.ru" },
new Employee { Id = 15, FirstName = "Artem", LastName = "Novikov", Department = "Design", Salary = 2550, DateOfBirth = new DateTime(1996, 04, 19), DateOfEmployment = new DateTime(2023, 01, 15), Email = "artem.novikov@company.ru" },
new Employee { Id = 16, FirstName = "Yulia", LastName = "Mikhailova", Department = "HR", Salary = 1900, DateOfBirth = new DateTime(1993, 08, 03), DateOfEmployment = new DateTime(2022, 04, 10), Email = "yulia.mikhailova@company.ru" },
new Employee { Id = 17, FirstName = "Denis", LastName = "Frolov", Department = "Develop", Salary = 3300, DateOfBirth = new DateTime(1988, 02, 25), DateOfEmployment = new DateTime(2020, 07, 20), Email = "denis.frolov@company.ru" },
new Employee { Id = 18, FirstName = "Anastasia", LastName = "Zaitseva", Department = "Design", Salary = 2450, DateOfBirth = new DateTime(1995, 11, 14), DateOfEmployment = new DateTime(2023, 09, 01), Email = "anastasia.zaitseva@company.ru" },
new Employee { Id = 19, FirstName = "Vladimir", LastName = "Semenov", Department = "Develop", Salary = 2700, DateOfBirth = new DateTime(1992, 01, 30), DateOfEmployment = new DateTime(2021, 12, 08), Email = "vladimir.semenov@company.ru" },
new Employee { Id = 20, FirstName = "Olga", LastName = "Pavlova", Department = "HR", Salary = 1820, DateOfBirth = new DateTime(2000, 05, 22), DateOfEmployment = new DateTime(2024, 10, 14), Email = "olga.pavlova@company.ru" },
new Employee { Id = 21, FirstName = "Sergei", LastName = "Kozlov", Department = "Develop", Salary = 3050, DateOfBirth = new DateTime(1990, 07, 16), DateOfEmployment = new DateTime(2021, 02, 25), Email = "sergei.kozlov@company.ru" },
new Employee { Id = 22, FirstName = "Ksenia", LastName = "Sorokina", Department = "Design", Salary = 2350, DateOfBirth = new DateTime(1998, 10, 09), DateOfEmployment = new DateTime(2024, 03, 12), Email = "ksenia.sorokina@company.ru" },
new Employee { Id = 23, FirstName = "Ivan", LastName = "Volkov", Department = "HR", Salary = 1780, DateOfBirth = new DateTime(1999, 12, 05), DateOfEmployment = new DateTime(2024, 07, 30), Email = "ivan.volkov@company.ru" },
new Employee { Id = 24, FirstName = "Polina", LastName = "Kuzmina", Department = "Develop", Salary = 2850, DateOfBirth = new DateTime(1993, 04, 27), DateOfEmployment = new DateTime(2022, 06, 18), Email = "polina.kuzmina@company.ru" },
new Employee { Id = 25, FirstName = "Maxim", LastName = "Zakharov", Department = "Design", Salary = 2650, DateOfBirth = new DateTime(1994, 09, 02), DateOfEmployment = new DateTime(2023, 04, 05), Email = "maxim.zakharov@company.ru" },
new Employee { Id = 26, FirstName = "Elena", LastName = "Sokolova", Department = "HR", Salary = 1880, DateOfBirth = new DateTime(1996, 02, 14), DateOfEmployment = new DateTime(2023, 12, 01), Email = "elena.sokolova@company.ru" },
new Employee { Id = 27, FirstName = "Andrei", LastName = "Lebedev", Department = "Develop", Salary = 3400, DateOfBirth = new DateTime(1987, 11, 20), DateOfEmployment = new DateTime(2020, 01, 15), Email = "andrei.lebedev@company.ru" },
new Employee { Id = 28, FirstName = "Valeria", LastName = "Guseva", Department = "Design", Salary = 2500, DateOfBirth = new DateTime(1997, 06, 08), DateOfEmployment = new DateTime(2024, 01, 20), Email = "valeria.guseva@company.ru" },
new Employee { Id = 29, FirstName = "Timur", LastName = "Belyaev", Department = "Develop", Salary = 2900, DateOfBirth = new DateTime(1995, 03, 11), DateOfEmployment = new DateTime(2023, 07, 10), Email = "timur.belyaev@company.ru" },
new Employee { Id = 30, FirstName = "Natalia", LastName = "Vinogradova", Department = "HR", Salary = 1920, DateOfBirth = new DateTime(1998, 08, 25), DateOfEmployment = new DateTime(2024, 11, 05), Email = "natalia.vinogradova@company.ru" }
        );
    }
}