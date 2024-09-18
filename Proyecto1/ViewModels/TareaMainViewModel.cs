using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto1.Models;
using Proyecto1.Services;
using Proyecto1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.ViewModels
{
    public partial class TareaMainViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<Tarea>  tareaCollection = new ObservableCollection<Tarea>();

        private readonly TareaService TareaService;

        public TareaMainViewModel()
        {
            TareaService = new TareaService();
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
        /// Muestra el listado de productos
        /// </summary>
        public void GetAll()
        {
            var GetAll = TareaService.GetAll();

            if (GetAll.Count > 0)
            {
                tareaCollection.Clear();
                foreach (var tarea in GetAll)
                {
                    TareaCollection.Add(tarea);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la vista de agregar / editar producto
        /// </summary>
        /// <returns>Muestra la vista de agregar / editar producto</returns>
        [RelayCommand]
        private async Task GoToAddTareaForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new TareaformView());
        }

        /// <summary>
        /// Muestra las opciones para editar o eliminar un prudcto al seleccionarlo
        /// </summary>
        /// <param name="Producto">Objeto seleccionado para actualizar o eliminar el registro</param>
        /// <returns>Proceso de opciones al seleccionar el registro del producto</returns>
        
        [RelayCommand]
        private async Task SelectTarea(Tarea Tarea)
        {
            try
            {
                const string ACTUALIZAR = "1. Actualizar";
                const string ELIMINAR = "2. Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new TareaformView(Tarea));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR TAREA", "¿Desea eliminar la tarea?", "Si", "No");

                    if (respuesta)
                    {
                        int del = TareaService.Delete(Tarea);

                        if (del > 0)
                        {
                            TareaCollection.Remove(Tarea);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

    }
}

