using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Diagnostico
{
    public partial class DiagnosticoPage : ContentPage, INotifyPropertyChanged {
        ObservableCollection<Paciente> pacientesCollection = new ObservableCollection<Paciente>{
            new Paciente{FullNombre="Luis Slacker"},
        };

        public DiagnosticoPage() {
            this.Title = "Pacientes";
            BindingContext = pacientesCollection;
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


		async void onBtnClicked(object sender, EventArgs e) {
            string nombre = await CustomDialog.InputBox(this.Navigation, "Añadir nuevo paciente", "Nombre y Apellido", "");
            if(nombre != null) pacientesCollection.Add(new Paciente { FullNombre = nombre });
		}

		async void onSelection(object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			((ListView)sender).SelectedItem = null; // unselect item

            var secondPage = new Diagnosis(e.SelectedItem as Paciente);
			await Navigation.PushAsync(secondPage);

		}

		

		
    }

	
}
