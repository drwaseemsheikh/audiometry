using System;

namespace Audiometry.ViewModel.PatientVM
{
    public abstract class Test
    {
        public string Name { get; set; }
        public DateTime DateOfTest { get; set; }
    }
}
