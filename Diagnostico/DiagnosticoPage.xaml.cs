using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;

namespace Diagnostico
{
	public class SingleDiagnosis {
		public string Nombre { get; set; }
	}

    public class Paciente {
        public string FullNombre { get; set; }
		public ObservableCollection<SingleDiagnosis> diagnosisCollection = new ObservableCollection<SingleDiagnosis>{};

	}


    public partial class DiagnosticoPage : ContentPage {
        ObservableCollection<Paciente> pacientesCollection = new ObservableCollection<Paciente>{
            new Paciente{FullNombre="Luis Slacker"},
        };

        public DiagnosticoPage() {
            this.Title = "Pacientes";
            InitializeComponent();
            pacientes.ItemsSource = pacientesCollection;
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

			((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

            var secondPage = new Diagnosis(((Paciente) e.SelectedItem));
			await Navigation.PushAsync(secondPage);

		}

		
    }

	
}
