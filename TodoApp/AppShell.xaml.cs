using TodoApp.Views;

namespace TodoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateAgendaDetail), typeof(AddUpdateAgendaDetail));
	}
}
