using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GOTODON
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Task> tasks = new List<Task>();
        private UIBuilder UIbuilder;
        private ExcelExporter excelExporter;

        public MainWindow()
        {
            InitializeComponent();

            UIbuilder= new UIBuilder();
            excelExporter = new ExcelExporter();
        }

        private void AddTODOItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemInList(TODOInput.Text, TaskType.TODO, TODOList);
            TODOInput.Text = string.Empty;
        }

        private void AddItemInList(string message, TaskType type, ListBox list)
        {
            Grid grid = new Grid();
            Task task = new Task();

            Button editButton = UIbuilder.InitIconButton("MaterialDesignToolButton", PackIconKind.Edit, "#FFFF5722", VerticalAlignment.Top);
            Button removeButton = UIbuilder.InitIconButton("MaterialDesignToolButton", PackIconKind.TrashCan, "#FFFF5722", VerticalAlignment.Bottom);
            TextBox item = UIbuilder.InitItemTextBox(message, "MaterialDesignDataGridTextColumnEditingStyle", new Thickness(5, 5, 25, 5));

            grid.Children.Add(editButton);
            grid.Children.Add(removeButton);
            grid.Children.Add(item);


            list.Items.Add(grid);

            task.Message = message;
            task.View = list.Items[list.Items.Count - 1];
            task.Type = (sbyte)type;

            tasks.Add(task);

            DragDrop.DoDragDrop(grid, grid, DragDropEffects.Copy);

            removeButton.Click += (sender, EventArgs) => { DeleteItemFromList(sender, EventArgs, task, list); };
            editButton.Click += (sender, EventArgs) => { EditItemFromList(sender, EventArgs, task, item); };
        }

        private void DeleteItemFromList(object sender, RoutedEventArgs e, Task task, ListBox list)
        {
            list.Items.Remove(task.View);
            tasks.Remove(task);
        }

        private void EditItemFromList(object sender, RoutedEventArgs e, Task task, TextBox textBox)
        {
            Button btn = (Button)sender;
            PackIcon packIcon = new PackIcon();

            if (textBox.IsReadOnly)
            {
                packIcon.Kind = PackIconKind.SuccessBold;
                
                textBox.IsReadOnly = false;
                textBox.BorderBrush =  UIbuilder.GetColorFromHEX("#FFFF5722");
                btn.Content = packIcon;
            }
            else
            {
                packIcon.Kind = PackIconKind.Edit;

                textBox.IsReadOnly = true;
                textBox.BorderBrush = null;
                btn.Content = packIcon;

                tasks.Find(x => x.Equals(task)).Message = textBox.Text;
            }
        }

        private void ExportInXLS_Click(object sender, RoutedEventArgs e)
        {
            excelExporter.Export(tasks);
        }
    }
}
