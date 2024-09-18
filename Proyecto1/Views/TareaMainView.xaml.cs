using Proyecto1.ViewModels;

namespace Proyecto1.Views;

public partial class TareaMainView : ContentPage
{
    private TareaMainViewModel ViewModel;

    public TareaMainView()
    {
        InitializeComponent();
        ViewModel = new TareaMainViewModel();
        this.BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetAll();
    }
}