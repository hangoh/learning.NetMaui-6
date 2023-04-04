using converter.MVVM.View;

namespace converter;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MenuView());
	}
}

