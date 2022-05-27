using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FE_LAW_FINAL.ViewModel {
    public class MainViewModel: BaseViewModel {

        public bool isLoaded = false;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            LoginWindow loginWindow = new();
            if (!isLoaded)
            {
                isLoaded = true;
                loginWindow.ShowDialog();
            } 
        }

       
    }
}
