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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
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
            if (Settings.Default.accessToken != "" && Settings.Default.user_id != 0) SetAppStateLogin();
            else SetAppStateLogout();
        }

        private async void Login_click(object sender, RoutedEventArgs e)
        {
            string login = LoginName.Text;
            string password = PasswordName.Text;
            if (login == "" || password == "")
            {
                MessageBox.Show("All fields are required", "Error");
            }
            else
            {
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
        }
        public void SetAppStateLogin()
        {
            LoginGrid.Visibility = Visibility.Collapsed;
            ProjectsGrid.Visibility = Visibility.Visible;
            RegisterGrid.Visibility = Visibility.Collapsed;
            LoginName.Text = "";
            PasswordName.Text = "";
            LNameRegister.Text = "";
            LoginRegister.Text = "";
            PasswordRegister.Text = "";
            NameRegister.Text = "";
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
            RegisterGrid.Visibility = Visibility.Collapsed;
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
            ProjectNameText.Text = currentProject.Project_name;
            ProjectGrid.Visibility = Visibility.Visible;
            ProjectsGrid.Visibility = Visibility.Collapsed;
        }
        public async void GetTasksList(int project_id)
        {
            GetTasksListResponse res = await Api.GetTasksListAsync(project_id);
            if (res.Tasks != null) TasksListView.ItemsSource = res.Tasks.OrderBy(item => item.Done);
            else TasksListView.ItemsSource = null;
        }
        private async void RenameProject_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            RenameProject renameProject = new RenameProject { Owner = this };
            renameProject.NewName.Text = projects.Where(item => item.Id == int.Parse(btn.Uid)).ToList()[0].Project_name;
            renameProject.NewName.Focus();
            renameProject.NewName.SelectAll();
            if (renameProject.ShowDialog() == true)
            {
                APIResponse res = await Api.RenameProjectAsync(int.Parse(btn.Uid), renameProject.NewName.Text);
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else GetProjects();
            }
        }

        private async void DeleteProject_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Project deleteProject = projects.Where(item => item.Id == int.Parse(btn.Uid)).ToList()[0];
            MessageBoxResult mbresult = MessageBox.Show(deleteProject.Project_name + " will be deleted permanently, do you want to continue?", "Delete", MessageBoxButton.YesNo);
            if (mbresult == MessageBoxResult.Yes)
            {
                APIResponse res = await Api.DeleteProjectAsync(int.Parse(btn.Uid));
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else GetProjects();
            }
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

        private async void EditTask_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            EditTask editTask = new EditTask { Owner = this };
            GetTasksListResponse response= await Api.GetTasksListAsync(currentProject.Id);
            editTask.Description.Text = response.Tasks.Where(item => item.Id == int.Parse(btn.Uid)).ToList()[0].Description;
            editTask.Description.Focus();
            editTask.Description.SelectAll();
            if (editTask.ShowDialog() == true)
            {
                APIResponse res = await Api.EditTaskAsync(editTask.Description.Text, int.Parse(btn.Uid));
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else GetTasksList(currentProject.Id);
            }
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            APIResponse res = await Api.MarkTaskAsync(int.Parse(checkBox.Uid), checkBox.IsChecked==true ? 1: 0);
            if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
            else GetTasksList(currentProject.Id);
        }

        private async void DeleteTask_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBoxResult mbresult = MessageBox.Show("This task will be deleted permanently, do you want to continue?", "Delete", MessageBoxButton.YesNo);
            if (mbresult == MessageBoxResult.Yes)
            {
                APIResponse res = await Api.DeleteTaskAsync(int.Parse(btn.Uid));
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else GetTasksList(currentProject.Id);
            }
        }

        private async void AddProject_click(object sender, RoutedEventArgs e)
        {
            CreateProject createProject = new CreateProject { Owner = this };
            if(createProject.ShowDialog() == true)
            {
                APIResponse res = await Api.CreateProjectAsync(Settings.Default.user_id, createProject.ProjectName.Text);
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else GetProjects();
            }
        }

        private void BackRegister_click(object sender, RoutedEventArgs e)
        {
            RegisterGrid.Visibility = Visibility.Collapsed;
            LoginGrid.Visibility = Visibility.Visible;
        }

        private async void Register_click(object sender, RoutedEventArgs e)
        {
            string login = LoginRegister.Text;
            string password = PasswordRegister.Text;
            string name = NameRegister.Text;
            string last_name = LNameRegister.Text;
            if (login == "" || password == "" || name == "" || last_name == "")
            {
                MessageBox.Show("All fields are required", "Error");
            }
            else
            {
                APIResponse res = await Api.RegisterAsync(login, password, name, last_name);
                if (res.Error) MessageBox.Show(res.Message, "Error", MessageBoxButton.OK);
                else
                {
                    RegisterGrid.Visibility = Visibility.Collapsed;
                    LoginGrid.Visibility = Visibility.Visible;
                }
            }
        }

        private void GoToRegister_click(object sender, RoutedEventArgs e)
        {
            RegisterGrid.Visibility = Visibility.Visible;
            LoginGrid.Visibility = Visibility.Collapsed;
        }
    }
}
