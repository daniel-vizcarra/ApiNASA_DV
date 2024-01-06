using ApiNASADV.ViewModels;

namespace ApiNASADV.Views;

public partial class ApodPageDV : ContentPage
{
	public ApodPageDV()
	{
        InitializeComponent();
        BindingContext = new ApodViewModelDV();
    }
}