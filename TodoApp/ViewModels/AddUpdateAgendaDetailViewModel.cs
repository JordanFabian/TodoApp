using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoApp.ViewModels
{
    [QueryProperty(nameof(AgendaDetail), "AgendaDetail")]
    public partial class AddUpdateAgendaDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private AgendaModel _agendaDetail = new();

        private readonly IAgendaService _agendaService;
        
        public AddUpdateAgendaDetailViewModel(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }
        
        [RelayCommand]
        public async void AddUpdateAgenda()
        {
            int response;
            if (AgendaDetail.Id > 0)
            {
                response = await _agendaService.UpdateAgenda(AgendaDetail);

            }
            else
            {
                response = await _agendaService.AddAgenda(new Models.AgendaModel
                {
                    AgendaConteudo = AgendaDetail.AgendaConteudo,
                    Date = AgendaDetail.Date,

                });
            }

            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Salvo", "Salvo a pagina principal", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Não adicionado", "Algo de errado aconteceu", "Ok");
            }

            await Shell.Current.GoToAsync("..", true);        
        }

    }
}
