using System;
using System.Collections.Generic;
namespace Audiometry.ViewModel.PatientVM
{
    public class Symptom
    {
        public string Description { get; set; }
        public bool IsChecked { get; set; }

        public Symptom() { }

        public  Symptom(string description)
        {
            Description = description;
        }
        public Symptom(string description, bool isChecked)
        {
            Description = description;
            IsChecked = isChecked;
        }
    }
}
