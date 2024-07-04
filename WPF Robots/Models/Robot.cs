using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Robots.Models
{
    public class Robot
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int BatteryLevel { get; set; }
        [Required]
        public string Lokalizacja { get; set; }

        [Required]
        public string Pozycja { get; set; }

        [Required]
        public string Magazyn { get; set; }

        [Required]
        public string Stan { get; set; }

        public string ImagePath => $"/Images/robot_{Id}_black.png"; 
    }

}
