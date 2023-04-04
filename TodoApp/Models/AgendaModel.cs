using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class AgendaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AgendaConteudo { get; set; }
        public DateTime Date { get; set; }
    }
}
