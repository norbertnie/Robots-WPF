using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Robots.Models;

namespace WPF_Robots.ViewModels
{
    public class RobotViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Robot> _robots;
        private ObservableCollection<Robot> _visibleRobots;
        private Robot _selectedRobot;
        private int _currentPage;
        private const int PageSize = 5; // Liczba robotów na stronę
        private static readonly Robot ShowAllRobots = new Robot { Id = -1, Name = "Wszystkie" };

        public RobotViewModel()
        {
            _robots = new ObservableCollection<Robot>();
            _visibleRobots = new ObservableCollection<Robot>();
            LoadRobotsCommand = new RelayCommand(LoadRobots);
            UpdateRobotCommand = new RelayCommand(UpdateRobot);
            PreviousPageCommand = new RelayCommand(PreviousPage, CanPreviousPage);
            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            SelectPreviousRobotCommand = new RelayCommand(SelectPreviousRobot, CanSelectPreviousRobot);
            SelectNextRobotCommand = new RelayCommand(SelectNextRobot, CanSelectNextRobot);
            CurrentPage = 1;
        }

        public ObservableCollection<Robot> Robots
        {
            get => _robots;
            set
            {
                _robots = value;
                _robots.Insert(0, ShowAllRobots); // Dodajemy opcję "Wszystkie" na początku listy
                OnPropertyChanged(nameof(Robots));
                UpdateVisibleRobots();
            }
        }

        public ObservableCollection<Robot> VisibleRobots
        {
            get => _visibleRobots;
            set
            {
                _visibleRobots = value;
                OnPropertyChanged(nameof(VisibleRobots));
            }
        }

        public Robot SelectedRobot
        {
            get => _selectedRobot;
            set
            {
                _selectedRobot = value;
                OnPropertyChanged(nameof(SelectedRobot));
                UpdateVisibleRobots();
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                UpdateVisibleRobots();
            }
        }

        public ICommand LoadRobotsCommand { get; }
        public ICommand UpdateRobotCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand SelectPreviousRobotCommand { get; }
        public ICommand SelectNextRobotCommand { get; }

        private void LoadRobots()
        {
            using (var context = new RobotContext())
            {
                Robots = new ObservableCollection<Robot>(context.Robots.ToList());
            }

            SelectedRobot = ShowAllRobots; // Ustaw "Pokaż wszystkie roboty" jako domyślnie wybrany
            UpdateVisibleRobots(); // Zaktualizuj widoczne roboty
        }

        private void UpdateRobot()
        {
            using (var context = new RobotContext())
            {
                if (SelectedRobot != null && SelectedRobot.Id == -1)
                {
                    // Zaktualizuj wszystkie roboty
                    foreach (var robot in Robots.Where(r => r.Id != -1))
                    { 
                        robot.BatteryLevel -= 1;
                        context.Entry(robot).State = EntityState.Modified;
                    }
                }
                else if (SelectedRobot != null && SelectedRobot.Id != -1)
                {
                    // Zaktualizuj wybrany robot 
                    SelectedRobot.BatteryLevel -= 1;
                    context.Entry(SelectedRobot).State = EntityState.Modified;
                }

                context.SaveChanges();
            }

            UpdateVisibleRobots();
        }

        private void UpdateVisibleRobots()
        {
            if (SelectedRobot != null && SelectedRobot.Id == -1)
            {
                // Pokaż wszystkie roboty bez specjalnego elementu "Pokaż wszystkie roboty"
                VisibleRobots = new ObservableCollection<Robot>(_robots.Where(r => r.Id != -1).Skip((CurrentPage - 1) * PageSize).Take(PageSize));
            }
            else
            {
                // Filtruj roboty na podstawie wybranego robota
                var filteredRobots = _selectedRobot != null ? _robots.Where(r => r.Id == _selectedRobot.Id) : _robots;
                VisibleRobots = new ObservableCollection<Robot>(filteredRobots.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
            }
            CommandManager.InvalidateRequerySuggested();
        }

        private void PreviousPage()
        {
            if (CanPreviousPage())
            {
                CurrentPage--;
            }
        }

        private bool CanPreviousPage()
        {
            return CurrentPage > 1;
        }

        private void NextPage()
        {
            if (CanNextPage())
            {
                CurrentPage++;
            }
        }

        private bool CanNextPage()
        {
            var filteredRobotsCount = _selectedRobot != null && _selectedRobot.Id != -1 ? _robots.Count(r => r.Id == _selectedRobot.Id) : _robots.Count(r => r.Id != -1);
            return CurrentPage < (filteredRobotsCount + PageSize - 1) / PageSize;
        }

        private void SelectPreviousRobot()
        {
            if (CanSelectPreviousRobot())
            {
                var currentIndex = _robots.IndexOf(SelectedRobot);
                SelectedRobot = _robots[currentIndex - 1];
            }
        }

        private bool CanSelectPreviousRobot()
        {
            return SelectedRobot != null && _robots.IndexOf(SelectedRobot) > 0;
        }

        private void SelectNextRobot()
        {
            if (CanSelectNextRobot())
            {
                var currentIndex = _robots.IndexOf(SelectedRobot);
                SelectedRobot = _robots[currentIndex + 1];
            }
        }

        private bool CanSelectNextRobot()
        {
            return SelectedRobot != null && _robots.IndexOf(SelectedRobot) < _robots.Count - 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 