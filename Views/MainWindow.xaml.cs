using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Silver
{
    public partial class MainWindow : Window
    {
        protected MainWindowViewModel viewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void Amount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            const string period = ".";
            TextBox textBox = (TextBox)sender;

            if (e.Key == Key.Back)
            {
                int count = textBox.Text.Count();
                int countToRemove = textBox.Text.IndexOf(period) == count - 2 ? 2 : 1;
                if (count <= 1) { countToRemove = count; }

                textBox.Text = textBox.Text.Remove(count - countToRemove, countToRemove);
            }
        }

        public void Amount_KeyDown(object sender, KeyEventArgs e)
        {
            const string period = ".";
            // const string minus = "-";
            TextBox textBox = (TextBox)sender;
            string text = string.Empty;

            // if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            // {
            //     if (string.IsNullOrEmpty(textBox.Text)) { text = minus; }
            // }
            // else
            if (e.Key == Key.Decimal || e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Oem2)
            {
                if (textBox.Text.IndexOf(period) == -1) { text = period; }
            }
            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                text = e.Key.ToString().Remove(0, 1);
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                text = e.Key.ToString().Remove(0, 6);
            }

            textBox.Text += text;
        }

        private void OpenFileCmd(object sender, ExecutedRoutedEventArgs e)
        {
            // OpenFileDialog dialog = new OpenFileDialog();
            // dialog.Filter ="Databases (.silver)|*.silver";

            // Nullable<bool> result = dialog.ShowDialog();
            // if (result == true)
            // {
            //     viewModel.Open(dialog.FileName);
            //     TransactionsList.GetBindingExpression(ListBox.ItemsSourceProperty).UpdateTarget();
            // }
        }

        private void CanExecuteOpenFileCmd(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}