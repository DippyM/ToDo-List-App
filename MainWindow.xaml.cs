using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Globalization;
using System.Threading;

namespace TodoApp
{
    public partial class MainWindow : Window
    {
        private List<TodoItem> todoList = new List<TodoItem>();
        private Dictionary<string, List<TodoItem>> completedTasksByMonth = new Dictionary<string, List<TodoItem>>();

        public MainWindow()
        {
            InitializeComponent();

            // Nastavení české lokalizace pro celý program
            CultureInfo culture = new CultureInfo("cs-CZ");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        // Přidání nového úkolu
        private void AddTodo_Click(object sender, RoutedEventArgs e)
        {
            string todoText = TodoInput.Text;
            string descriptionText = TodoDescription.Text;
            DateTime? dueDate = DueDatePicker.SelectedDate;

            if (!string.IsNullOrWhiteSpace(todoText) && dueDate != null && todoText != "Zadej úkol")
            {
                var todoItem = new TodoItem
                {
                    Task = todoText,
                    Description = descriptionText,
                    DueDate = dueDate.Value,
                    IsCompleted = false
                };

                todoList.Add(todoItem);
                UpdateTodoList();
                TodoInput.Clear();
                TodoDescription.Clear();
                DueDatePicker.SelectedDate = null;
                TodoInput.Text = "Zadej úkol";
                TodoInput.Foreground = Brushes.Gray;
                TodoDescription.Text = "Popis úkolu";
                TodoDescription.Foreground = Brushes.Gray;
            }
        }
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Pokud je vybraný úkol z aktivního seznamu
            if (TodoListBox.SelectedItem != null)
            {
                var selectedTodo = (ListBoxItem)TodoListBox.SelectedItem;
                var todoItem = (TodoItem)selectedTodo.Tag;
                todoList.Remove(todoItem);
                UpdateTodoList();
            }
            // Pokud je vybraný úkol z hotových úkolů
            else if (CompletedTreeView.SelectedItem is TreeViewItem selectedCompletedItem)
            {
                foreach (var monthKey in completedTasksByMonth.Keys)
                {
                    var monthGroup = completedTasksByMonth[monthKey];
                    foreach (var task in monthGroup)
                    {
                        if ($"{task.Task} - {task.DueDate.ToShortDateString()}" == (string)selectedCompletedItem.Header)
                        {
                            monthGroup.Remove(task);
                            if (monthGroup.Count == 0)
                            {
                                completedTasksByMonth.Remove(monthKey);
                            }
                            UpdateCompletedTasksView();
                            return;
                        }
                    }
                }
            }
        }

        // Aktualizace seznamu úkolů
        private void UpdateTodoList()
        {
            TodoListBox.Items.Clear();

            foreach (var todoItem in todoList)
            {
                var listItem = new ListBoxItem
                {
                    Content = $"{todoItem.Task} - {todoItem.DueDate.ToString("dd/MM/yyyy")}",
                    Tag = todoItem
                };

                // Barevné upozornění na blížící se termín
                TimeSpan timeRemaining = todoItem.DueDate - DateTime.Now;
                if (timeRemaining.TotalDays <= 1)
                {
                    listItem.Background = Brushes.Red; // Termín je blízko nebo prošel
                }
                else if (timeRemaining.TotalDays <= 3)
                {
                    listItem.Background = Brushes.Orange; // Termín se blíží
                }
                else
                {
                    listItem.Background = Brushes.LightGreen; // Ještě dost času
                }

                TodoListBox.Items.Add(listItem);
            }
        }

