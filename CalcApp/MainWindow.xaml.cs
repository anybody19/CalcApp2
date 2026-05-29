using System;
using System.Windows;
using System.Windows.Controls;

namespace CalcApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TipComboBox.SelectedIndex = 0;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool billParsed = double.TryParse(BillTextBox.Text, out double bill);
                bool guestsParsed = int.TryParse(GuestsTextBox.Text, out int guests);

                if (!billParsed || !guestsParsed)
                {
                    MessageBox.Show("Введите корректные данные");
                    return;
                }

                ComboBoxItem selectedItem =
                    (ComboBoxItem)TipComboBox.SelectedItem;

                string percentText =
                    selectedItem.Content.ToString().Replace("%", "");

                int tipPercent = int.Parse(percentText);

                double total =
                    TipCalculator.CalculateTotal(bill, guests, tipPercent);

                double perPerson =
                    TipCalculator.CalculatePerPerson(total, guests);

                ResultTextBlock.Text =
                    $"Общая сумма: {total:F2}\n" +
                    $"На одного человека: {perPerson:F2}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
