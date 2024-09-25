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

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        private ToDoManager toDoManager;

        public MainWindow()
        {
            InitializeComponent();
            toDoManager = new ToDoManager();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем диалоговое окно для ввода текста
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                // Получаем новый элемент ToDoItem
                ToDoItem newItem = inputDialog.Item;

                // Добавляем элемент в менеджер
                toDoManager.AddItem(newItem);

                // Создаем новый Border
                Border newBorder = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5)
                };

                // Создаем новый CheckBox с введенным текстом и приоритетом
                CheckBox newCheckBox = new CheckBox
                {
                    Content = $"{newItem.Text} ({newItem.Priority})",
                    Tag = newItem // Сохраняем ссылку на элемент ToDoItem в Tag
                };

                // Добавляем CheckBox в Border
                newBorder.Child = newCheckBox;

                // Проверяем, есть ли уже StackPanel внутри Frame
                if (MainFrame.Content is StackPanel stackPanel)
                {
                    stackPanel.Children.Add(newBorder);
                }
                else
                {
                    // Если StackPanel нет, создаем новый и добавляем Border
                    stackPanel = new StackPanel();
                    stackPanel.Children.Add(newBorder);
                    MainFrame.Content = stackPanel;
                }
            }
        }

        private void RemuveBt_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, есть ли StackPanel внутри Frame
            if (MainFrame.Content is StackPanel stackPanel)
            {
                // Создаем список для хранения элементов, которые нужно удалить
                var itemsToRemove = new List<UIElement>();

                // Проходим по всем элементам StackPanel
                foreach (UIElement element in stackPanel.Children)
                {
                    if (element is Border border && border.Child is CheckBox checkBox && checkBox.IsChecked == true)
                    {
                        // Получаем элемент ToDoItem из Tag
                        if (checkBox.Tag is ToDoItem toDoItem)
                        {
                            // Удаляем элемент из менеджера
                            toDoManager.RemoveItem(toDoItem);
                        }

                        // Добавляем элемент в список для удаления
                        itemsToRemove.Add(element);
                    }
                }

                // Удаляем отмеченные элементы
                foreach (var item in itemsToRemove)
                {
                    stackPanel.Children.Remove(item);
                }
            }
        }
    }
}
