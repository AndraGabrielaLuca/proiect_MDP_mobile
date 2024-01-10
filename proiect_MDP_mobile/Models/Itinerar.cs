using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_MDP_mobile.Models;
using SQLite;


namespace proiect_MDP_mobile.Models
{
    public class Itinerar
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Destinatie { get; set; }

        public DateTime Data_itinerar { get; set; }
    }
}
