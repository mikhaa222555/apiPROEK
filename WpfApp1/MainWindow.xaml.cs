using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {}
        private async void Seerce_Click(object sender, RoutedEventArgs e)
        { 
            Task task = new() { Id = 1, Description = "Description", Title = "New Tittle", IsCompleted = true };
            ApiService apiService = new ApiService("https://localhost:7094/");//Тут линк на API
            await apiService.UpdateTaskAsync(task);
        }
        // ТУТ ТОЖЕ УТОЧНИ САМ

        public class Task
        {
            [Key] // Specify the primary key
            public int Id { get; set; }

            [Required(ErrorMessage = "Title is required")]
            [MaxLength(255)] // Limit the length(optional)
            public string? Title { get; set; }

            public string? Description { get; set; }

            public bool IsCompleted { get; set; }
            // ТУТ ТОЖЕ УТОЧНИ САМ
        }
    }
}