using SQLite;
using TodoApp.Models;


namespace TodoApp.Services
{
    public class AgendaService : IAgendaService
    {
        private SQLiteAsyncConnection _dbConnection;

        public AgendaService()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if(_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Agenda.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AgendaModel>();
            }
        }


        public Task<int> AddAgenda(AgendaModel agendaModel)
        {
           return _dbConnection.InsertAsync(agendaModel);

        }

        public Task<int> DeleteAgenda(AgendaModel agendaModel)
        {
            return _dbConnection.DeleteAsync(agendaModel);
        }

        public async Task<List<AgendaModel>> GetAgendaList()
        {
            var agendaList = await _dbConnection.Table<AgendaModel>().ToListAsync();
            return agendaList;  
        }

        public Task<int> UpdateAgenda(AgendaModel agendaModel)
        {
            return _dbConnection.UpdateAsync(agendaModel);
        }
    }
}
