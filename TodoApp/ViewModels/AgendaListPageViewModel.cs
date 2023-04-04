using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.Views;

namespace TodoApp.ViewModels
{
    public partial class AgendaListPageViewModel : ObservableObject
    {
        public ObservableCollection<AgendaModel> Agenda { get; set; } = new ObservableCollection<AgendaModel>();

        private readonly IAgendaService _agendaService;
        
        public AgendaListPageViewModel(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }


        [RelayCommand]

        public async void GetAgendaList()
        {
            var agendaList = await _agendaService.GetAgendaList();
            if(agendaList?.Count > 0) 
            {
                Agenda.Clear();
                foreach(var agenda in agendaList)
                {
                    Agenda.Add(agenda);
                }
            }
        }

        [RelayCommand]

        public async void AddUpdateAgenda()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateAgendaDetail));
        }

        [RelayCommand]

        public async void DisplayAction(AgendaModel agendaModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Selecione a opção", "Ok", null, "Editar", "Deletar");
            if(response == "Editar")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "AgendaDetail", agendaModel }
                };

                await AppShell.Current.GoToAsync(nameof(AddUpdateAgendaDetail), navParam);
            }
            else if(response ==  "Deletar")
            {

                var delResponse = await AppShell.Current.DisplayActionSheet("Deseja mesmo excluir", null, null, "Sim", "Não");

                if(delResponse == "Sim")
                {
                    var realDeleteResponse = await _agendaService.DeleteAgenda(agendaModel);

                    Agenda.Remove(agendaModel);
                    if (realDeleteResponse > 0)
                    {
                        GetAgendaList();
                    }
                }

            }
        }
    }
}
