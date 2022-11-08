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
using WpfApp.Data;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductService _productService;

        public MainWindow(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private async void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            await _productService.CreateAsync(new Models.ProductRequest
            {
                Name = tb_name.Text,
                Description = tb_description.Text,
                Price = decimal.Parse(tb_price.Text),
                CategoryId = int.Parse(tb_categoryId.Text)
            });

            tb_name.Text = "";
            tb_description.Text = "";
            tb_price.Text = "";
            tb_categoryId.Text = "";
        }
    }
}
