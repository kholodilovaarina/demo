using ForensicDepartmen.ForensicDepartmen_HAUDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForensicDepartmen
{
    public partial class FormArrested : Form
    {
        public ListViewItem LastselectedItem;
        public string imagePath, MainImagePath;
        public FormArrested()
        {
            InitializeComponent();
        }

        private void FormArrested_Load(object sender, EventArgs e)
        {
            FillArrestedList();
            CB_Gender.Items.Clear();
            CB_GenderAdd.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.GENDER) CB_Gender.Items.Add(Row["Name"].ToString());
            DTP_Birth.Value = DateTime.Now;
            DTP_Place.Value = DateTime.Now;
            imagePath = Environment.CurrentDirectory + "\\Image\\";
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.GENDER) CB_GenderAdd.Items.Add(Row["Name"].ToString());
        }
        private void FillArrestedList()
        {
            this.aRRESTEDTableAdapter.Fill(this.forensicDepartmen_HAUDataSet.ARRESTED);
            this.gENDERTableAdapter.Fill(this.forensicDepartmen_HAUDataSet.GENDER);
            listView_arrested.Items.Clear();
            foreach(DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED)
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void TB_FIO_TextChanged(object sender, EventArgs e)
        {
            if (TB_FIO.Text == null)
            {
                TB_FIO.Text = "";
            }
            string str_find = TB_FIO.Text;
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED.Select("FIO LIKE '%" + str_find + "%*'"))
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void ButClear_Click(object sender, EventArgs e)
        {
            TB_FIO.Text = "";
            CB_Blood.Text = "";
            CB_Gender.Text = "";
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED)
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void ButSortMaxBirth_Click(object sender, EventArgs e)
        {
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED.OrderBy(p => p.Birthday))
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void ButSortMinBirth_Click(object sender, EventArgs e)
        {
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED.OrderByDescending(p => p.Birthday))
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void ButSortMaxArrest_Click(object sender, EventArgs e)
        {
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED.OrderBy(p => p.Date_arrest))
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void ButSortMinArrest_Click(object sender, EventArgs e)
        {
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED.OrderByDescending(p => p.Date_arrest))
            {
                DataRow TempRow;
                string[] items = new string[7];
                items[1] = Row["FIO"].ToString();
                TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                items[2] = TempRow["Name"].ToString();
                items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                items[4] = Row["Place_birth"].ToString();
                items[5] = Row["Blood_group"].ToString();
                items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                ListViewItem it = new ListViewItem();
                it.Text = Row["ID_arrsted"].ToString();
                it.SubItems.AddRange(items);
                listView_arrested.Items.Add(it);
            }
        }

        private void CB_Gender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED)
            {
                DataRow RowFilter = forensicDepartmen_HAUDataSet.GENDER.Select("Name = '" + CB_Gender.SelectedItem + "'")[0];
                if (Convert.ToString(Row["ID_gender"]) == Convert.ToString(RowFilter["ID_gender"]))
                {
                    DataRow TempRow;
                    string[] items = new string[7];
                    items[1] = Row["FIO"].ToString();
                    TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                    items[2] = TempRow["Name"].ToString();
                    items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                    items[4] = Row["Place_birth"].ToString();
                    items[5] = Row["Blood_group"].ToString();
                    items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                    ListViewItem it = new ListViewItem();
                    it.Text = Row["ID_arrsted"].ToString();
                    it.SubItems.AddRange(items);
                    listView_arrested.Items.Add(it);
                }
            }
        }

        private void CB_Blood_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listView_arrested.Items.Clear();
            foreach (DataRow Row in forensicDepartmen_HAUDataSet.ARRESTED.Rows)
            {

                DataRow RowFilter = forensicDepartmen_HAUDataSet.ARRESTED.Select("Blood_group = '" + CB_Blood.SelectedItem + "'")[0];
                if (Convert.ToString(Row["ID_arrsted"]) == Convert.ToString(RowFilter["ID_arrsted"]))
                {
                    DataRow TempRow;
                    string[] items = new string[7];
                    items[1] = Row["FIO"].ToString();
                    TempRow = Row.GetParentRow("FK_ARRESTED_GENDER");
                    items[2] = TempRow["Name"].ToString();
                    items[3] = $"{Convert.ToDateTime(Row["Birthday"]).ToString("dd.MM.yyyy")}г.";
                    items[4] = Row["Place_birth"].ToString();
                    items[5] = Row["Blood_group"].ToString();
                    items[6] = $"{Convert.ToDateTime(Row["Date_arrest"]).ToString("dd.MM.yyyy")}г.";
                    ListViewItem it = new ListViewItem();
                    it.Text = Row["ID_arrsted"].ToString();
                    it.SubItems.AddRange(items);
                    listView_arrested.Items.Add(it);
                }
            }
        }

        private void listView_arrested_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(listView_arrested, e.Location);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow[] Rows;
            DialogResult reslt = MessageBox.Show("Вы действительно хотите удалить выбранных задержанных?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (reslt == DialogResult.OK)
            {
                Rows = forensicDepartmen_HAUDataSet.ARRESTED.Select("ID_arrsted = '" + LastselectedItem.Text + "'");
                aRRESTEDTableAdapter.Delete(Convert.ToInt32(Rows[0][0]), Convert.ToString(Rows[0][1]), Convert.ToInt32(Rows[0][2]), Convert.ToDateTime(Rows[0][3]), Convert.ToString(Rows[0][4]), Convert.ToString(Rows[0][5]), Convert.ToDateTime(Rows[0][6]), Convert.ToString(Rows[0][7]));
                try { LastselectedItem.Remove(); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                aRRESTEDTableAdapter.Fill(forensicDepartmen_HAUDataSet.ARRESTED);
            }
        }

        private void listView_arrested_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LastselectedItem = e.Item;
            DataRow Row = forensicDepartmen_HAUDataSet.ARRESTED.Select("ID_arrsted = '" + LastselectedItem.Text + "'")[0];
            if (Row["Photo"].ToString() == "")
                PB_Photo.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Image\\no-photo.jpg");
            else
                PB_Photo.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Image\\" + Row["Photo"].ToString());
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            aRRESTEDBindingSource.EndEdit();
            aRRESTEDTableAdapter.Update(forensicDepartmen_HAUDataSet.ARRESTED);
            aRRESTEDTableAdapter.Fill(forensicDepartmen_HAUDataSet.ARRESTED);
            FillArrestedList();
        }

        private void ButLoad_Click(object sender, EventArgs e)
        {
            var reslt = openFileDialog1.ShowDialog();
            if(reslt == DialogResult.OK)
            {
                string newFilePath = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss") + openFileDialog1.SafeFileName;
                File.Copy(openFileDialog1.FileName, imagePath + newFilePath);
                PB_PhotoAdd.Image = Image.FromFile(imagePath + newFilePath);
                MainImagePath = newFilePath;
                TB_Photo.Text = MainImagePath;
            }
        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            DataRow[] RowGender = forensicDepartmen_HAUDataSet.GENDER.Select("Name = '" + CB_GenderAdd.Text + "'");
            string gender = Convert.ToString(RowGender[0]["ID_gender"]);
            int InsertesRows = aRRESTEDTableAdapter.Insert(TB_FIO_Add.Text, Convert.ToInt32(gender), Convert.ToDateTime(DTP_Birth.Value), TB_Place.Text, CB_BloodAdd.Text, Convert.ToDateTime(DTP_Place.Value), MainImagePath);
            if (InsertesRows == 0)
            {
                MessageBox.Show("Не удалось добавить задержанного", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Задержанный успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            aRRESTEDTableAdapter.Fill(forensicDepartmen_HAUDataSet.ARRESTED);
            FillArrestedList();
            CB_GenderAdd.Items.Clear();
            TB_FIO_Add.Text = "";
            TB_Photo.Text = "";
            TB_Place.Text = "";
            DTP_Birth.Value = DateTime.Now;
            DTP_Place.Value = DateTime.Now;
        }
    }
}
