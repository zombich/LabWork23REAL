using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;
using DatabaseLibrary.Service;
using Microsoft.Win32;
using System.IO;
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

namespace LabWork23REAL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GamesService _service = new(new GamesDbContext());
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddLogoButton_Click(object sender, RoutedEventArgs e)
        {
            int gameId;
            if (!int.TryParse(GameIdTextBox.Text, out gameId))
            {
                MessageBox.Show("","");
                return;
            }    
            
            OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == false)
                return;

            var copyPath = System.IO.Path.Combine(Environment.CurrentDirectory, "GamesLogo");
            var filePath = System.IO.Path.Combine(copyPath, $@"{dialog.SafeFileName}");

            if (!System.IO.Path.Exists(copyPath))
                Directory.CreateDirectory(copyPath);

            File.Copy(dialog.FileName, filePath);

            _service.AddGameLogo(gameId, filePath);
        }

        private async Task AddScreenshotButton_Click(object sender, RoutedEventArgs e)
        {
            int gameId;
            if (!int.TryParse(GameIdTextBox.Text, out gameId))
            {
                MessageBox.Show("", "");
                return;
            }

            OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == false)
                return;

            byte[] bytes = File.ReadAllBytes(dialog.FileName);

            ScreenshotsLw23 screenshot = new();

            screenshot.Photo = bytes;
            screenshot.FileName = dialog.SafeFileName;
            screenshot.GameId = gameId;

            await _service.AddScreenshot(screenshot);
        }
    }
}