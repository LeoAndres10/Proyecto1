using CommunityToolkit.Mvvm.ComponentModel;
using Proyecto1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Services
{
    public partial class TareaService : ObservableObject
    {
        private readonly SQLiteConnection bdConecction;

        public TareaService()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tarea.db3");

            bdConecction = new SQLiteConnection(path);

            bdConecction.CreateTable<Tarea>();

        }
        public List<Tarea> GetAll()
        {
            var get = bdConecction.Table<Tarea>().ToList();

            return get;

        }

        public int Insert(Tarea tarea)
        {
            return bdConecction.Insert(tarea);
        }

        public int Update(Tarea tarea)
        {
            return bdConecction.Update(tarea);

        }

        public int Delete(Tarea tarea)
        {
            return bdConecction.Delete(tarea);
        }
    }
}
