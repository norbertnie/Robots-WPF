using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPF_Robots.Models;
using WPF_Robots.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_Robots
{
    public partial class RobotSelector : UserControl
    {
        public static readonly DependencyProperty RobotsProperty =
            DependencyProperty.Register("Robots", typeof(IEnumerable<Robot>), typeof(RobotSelector), new PropertyMetadata(null, OnRobotsChanged));

        public static readonly DependencyProperty SelectedRobotProperty =
            DependencyProperty.Register("SelectedRobot", typeof(Robot), typeof(RobotSelector), new PropertyMetadata(null, OnSelectedRobotChanged));

        public IEnumerable<Robot> Robots
        {
            get { return (IEnumerable<Robot>)GetValue(RobotsProperty); }
            set { SetValue(RobotsProperty, value); }
        }

        public Robot SelectedRobot
        {
            get { return (Robot)GetValue(SelectedRobotProperty); }
            set { SetValue(SelectedRobotProperty, value); }
        }

        public RobotSelector()
        {
            InitializeComponent();
        }

        private static void OnRobotsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RobotSelector control)
            {
                control.UpdateRobotButtons();
            }
        }

        private static void OnSelectedRobotChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RobotSelector control && control.SelectedRobot != null)
            {
                control.MainButtonText.Text = control.SelectedRobot.Name;

                if (!string.IsNullOrWhiteSpace(control.SelectedRobot.ImagePath))
                {
                    try
                    {
                        Uri imageUri;
                        if ( control.SelectedRobot.Id == -1)
                        { 
                            imageUri = new Uri($"pack://application:,,,/Images/robot_black.png", UriKind.RelativeOrAbsolute);
                        }
                        else
                        { 
                            string relativeUri = control.SelectedRobot.ImagePath.TrimStart('/');
                            imageUri = new Uri($"pack://application:,,,/{relativeUri}", UriKind.RelativeOrAbsolute); 
                        
                        }

                        control.MainButtonTextImage.Source = new BitmapImage(imageUri);
                    }
                    catch (Exception ex)
                    { 
                        control.MainButtonTextImage.Source = null;
                    }
                }
                else
                {
                    control.MainButtonTextImage.Source = null;
                }
            }
        }

        private void UpdateRobotButtons()
        {
            RobotButtonsContainer.ItemsSource = Robots.Where(x => x.Id != -1);
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            RobotPopup.IsOpen = !RobotPopup.IsOpen;
        }

        private void RobotButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Robot robot)
            {
                SelectedRobot = robot;
                RobotPopup.IsOpen = false;

                if (DataContext is RobotViewModel viewModel)
                {
                    viewModel.SelectedRobot = robot;
                }
            }
        }
    }
}
