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

namespace CSH2_Tag_18_Wunschzettel
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

        private void btnAbsenden_Click(object sender, RoutedEventArgs e)
        {
            bool fehler = false;
            StringBuilder sb = new StringBuilder();
            if ((bool)this.rdbMale.IsChecked)
                sb.AppendLine("Geschlecht: " + this.rdbMale.Content);
            else if ((bool)this.rdbFemale.IsChecked)
                sb.AppendLine("Geschlecht: " + this.rdbFemale.Content);
            else
            {
                MessageBox.Show("Bitte Geschlecht wählen!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                fehler = true;
            }

            StackPanel wishPanel = this.grbWishes.Content as StackPanel;
            int anzahlWuensche = 0;
            if (!fehler)
            {
                fehler = true;
                foreach (CheckBox cb in wishPanel.Children)
                {
                    if ((bool)cb.IsChecked)
                    {
                        anzahlWuensche++;
                        sb.AppendLine($"Wunsch Nr. {anzahlWuensche}: {cb.Content}");
                    }
                }
                if (anzahlWuensche > 0)
                    fehler = false;
                if (fehler)
                {
                    MessageBox.Show("Kein Geschenk ausgewählt!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if(!fehler)
                MessageBox.Show(sb.ToString(), "Dein Wunschzettel", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