        // Zobrazení popisu úkolu po kliku pravého tlačítka
        private void TodoListBox_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TodoListBox.SelectedItem != null)
            {
                var selectedTodo = (ListBoxItem)TodoListBox.SelectedItem;
                var todoItem = (TodoItem)selectedTodo.Tag;

                // Otevře dialogové okno pro editaci úkolu
                EditTaskWindow editWindow = new EditTaskWindow(todoItem);
                if (editWindow.ShowDialog() == true)
                {
                    // Po uložení úprav se úkol aktualizuje v seznamu
                    UpdateTodoList();
                }
            }
        }
        
        // Dvojklik na úkol v seznamu aktivních úkolů
        private void TodoListBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (TodoListBox.SelectedItem != null)
            {
                var selectedTodo = (ListBoxItem)TodoListBox.SelectedItem;
                var todoItem = (TodoItem)selectedTodo.Tag;

                // Přesunutí úkolu do hotových
                MarkSelectedTaskAsCompleted();
            }
        }

        // Dvojklik na úkol v seznamu hotových úkolů
        private void CompletedTreeView_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (CompletedTreeView.SelectedItem is TreeViewItem selectedCompletedItem)
            {
                foreach (var monthKey in completedTasksByMonth.Keys)
                {
                    var monthGroup = completedTasksByMonth[monthKey];
                    foreach (var task in monthGroup)
                    {
                        if ($"{task.Task} - {task.DueDate.ToShortDateString()}" == (string)selectedCompletedItem.Header)
                        {
                            // Odstraníme úkol z hotových a vrátíme ho do aktivních
                            monthGroup.Remove(task);
                            if (monthGroup.Count == 0)
                            {
                                completedTasksByMonth.Remove(monthKey);
                            }
                            todoList.Add(task);
                            UpdateTodoList();
                            UpdateCompletedTasksView();
                            return;
                        }
                    }
                }
            }
        }

        // Označení úkolu jako hotového přes tlačítko
        private void MarkAsCompleted_Click(object sender, RoutedEventArgs e)
        {
            MarkSelectedTaskAsCompleted();
        }

        // Univerzální metoda pro označení úkolu jako hotového
        private void MarkSelectedTaskAsCompleted()
        {
            if (TodoListBox.SelectedItem != null)
            {
                var selectedTodo = (ListBoxItem)TodoListBox.SelectedItem;
                var todoItem = (TodoItem)selectedTodo.Tag;
                todoItem.IsCompleted = true;

                // Přidání do hotových úkolů podle měsíce dokončení
                string monthKey = todoItem.DueDate.ToString("MMMM yyyy");
                if (!completedTasksByMonth.ContainsKey(monthKey))
                {
                    completedTasksByMonth[monthKey] = new List<TodoItem>();
                }
                completedTasksByMonth[monthKey].Add(todoItem);

                todoList.Remove(todoItem);
                UpdateTodoList();
                UpdateCompletedTasksView();
            }
        }

        // Aktualizace zobrazení hotových úkolů
        private void UpdateCompletedTasksView()
        {
            CompletedTreeView.Items.Clear();

            foreach (var monthKey in completedTasksByMonth.Keys)
            {
                TreeViewItem monthItem = new TreeViewItem { Header = monthKey };

                foreach (var task in completedTasksByMonth[monthKey])
                {
                    TreeViewItem taskItem = new TreeViewItem { Header = $"{task.Task} - {task.DueDate.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)}" };
                    monthItem.Items.Add(taskItem);
                }

                CompletedTreeView.Items.Add(monthItem);
            }
        }

        // Třída reprezentující úkol
        public class TodoItem
        {
            public string Task { get; set; }
            public string Description { get; set; } // Popis úkolu
            public DateTime DueDate { get; set; }
            public bool IsCompleted { get; set; }
        }

        // Placeholder GotFocus a LostFocus pro popis úkolu
        private void TodoDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TodoDescription.Text == "Popis úkolu")
            {
                TodoDescription.Text = "";
                TodoDescription.Foreground = Brushes.Black;
            }
        }

        private void TodoDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TodoDescription.Text))
            {
                TodoDescription.Text = "Popis úkolu";
                TodoDescription.Foreground = Brushes.Gray;
            }
        }

        // Placeholder GotFocus a LostFocus pro název úkolu
        private void TodoInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TodoInput.Text == "Zadej úkol")
            {
                TodoInput.Text = "";
                TodoInput.Foreground = Brushes.Black;
            }
        }

        private void TodoInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TodoInput.Text))
            {
                TodoInput.Text = "Zadej úkol";
                TodoInput.Foreground = Brushes.Gray;
            }
        }
    }
}