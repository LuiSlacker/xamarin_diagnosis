using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Diagnostico
{
	public class Paciente : INotifyPropertyChanged
	{
		public string FullNombre { get; set; }
		public ObservableCollection<SingleDiagnosis> diagnosisCollection = new ObservableCollection<SingleDiagnosis> { };

		public event PropertyChangedEventHandler PropertyChanged;

		private string lastDiagnosis;

		public string LastDiagnosis
		{
			set
			{
				if (lastDiagnosis != value)
				{
					lastDiagnosis = value;
					if (PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs("LastDiagnosis"));
					}
				}
			}
			get => lastDiagnosis;
		}

	}
}
