using System;
using System.ComponentModel;

namespace Diagnostico
{
    public class SingleDiagnosis : INotifyPropertyChanged
    {
        private string nombre; 

        public SingleDiagnosis()
        {
        }

		public string Nombre
		{
			set
			{
				if (nombre != value)
				{
					nombre = value;
					if (PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
					}
				}
			}
			get => nombre;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
