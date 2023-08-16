using MyVacationManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVacationManager
{
    public partial class HostelForm : Form
    {
        Classes.Hostel GlobalHostel;
        public HostelForm(Classes.Hostel hostel)
        {
            InitializeComponent();
            // מכניס לתוך הטקסט בוקס את פרטי האיבר    
            hostelnameForm.Text = hostel.GetName();
            NumBedForm.Text = hostel.GetNumBed().ToString();
            TyperoomForm.Text = hostel.GetTypeOfRoom();
            AttractionsHostelform.Text = hostel.GetAttractions().ToString();
            ServiceQform.Text = hostel.GetServiceQuality().ToString();
            PriceHostelForm.Text = hostel.GetPriceForNight().ToString();

            if (hostel.GetPhotoPath() != "")
            {
                WebRequest request = WebRequest.Create(hostel.GetPhotoPath());
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        pictureBox1.Image = Bitmap.FromStream(str);
                    }
                }
            }
            GlobalHostel = hostel;
        }
        private void label7_Click(object sender, EventArgs e) { }
        private void HostelForm_Load(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) // Buttom Delete
        {
            GlobalHostel.SetIsActive(false);
            Program.rentalPropetyCollection.RentalProperties.Remove(GlobalHostel);
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void hostelnameForm_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) // Buttom Update
        {
            GlobalHostel.Name = hostelnameForm.Text;
            GlobalHostel.NumOfBed = int.Parse(NumBedForm.Text);
            GlobalHostel.TypeOfRoom = TyperoomForm.Text;
            GlobalHostel.Attractions = int.Parse(AttractionsHostelform.Text);
            GlobalHostel.ServiceQuality = int.Parse(ServiceQform.Text);
            PriceHostelForm.Text = GlobalHostel.GetPriceForNight().ToString();
        }
        private void PriceHostelForm_TextChanged(object sender, EventArgs e) { }
    }
}
