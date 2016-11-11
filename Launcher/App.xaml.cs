// -----------------------------------------------------------
// Copyrights (c) 2016 Seditio 🍂 INC. All rights reserved.
// -----------------------------------------------------------

using System.Windows;

using Launcher.Windows;

namespace Launcher
{
    /// <summary>
    ///   Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_Start(object sender, StartupEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}