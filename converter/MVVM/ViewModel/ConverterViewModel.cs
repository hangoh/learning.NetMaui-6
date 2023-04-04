using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UnitsNet;
using PropertyChanged;
namespace converter.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
	public class ConverterViewModel
	{
		public string param { get; set; }
        public List<string> FromMeasures { get; set; }
        public List<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }
        public double FromValue { get; set; }
        public double ToValue { get; set; }
        public ICommand ReturnCommand => new Command(() => { convert(); });

        public ConverterViewModel(string s) {
			param = s;
            ToMeasures = LoadMeasures();
            FromMeasures = LoadMeasures() ;
            FromValue = 1;
            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
            convert();
        }

        public void convert() {
            var result = UnitConverter.ConvertByName(FromValue, param,CurrentFromMeasure, CurrentToMeasure);
            ToValue = result;
        }

        private List<string> LoadMeasures() {
            var units = Quantity.Infos.FirstOrDefault(x => x.Name == param).UnitInfos.Select(x=>x.Name).ToList();
            return new List<string>(units);
        }

    }
}

