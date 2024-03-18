using System;
using System.Collections.Generic;
using System.Data;
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

using Lab2_DS.MakdoknekDataSetTableAdapters;

namespace Lab2_DS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientTableAdapter client = new ClientTableAdapter();
        MenuTableAdapter menu = new MenuTableAdapter();
        BookingTableAdapter booking = new BookingTableAdapter();

        bool ClientTableIsEnabled = false;
        bool MenuTableIsEnabled = false;
        bool BookingTableIsEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
            DishNameTbx.IsEnabled = false;
            DishPriceTbx.IsEnabled = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) // кнопка показа таблицы клиентов
        {
            ClientDgr.ItemsSource = client.GetData();

            DishNameTbx.IsEnabled = false; // блок текстблока
            DishPriceTbx.IsEnabled = false;

            AddButton.IsEnabled = false; // блок кнопки добавления
            DeleteButton.IsEnabled = true; // анлок кнопки удаления

            ClientTableIsEnabled = true;
            MenuTableIsEnabled = false;
            BookingTableIsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // кнопка показа таблицы меню
        {
            ClientDgr.ItemsSource = menu.GetData();

            DishNameTbx.IsEnabled = true;
            DishPriceTbx.IsEnabled = true;

            AddButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;

            ClientTableIsEnabled = false;
            MenuTableIsEnabled = true;
            BookingTableIsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // кнопка показа таблицы заказов
        {
            ClientDgr.ItemsSource = booking.GetData();

            DishNameTbx.IsEnabled = false; // блок текстблока
            DishPriceTbx.IsEnabled = false;

            AddButton.IsEnabled = false; // блок кнопки добавления
            DeleteButton.IsEnabled = false;

            ClientTableIsEnabled = false;
            MenuTableIsEnabled = false;
            BookingTableIsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // добавление
        {
            string name = DishNameTbx.Text;
            int price = Convert.ToInt32(DishPriceTbx.Text);

            menu.InsertQuery(name, price);
            ClientDgr.ItemsSource = menu.GetData();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) // изменение
        {
            object id = (ClientDgr.SelectedItem as DataRowView).Row[0];
            client.UpdateQuery(DishNameTbx.Text, Convert.ToInt32(id));
            ClientDgr.ItemsSource = client.GetData();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // удаление
        {
            object id = (ClientDgr.SelectedItem as DataRowView).Row[0];
            menu.DeleteQuery(Convert.ToInt32(id));
            ClientDgr.ItemsSource = menu.GetData();
        }
    }
}
