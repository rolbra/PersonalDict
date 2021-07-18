using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace myPersonalDict.Models
{
    [Table("Translations")]
    public class Translations
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(1024), Unique]
        public string German { get; set; }
        [MaxLength(1024), Unique]
        public string Spanish { get; set; }
    }
}
