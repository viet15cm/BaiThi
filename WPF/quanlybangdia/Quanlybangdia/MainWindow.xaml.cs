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
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace quanlybangdia
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try

            {

                using (SqlConnection connection =

                  new SqlConnection(@"Data Source=DESKTOP-R6HSVS2;Initial Catalog=quanlybangdia;Integrated Security=True"))

                {

                    connection.Open();

                }

                MessageBox.Show("Kết nối thành công!", "Thông báo");
                Loadbang();

            }
            catch (Exception ex)

            {

                MessageBox.Show("Lỗi khi mở kết nối" + ex.Message);

            }
        }
        private void Loadbang()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connBangDia"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * From [BangDia]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("BangDia");
            da.Fill(dt);

            dataGridView1.ItemsSource = dt.DefaultView;

        }
        private void datag()
        {
            dataGridView1.Columns[0].Header = "Mã băng đĩa";
            dataGridView1.Columns[1].Header = "Tên băng đĩa";
            dataGridView1.Columns[2].Header = "Số lượng";
        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtBangdia.Text = row_selected["MaBD"].ToString();
                txtTenbangdia.Text = row_selected["Tenbangdia"].ToString();
                txtSoluong.Text = row_selected["Soluong"].ToString();

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            datag();
        }

        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {

            if (txtBangdia.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mã Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtBangdia.Focus();
                return;
            }
            if (txtTenbangdia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTenbangdia.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số Lượng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSoluong.Focus();
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6HSVS2;Initial Catalog=quanlybangdia;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("insert into BangDia(MaBD,Tenbangdia,Soluong) values('" + txtBangdia.Text + "',N'" + txtTenbangdia.Text + "','" + txtSoluong.Text + "' )", con);
            con.Open(); // mo ket noi

            try

            {
                cmd.ExecuteNonQuery(); // thuc thi

            }
            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);

            }

            con.Close();
            Loadbang();

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {

            if (txtBangdia.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mã Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtBangdia.Focus();
                return;
            }
            if (txtBangdia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTenbangdia.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số Lượng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSoluong.Focus();
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6HSVS2;Initial Catalog=quanlybangdia;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("update BangDia set MaBD='" + txtBangdia.Text + "',Tenbangdia=N'" + txtTenbangdia.Text + "',Soluong='" + txtSoluong.Text + "' where MaBD='" + txtBangdia.Text + "'", con);
            con.Open(); // mo ket noi
            cmd.ExecuteNonQuery(); // thuc thi
            con.Close();
            Loadbang();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            if (txtBangdia.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mã Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtBangdia.Focus();
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6HSVS2;Initial Catalog=quanlybangdia;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("delete from BangDia  where MaBD='" + txtBangdia.Text + "'", con);
            con.Open(); // mo ket noi
            cmd.ExecuteNonQuery(); // thuc thi
            con.Close();
            Loadbang();
        }
        /// © 2021 Copyright by Tiendatmagic
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult key = MessageBox.Show(
              "Bạn có muốn thoát?",
              "Thoát?",
              MessageBoxButton.YesNo,
              MessageBoxImage.Question,
              MessageBoxResult.No);
            if (key == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}