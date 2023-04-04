using TodoApp.ViewModels;

namespace TodoApp.Views;

public partial class AddUpdateAgendaDetail : ContentPage
{
    public AddUpdateAgendaDetail(AddUpdateAgendaDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}