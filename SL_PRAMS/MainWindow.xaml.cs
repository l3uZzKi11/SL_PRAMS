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
using System.Windows.Forms;
using Devart.Data.MySql;

namespace _01DUMMY_SL_PRAMS
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



        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void Hyperlink_RequestNavigate(object sender,
                                               System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.msn.com");
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void Check02_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate_1(object sender, RequestNavigateEventArgs e)
        {

        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            string constring = "host=192.168.182.128;port=3306;User Id=SL_PRAMS_USER;Password=SLPRAMSpassword2018";
            string Query = "insert into slprams.impact (" +
                "firstname," +
                "middlename," +
                "lastname," +
                "officesymbol," +
                "squadron) " +
                "values(" +
                "'" + this.First_name_textbox.Text + "'," +
                "'" + this.MI_textbox.Text + "'," +
                "'" + this.LAST_NAME_textbox.Text + "'," +
                "'" + this.OFFICE_SYMBOL_textbox.Text + "','" + this.SQUADRON_textbox.Text +"')";
            //,'" +  + "'
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Purchase Request Submitted!");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

    }
}

