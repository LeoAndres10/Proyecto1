using Proyecto1.Models;
using Proyecto1.ViewModels;

namespace Proyecto1.Views;

public partial class TareaformView : ContentPage
{
    private TareaFormViewModel ViewModel;
    public TareaformView()
    {
        InitializeComponent();
        ViewModel = new  TareaFormViewModel();
        BindingContext = ViewModel;
    }

    public TareaformView(Tarea Tarea)
    {
        InitializeComponent();
        ViewModel = new TareaFormViewModel(Tarea);
        BindingContext = ViewModel;
    }
}