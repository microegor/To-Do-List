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
using System.Windows.Shapes;

namespace ToDoList
{
    public partial class InputDialog : Window
    {
        public ToDoItem Item { get; private set; }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Item = new ToDoItem
            {
                Text = InputTextBox.Text,
                CreationDate = DateTime.Now,
                Priority = (PriorityLevel)PriorityComboBox.SelectedIndex
            };
            DialogResult = true;
        }
    }
}
