using System;
using System.Windows;
using static TodoApp.MainWindow;

namespace TodoApp
{
    public partial class EditTaskWindow : Window
    {
        public TodoItem TodoItem { get; set; }

        public EditTaskWindow(TodoItem todoItem)
        {
            InitializeComponent();
            TodoItem = todoItem;
            TaskName.Text = TodoItem.Task;
            TaskDescription.Text = TodoItem.Description;
            DueDate.SelectedDate = TodoItem.DueDate;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Uloží úpravy úkolu
            TodoItem.Task = TaskName.Text;
            TodoItem.Description = TaskDescription.Text;
            TodoItem.DueDate = DueDate.SelectedDate.HasValue ? DueDate.SelectedDate.Value : DateTime.Now;
            DialogResult = true;
            Close();
        }
    }
}
