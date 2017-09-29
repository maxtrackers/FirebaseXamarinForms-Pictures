using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
namespace FirebaseXamarinForms
{
    public class Data
    {
        public double Value { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Data = GetData();
        }

        public ObservableCollection<Data> Data { get; set; }

        public static ObservableCollection<Data> GetData()
        {
            var data = new ObservableCollection<Data>
        {
            new Data { Value = 0.63 },
            new Data { Value = 0.85 },
            new Data { Value = 0.75 },
            new Data { Value = 0.96 },
            new Data { Value = 0.78 },
        };

            return data;
        }
    }
}
