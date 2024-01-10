using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace proiect_MDP_mobile.Models
{
    public class ListaDestinatie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Itinerar))]
        public int ItinerarID { get; set; }
        public int DestinatieID { get; set; } 
    }
}
