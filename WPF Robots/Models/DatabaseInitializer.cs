using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Robots.Models
{
   public static class DatabaseInitializer
{
    public static void Initialize(RobotContext context)
    {
        context.Database.EnsureCreated();

        if (context.Robots.Any())
        {
            return;  
        }

            var robots = new List<Robot>
            {
                new Robot { Id = 1, Name = "Chiron", Status = "W trakcie akcji", BatteryLevel = 100, Lokalizacja = "USM 201", Pozycja = "bezpieczna" , Magazyn = "(Dostępny do pracy)" , Stan = "W trakcjie akcji"  },
                new Robot { Id = 2, Name = "Robot 1", Status = "Dostępny", BatteryLevel = 80, Lokalizacja = "USM 201", Pozycja = "bezpieczna"  , Magazyn = "(Dostępny do pracy)" , Stan = "W trakcjie akcji" },
                new Robot { Id = 3, Name = "Robot 2", Status = "Niedostępny zajęty", BatteryLevel = 60, Lokalizacja = "USM 201", Pozycja = "bezpieczna"  , Magazyn = "(Zadokowany)" , Stan = "W trakcjie akcji" },
                new Robot { Id = 4, Name = "Robot 3", Status = "Niedostępny Potrzebny asystent", BatteryLevel = 60, Lokalizacja = "USM 201", Pozycja = "bezpieczna"  , Magazyn = "(E-stop zwolniony)" , Stan = "W trakcjie akcji" }
            };

            robots.ForEach(robot => context.Robots.Add(robot));
            context.SaveChanges();
        }
}

}
 