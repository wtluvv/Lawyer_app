using Lawyer_app.Services;
using System.Windows;

namespace Lawyer_app
{
    public partial class MainWindow : Window
    {
        private readonly DbHelper _dbHelper;

        public MainWindow()
        {
            InitializeComponent(); // Важно: должна быть первой строкой!
            _dbHelper = new DbHelper("Server=localhost;Database=lawyer_app;Uid=root;Pwd=;");
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = _dbHelper.GetTasks();
            TasksListView.ItemsSource = tasks; // Имя должно совпадать с x:Name в XAML
        }
    }
}