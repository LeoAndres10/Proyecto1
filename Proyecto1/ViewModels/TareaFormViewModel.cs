using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto1.Models;
using Proyecto1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto1.ViewModels
{
    public partial class TareaFormViewModel : ObservableObject
    {

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string descripcion;
        [ObservableProperty]
        private string estado;


        private readonly TareaService TareaService;

        public TareaFormViewModel()
        {
            TareaService = new TareaService();
        }

        public TareaFormViewModel(Tarea Tarea)
        {
            TareaService = new TareaService();
            id = Tarea.Id;
          
            descripcion = Tarea.Descripcion;
        
        }

        /// <summary>
        /// Muestra un mensaje de alerta personalizado
        /// </summary>
        /// <param name="Titulo">Titulo de la alerta, por ejemplo, ERROR, ADVERTENCIA, etc</param>
        /// <param name="Mensaje">Mensaje a mostrar en la alerta</param>
        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        /// <summary>
        /// Verifica que los campos obligatorios esten ingresados
        /// </summary>
        /// <param name="Producto">Objeto a validar</param>
        /// <returns>Valor booleano que nos confirma si los campos obligatorios tienen datos</returns>
        private bool Validar(Tarea Tarea)
        {
             if (Tarea.Descripcion is null || Tarea.Descripcion == "")
            {
                Alerta("ADVERTENCIA", "Ingrese la descripción de la tarea");
                return false;
            }else if(Tarea.Estado is null || Tarea.Estado == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el estado de la tarea");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Ingresa o actualiza un registro de producto
        /// </summary>
        /// <returns>Listado de productos con nuevo registro o registro actualizado</returns>
        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Tarea Tarea = new Tarea();
                Tarea.Id = Id;
                Tarea.Descripcion = Descripcion;
                Tarea.Estado = Estado;
               

                if (Validar(Tarea))
                {
                    if (Id == 0)
                    {
                        TareaService.Insert(Tarea);
                    }
                    else
                    {
                        TareaService.Update(Tarea);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

    }
}
