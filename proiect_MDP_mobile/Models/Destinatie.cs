﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace proiect_MDP_mobile.Models
{
    public class Destinatie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        [OneToMany]
        public List<ListaDestinatie> ListaDestinatii { get; set; }
    }
}
