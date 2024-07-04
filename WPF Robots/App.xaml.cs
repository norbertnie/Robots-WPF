using System.Configuration;
using System.Data;
using System.Windows;
using WPF_Robots.Models;

namespace WPF_Robots
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new RobotContext())
            {
                DatabaseInitializer.Initialize(context);
            }
        }
    }


}
