using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services
{
    public interface IAgendaService
    {
        Task<List<AgendaModel>> GetAgendaList();

        Task<int> AddAgenda(AgendaModel agendaModel);

        Task<int> DeleteAgenda(AgendaModel agendaModel);

        Task<int> UpdateAgenda(AgendaModel agendaModel);
    }
}
