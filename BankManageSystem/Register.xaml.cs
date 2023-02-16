using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace BankManageSystem
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        SqlConnection con;
        public Register()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=desktop-1ahtenp\\mssqlserver01;Initial Catalog=BankManageSystem;Integrated Security=True;Pooling=False");
            con.Open();

        }

        private void registe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // DatePicker dp = new DatePicker();
                //Open the db connection
                string qury = "insert into customerTable values(CAST((RAND()*(9832789-3)+(RAND()*(89732-298)))*100 AS BIGINT),@FName, @LName, @Dob, @Country, @PhoneNumber, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(qury, con);
                cmd.Parameters.AddWithValue("@FName", fname.Text);//We need to call the textbox by name to grab the text in it
                cmd.Parameters.AddWithValue("@LName", lname.Text);
                cmd.Parameters.AddWithValue("@Dob", dobPicker.ToString());
                cmd.Parameters.AddWithValue("@Country", country.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber.Text);
                cmd.Parameters.AddWithValue("@Email", email.Text);
                cmd.Parameters.AddWithValue("@Password", pwd.Password);
                //we now need to excute our qury
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registe Successfully, click ok go back to log in page!");
                MainWindow mainWindow= new MainWindow();
                mainWindow.email.Text = this.email.Text;
                this.Close();
                mainWindow.Show();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow= new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
