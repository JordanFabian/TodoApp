using TodoApp.ViewModels;


namespace TodoApp.Views;

public partial class AgendaListPage : ContentPage
{
    readonly private AgendaListPageViewModel _viewModel;

    public AgendaListPage(AgendaListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
       _viewModel.GetAgendaListCommand.Execute(null);
    }
}