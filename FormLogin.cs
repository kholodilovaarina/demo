using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForensicDepartmen
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void ButExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButLogin_Click(object sender, EventArgs e)
        {
            if (TB_Login.Text == "" || TB_Password.Text == "")
            {
                MessageBox.Show("Заполните поля логина и пароля", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string con_str = "Server=DESKTOP-3BS07CB\\SQLEXPRESS_admin;Initial Catalog=ForensicDepartmen_HAU;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(con_str))
            {
                con.Open();
                string sql = "SELECT Count(*) FROM [USER] WHERE Login = @login AND Password = @password";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@login", TB_Login.Text);
                command.Parameters.AddWithValue("@password", TB_Password.Text);
                int reslt = (int)command.ExecuteScalar();
                if(reslt > 0)
                {
                    MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain main = new FormMain();
                    main.Show();
                    FormLogin login = new FormLogin();
                    login.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.uSERTableAdapter.Fill(this.forensicDepartmen_HAUDataSet.USER);
        }
    }
}
