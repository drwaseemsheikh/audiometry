namespace Audiometry.ViewModel.PatientVM
{
    public class Diagnosis
    {
        public string Description { get; set; }
        public bool IsChecked { get; set; }

        public Diagnosis() { }

        public  Diagnosis(string description)
        {
            Description = description;
        }

        public Diagnosis(string description, bool isChecked)
        {
            Description = description;
            IsChecked = isChecked;
        }
    }
}
