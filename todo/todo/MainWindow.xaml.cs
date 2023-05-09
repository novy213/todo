using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using todo.Models;
using todo.Properties;

namespace todo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Project currentProject;
        List<Project> projects;
        public MainWindow()
        {
            InitializeComponent();
            if (Settings.Default.accessToken != "") SetAppStateLogin();
            else SetAppStateLogout();
        }

        private async void Login_click(object sender, RoutedEventArgs e)
        {
            string login = LoginName.Text;
            string password = PasswordName.Text;
            APIResponse res = await Api.LoginAsync(login, password);
            if (!res.Error)
            {
                SetAppStateLogin();
            }
            else
            {
                MessageBox.Show("Nie udało się zalogować", "Error", MessageBoxButton.OK);
            }
        }
        public void SetAppStateLogin()
        {
            LoginGrid.Visibility = Visibility.Collapsed;
            ProjectsGrid.Visibility = Visibility.Visible;
            GetProjects();
        }   
        public async void GetProjects()
        {
            GetProjectListResponse res = await Api.GetProjectsListAsync();
            ProjectsListView.ItemsSource = res.Projects;
            projects = res.Projects;
        }
        public void SetAppStateLogout()
        {
            LoginGrid.Visibility = Visibility.Visible;
            ProjectsGrid.Visibility = Visibility.Collapsed;
        }

        private async void Logout_click(object sender, RoutedEventArgs e)
        {
            APIResponse res = await Api.LogoutAsync();
            if (!res.Error)
            {
                SetAppStateLogout();
            }
        }

        private void OpenProject_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;            
            GetTasksList(int.Parse(btn.Uid));
            currentProject = projects.Where(item => item.Id == int.Parse(btn.Uid)).ToList()[0];
            ProjectGrid.Visibility = Visibility.Visible;
            ProjectsGrid.Visibility = Visibility.Collapsed;
        }
        public async void GetTasksList(int project_id)
        {
            GetTasksListResponse res = await Api.GetTasksListAsync(project_id);
            TasksListView.ItemsSource = res.Tasks;
        }
        private void RenameProject_click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProject_click(object sender, RoutedEventArgs e)
        {

        }

        private void TasksBack_click(object sender, RoutedEventArgs e)
        {
            ProjectGrid.Visibility = Visibility.Collapsed;
            ProjectsGrid.Visibility = Visibility.Visible;
            TasksListView.ItemsSource = null; 
        }

        private async void AddTask_click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask { Owner = this };
            if(addTask.ShowDialog() == true)
            {
                string desc = addTask.Description.Text;
                APIResponse res = await Api.AddTaskAsync(desc, currentProject.Id);
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else GetTasksList(currentProject.Id);
            }
        }

        private void EditTask_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
