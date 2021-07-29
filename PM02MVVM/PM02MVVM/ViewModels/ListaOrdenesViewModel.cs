using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PM02MVVM.Models;
using Xamarin.Forms;

namespace PM02MVVM.ViewModels
{
    public class ListaOrdenesViewModel : BaseViewMoldels
    {
        /// <summary>
        /// Obtener una lista de ordenes
        /// </summary>
        private ObservableCollection<Ordenes> ordenes;
        
        public ObservableCollection<Ordenes> GetOrdenes
        {
            get { return ordenes; }
            set { ordenes = value; OnPropertyChanged(); }
        }

        /// <summary>
        ///    Obteber una sola orden 
        /// </summary>

        private Ordenes _obtenerOrden;

        public Ordenes obtenerOrden
        {
            get { return _obtenerOrden; }
            set { _obtenerOrden = value; OnPropertyChanged(); }
        }

        public ICommand DetallesCommand { private set; get; }

        // Constructor de clase 
        public INavigation Navigation { get; set; }
        public ListaOrdenesViewModel(INavigation navigation)
        {
            Navigation = navigation;

            DetallesCommand = new Command<Type>(async (pageType) => await LlenarDetalle(pageType));

            GetOrdenes = new ObservableCollection<Ordenes>();

            GetOrdenes.Add(new Ordenes() { ID = 1, NombreCliente = "Juan Ramon", MontoTotal = 3000, Status = "A" });
            GetOrdenes.Add(new Ordenes() { ID = 2, NombreCliente = "Comercial Larach", MontoTotal = 40000, Status = "A" });
            GetOrdenes.Add(new Ordenes() { ID = 3, NombreCliente = "Diario La Prensa", MontoTotal = 16000, Status = "A" });

        }

        async Task LlenarDetalle(Type pageType)
        {
            var page = (Page)Activator.CreateInstance(pageType);

            page.BindingContext = new OrdenesViewModel()
            {
                Nombre = obtenerOrden.NombreCliente,
                Monto = obtenerOrden.MontoTotal,
                Status = obtenerOrden.Status
            };
            
            await Navigation.PushAsync(page);
        }

    }
}
