using Microsoft.EntityFrameworkCore;
using SalaryCalculation.Models;

namespace SalaryCalculation.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = Guid.Parse("1ae09909-2874-41c9-8203-48c2a0558f14"),
                Name = "Tom",
                PositionId = Guid.Parse("dbf707ca-c9e2-423e-866a-0ede1cbf70b9"),
                EmploymentDate = new DateTime(2019, 01, 01)
            },
            new Employee
            {
                Id = Guid.Parse("14642900-db07-4563-9144-e24da22537b8"),
                Name = "John",
                PositionId = Guid.Parse("eb2a7c49-cea4-4814-8ad0-44e9e32d3a19"),
                EmploymentDate = new DateTime(2015, 05, 10)
            });

            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = Guid.Parse("dbf707ca-c9e2-423e-866a-0ede1cbf70b9"),
                Title = "Technician",
            },
            new Position
            {
                Id = Guid.Parse("eb2a7c49-cea4-4814-8ad0-44e9e32d3a19"),
                Title = "Sales",
            });

            modelBuilder.Entity<BaseSalary>().HasData(new BaseSalary
            {
                Id = Guid.Parse("71fb91cf-7a47-4c84-9869-6300ee8ea3de"),
                PositionId = Guid.Parse("dbf707ca-c9e2-423e-866a-0ede1cbf70b9"),
                MinExperience = 0,
                Salary = 1000
            },
            new BaseSalary
            {
                Id = Guid.Parse("8c105fdb-79c0-4c17-8597-eb73165f1f13"),
                PositionId = Guid.Parse("dbf707ca-c9e2-423e-866a-0ede1cbf70b9"),
                MinExperience = 3,
                Salary = 1200
            },
            new BaseSalary
            {
                Id = Guid.Parse("74e7d85f-114a-4053-8d4b-eca9a70ba4dc"),
                PositionId = Guid.Parse("dbf707ca-c9e2-423e-866a-0ede1cbf70b9"),
                MinExperience = 6,
                Salary = 1520
            },
            new BaseSalary
            {
                Id = Guid.Parse("35c5f014-80dd-4e2f-a4fd-b80a3d1535cc"),
                PositionId = Guid.Parse("eb2a7c49-cea4-4814-8ad0-44e9e32d3a19"),
                MinExperience = 0,
                Salary = 1100
            },
            new BaseSalary
            {
                Id = Guid.Parse("c959aa32-2d97-4d72-bfdf-4c6b26029f83"),
                PositionId = Guid.Parse("eb2a7c49-cea4-4814-8ad0-44e9e32d3a19"),
                MinExperience = 3,
                Salary = 1400
            },
            new BaseSalary
            {
                Id = Guid.Parse("4170fd05-ccac-47d2-bafb-33fe6c84370a"),
                PositionId = Guid.Parse("eb2a7c49-cea4-4814-8ad0-44e9e32d3a19"),
                MinExperience = 7,
                Salary = 1650
            });

            modelBuilder.Entity<SatisfactionScore>().HasData(new SatisfactionScore
            {
                Id = Guid.Parse("a853a8ff-1e68-48cc-9f00-091256a9ee9e"),
                EmployeeId = Guid.Parse("1ae09909-2874-41c9-8203-48c2a0558f14"),
                Year = 2020,
                ScoreId = Guid.Parse("73615786-2125-45db-8cf4-46992eb9cb5a")

            },
            new SatisfactionScore
            {
                Id = Guid.Parse("88a6cf90-afde-41ec-a0bf-d12a505eba0d"),
                EmployeeId = Guid.Parse("1ae09909-2874-41c9-8203-48c2a0558f14"),
                Year = 2021,
                ScoreId = Guid.Parse("1ea40317-9f17-4086-98fa-77ab46fb6134")

            },
            new SatisfactionScore
            {
                Id = Guid.Parse("55b9f624-a948-483c-985d-7106ec1360f1"),
                EmployeeId = Guid.Parse("1ae09909-2874-41c9-8203-48c2a0558f14"),
                Year = 2022,
                ScoreId = Guid.Parse("620d317a-78df-4a12-a1b3-b448db307acb")

            },
            new SatisfactionScore
            {
                Id = Guid.Parse("b566edde-3523-41c7-8391-51c7adf072df"),
                EmployeeId = Guid.Parse("14642900-db07-4563-9144-e24da22537b8"),
                Year = 2020,
                ScoreId = Guid.Parse("73615786-2125-45db-8cf4-46992eb9cb5a")

            },
            new SatisfactionScore
            {
                Id = Guid.Parse("59c5a3b6-5775-4e11-9b4e-79134b6b6dfd"),
                EmployeeId = Guid.Parse("14642900-db07-4563-9144-e24da22537b8"),
                Year = 2021,
                ScoreId = Guid.Parse("3784a1b8-1ce2-47ce-a483-0cd3a3a1e272")

            },
            new SatisfactionScore
            {
                Id = Guid.Parse("a0dcc41a-99ae-4d17-bf0f-4b4eb10d49ec"),
                EmployeeId = Guid.Parse("14642900-db07-4563-9144-e24da22537b8"),
                Year = 2022,
                ScoreId = Guid.Parse("620d317a-78df-4a12-a1b3-b448db307acb")

            }
            );

            modelBuilder.Entity<Score>().HasData(new Score
            {
                Id = Guid.Parse("98bd9378-a9d9-4b33-a6a4-a93a6cc92560"),
                Value = 0,
                Bonus = 1.0
            },
            new Score
            {
                Id = Guid.Parse("73615786-2125-45db-8cf4-46992eb9cb5a"),
                Value = 1,
                Bonus = 1.0
            },
            new Score
            {
                Id = Guid.Parse("3784a1b8-1ce2-47ce-a483-0cd3a3a1e272"),
                Value = 2,
                Bonus = 1.02
            },
            new Score
            {
                Id = Guid.Parse("1ea40317-9f17-4086-98fa-77ab46fb6134"),
                Value = 3,
                Bonus = 1.07
            },
            new Score
            {
                Id = Guid.Parse("2e6356ba-960e-4fd3-9a67-43e90a8600bb"),
                Value = 4,
                Bonus = 1.15
            },
            new Score
            {
                Id = Guid.Parse("620d317a-78df-4a12-a1b3-b448db307acb"),
                Value = 5,
                Bonus = 1.2
            });
        }
    }
}
