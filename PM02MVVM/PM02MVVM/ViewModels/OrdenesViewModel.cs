using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PM02MVVM.ViewModels
{
    public class OrdenesViewModel : BaseViewMoldels
    {
        private string nombre;
        private double monto;
        private string status;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(); }
        }

        public double Monto
        {
            get { return monto; }
            set { monto = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }


        public ICommand LimpiarCommand { private get; set; }

        /*  Constructor de la clase */
        public OrdenesViewModel()
        {
            LimpiarCommand = new Command(() => Limpiar());
        }

        void Limpiar()
        {
            Nombre = String.Empty;
            Monto = 0.0;
            Status = String.Empty;
        }
    }
}
