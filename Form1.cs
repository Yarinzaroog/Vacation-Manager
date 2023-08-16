using MyVacationManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WMPLib;
using System.Xml.Serialization;

namespace MyVacationManager
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            player.URL = "musicrental.mp3";
            LoadDataFromCollection();
            chooseadd.SelectedIndex = 1;
        }
        private void LoadDataFromCollection()
        {
            dataGridView1.Rows.Clear();

            int i = 0;
            foreach (Classes.RentalProperty rp in Program.rentalPropetyCollection.RentalProperties)
            {
                if (rp.GetIsActive())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = rp.GetName();
                    dataGridView1.Rows[i].Cells[1].Value = rp.GetPriceForNight();
                    if (rp is Classes.Hostel)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "Hostel";
                    }
                    if (rp is Classes.Hotel)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "Hotel";
                    }
                    if (rp is Classes.Villa)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "Villa";
                    }
                    i++;
                }
            }
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e) // Buttom Add
        {
            string choosen = chooseadd.SelectedItem.ToString();

            if (choosen == "Hotel")
            {
                Classes.Hotel hl = new Classes.Hotel();
                HotelDetails AddHotel = new HotelDetails(hl);
                AddHotel.ShowDialog();
            }
            if (choosen == "Hostel")
            {
                Classes.Hostel hos = new Classes.Hostel();
                HostelDetails AddHostel = new HostelDetails(hos);
                AddHostel.ShowDialog();
            }
            if (choosen == "Villa")
            {
                Classes.Villa vil = new Classes.Villa();
                VillaDetails AddVilla = new VillaDetails(vil);
                AddVilla.ShowDialog();
            }
            LoadDataFromCollection();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) // Buttom Exit
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to Exit", "Save DataGirdView", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void chooseadd_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e) // Buttom Keep all changes
        {
            DialogResult iSave;
            iSave = MessageBox.Show("Confirm if you want to Save", "Save DataGirdView", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iSave == DialogResult.Yes)
            {
                IFormatter formatter = new BinaryFormatter();
                // "data.mdl" שמירת הנתונים לתוך קובץ בשם 
                using (Stream stream = new FileStream("data.mdl", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, Program.rentalPropetyCollection);
                }

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // לחיצה כפולה על הטבלה פותחת חלון עם כל הנתונים של אותו נכס להשכרה
            if ((dataGridView1.SelectedCells.Count > 0) || (dataGridView1.SelectedRows.Count > 0))
            {
                int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                String name = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                // מחפשת בתוך הרשימה המקושרת את הנכס עם השם הנבחר
                Classes.RentalProperty rental = Program.rentalPropetyCollection.FindbyName(name);

                if (rental is Classes.Hotel)
                {
                    HotelForm hform = new HotelForm((Classes.Hotel)rental);
                    hform.Show();
                }

                if (rental is Classes.Hostel)
                {
                    HostelForm aform = new HostelForm((Classes.Hostel)rental);
                    aform.Show();
                }

                if (rental is Classes.Villa)
                {
                    VillaForm lform = new VillaForm((Classes.Villa)rental);
                    lform.Show();
                }

                LoadDataFromCollection();
            }
        }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e) // Buttom load
        {
            Stream stream = File.Open("data.mdl", FileMode.Open);
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Program.rentalPropetyCollection = (RentalPropetyCollection)binaryFormatter.Deserialize(stream);
            stream.Close();
            LoadDataFromCollection();
        }
    }
}