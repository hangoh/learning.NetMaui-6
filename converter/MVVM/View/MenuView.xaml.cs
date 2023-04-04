using System.Collections.Generic;
using System.Diagnostics;
using converter.MVVM.ViewModel;

namespace converter.MVVM.View;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		var g = (Grid)sender;
        IEnumerable < Label > option = g.Children.OfType<Label>();
		Label l = option.ElementAtOrDefault(0);
        var param = new ConvertView {
			BindingContext=new ConverterViewModel(l.Text)
		};

		Navigation.PushAsync(param);
    }
}
