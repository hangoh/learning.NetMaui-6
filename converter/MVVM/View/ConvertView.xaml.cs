using converter.MVVM.ViewModel;

namespace converter.MVVM.View;

public partial class ConvertView : ContentPage
{
	public ConvertView()
	{
		InitializeComponent();
		
	}

    void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
		var view = (ConverterViewModel)BindingContext;
		view.convert();
    }

}
