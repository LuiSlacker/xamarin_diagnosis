using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

namespace Diagnostico {

    public partial class Diagnosis : ContentPage {

		private Paciente paciente;

        public Diagnosis(Paciente paciente) {
			this.Title = "Diagnosis";
            this.paciente = paciente;
			InitializeComponent();
            diagnosis.ItemsSource = paciente.diagnosisCollection;
        }

		async void onBtnClicked(object sender, EventArgs e) {
			string nombre = await CustomDialog.InputBox(this.Navigation, "Añadir nueva diagnosis", "Nombre", "");
            if (nombre != null)  {
                paciente.diagnosisCollection.Add(new SingleDiagnosis { Nombre = nombre });
                paciente.LastDiagnosis = nombre;
            }

		}

		async public void OnEdit(object sender, EventArgs e) {
            var menuItem = ((MenuItem)sender);
            SingleDiagnosis diagnosis = (SingleDiagnosis) menuItem.CommandParameter;

			string nombre = await CustomDialog.InputBox(this.Navigation, "Añadir nueva diagnosis", "Nombre", diagnosis.Nombre);
			if (nombre != null) diagnosis.Nombre = nombre;
            if (isLastEntry(diagnosis)) {
                paciente.LastDiagnosis = nombre;
            }

		}

		public void OnDelete(object sender, EventArgs e) {
			var menuItem = ((MenuItem)sender);
            SingleDiagnosis diagnosis = (SingleDiagnosis)menuItem.CommandParameter;

            if (isLastEntry(diagnosis)) {
				paciente.diagnosisCollection.Remove(diagnosis);
                paciente.LastDiagnosis = (paciente.diagnosisCollection.Count > 0) ? paciente.diagnosisCollection.Last().Nombre : "";
            } else DisplayAlert("Error", "Item cannot be deleted!", "OK");
		}

        private bool isLastEntry(SingleDiagnosis diagnosis) {
            return paciente.diagnosisCollection.IndexOf(diagnosis) + 1 == paciente.diagnosisCollection.Count;
        }
    }
}
