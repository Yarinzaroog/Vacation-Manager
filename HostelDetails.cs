using MyVacationManager.Classes;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace MyVacationManager
{
    public partial class HostelDetails : Form
    {
        public Classes.Hostel GlobalHostel;
        public HostelDetails(Classes.Hostel hos)
        {
            InitializeComponent();

            GlobalHostel = hos;
            hostelnameForm.Text = GlobalHostel.GetName();
            NumBedForm.Text = GlobalHostel.GetNumBed().ToString();
            TyperoomForm.Text = GlobalHostel.GetTypeOfRoom();
            AttractionsHostelform.Text = GlobalHostel.GetAttractions().ToString();
            ServiceQform.Text = GlobalHostel.GetServiceQuality().ToString();
            pricemeter.Text = GlobalHostel.GetPriceOfMeter().ToString();
            roomsize11.Text = GlobalHostel.GetRoomSize().ToString();
            textBoxLoadPic.Text = GlobalHostel.GetPhotoPath();
        }
        private void HostelDetails_Load(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) // Buttom Type to add
        {
            GlobalHostel.SetName(hostelnameForm.Text);
            GlobalHostel.SetNumOfBed(Int32.Parse(NumBedForm.Text));
            GlobalHostel.SetTypeOfRoom(TyperoomForm.Text);
            GlobalHostel.SetServiceQuality(Int32.Parse(ServiceQform.Text));
            GlobalHostel.SetAttractions(Int32.Parse(AttractionsHostelform.Text));
            GlobalHostel.SetPriceOfMeter(Int32.Parse(pricemeter.Text));
            GlobalHostel.SetRoomSize(Int32.Parse(roomsize11.Text));
            GlobalHostel.SetPhotoPath(textBoxLoadPic.Text);

            // הכנסת האיבר החדש לתוך הרשימה המקושרת של התכנית
            Classes.Hostel hos = new Classes.Hostel(GlobalHostel.GetName(), GlobalHostel.GetRoomSize(), GlobalHostel.GetPriceOfMeter(), GlobalHostel.GetServiceQuality(), GlobalHostel.GetAttractions(), GlobalHostel.GetNumBed(), GlobalHostel.GetTypeOfRoom(), GlobalHostel.GetPhotoPath());
            Program.rentalPropetyCollection.RentalProperties.Add(hos);

            GlobalHostel.SetIsActive(true);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Buttom Load image
        {
            try
            {
                WebRequest request = WebRequest.Create(textBoxLoadPic.Text);
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        pictureBox1.Image = Bitmap.FromStream(str);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter other photo", "Save DataGirdView", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
