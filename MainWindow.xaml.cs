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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем диалоговое окно для ввода текста
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                // Получаем введенный текст
                string noteText = inputDialog.InputText;

                // Создаем новый Border
                Border newBorder = new Border
                {
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5)
                };

                // Создаем новый CheckBox с введенным текстом
                CheckBox newCheckBox = new CheckBox
                {
                    Content = noteText
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
                var itemsToRemove = new System.Collections.Generic.List<UIElement>();

                // Проходим по всем элементам StackPanel
                foreach (UIElement element in stackPanel.Children)
                {
                    if (element is Border border && border.Child is CheckBox checkBox && checkBox.IsChecked == true)
                    {
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