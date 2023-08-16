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
    public partial class HotelDetails : Form
    {
        public Classes.Hotel GlobalHotel;
        public HotelDetails(Classes.Hotel h)
        {
            InitializeComponent();
            GlobalHotel = h;
            hotelname.Text = GlobalHotel.GetName();
            starsForm.Text = GlobalHotel.GetNumOfStars().ToString();
            numFloor.Text = GlobalHotel.GetFloor().ToString();
            NumAttraction.Text = GlobalHotel.GetAttractions().ToString();
            ServiceQform.Text = GlobalHotel.GetServiceQuality().ToString();
            pricemeter.Text = GlobalHotel.GetPriceOfMeter().ToString();
            roomsize11.Text = GlobalHotel.GetRoomSize().ToString();
            textBoxLoadPic.Text = GlobalHotel.GetPhotoPath();
        }
        private void button1_Click(object sender, EventArgs e) // Buttom Type to add
        {
            GlobalHotel.SetName(hotelname.Text);
            GlobalHotel.SetNumOfStars(Int32.Parse(starsForm.Text));
            GlobalHotel.SetFloor(Int32.Parse(numFloor.Text));
            GlobalHotel.SetServiceQuality(Int32.Parse(ServiceQform.Text));
            GlobalHotel.SetAttractions(Int32.Parse(NumAttraction.Text));
            GlobalHotel.SetPriceOfMeter(Int32.Parse(pricemeter.Text));
            GlobalHotel.SetRoomSize(Int32.Parse(roomsize11.Text));
            GlobalHotel.SetPhotoPath(textBoxLoadPic.Text);

            // הכנסת האיבר החדש לתוך הרשימה המקושרת של התכנית
            Classes.Hotel hos = new Classes.Hotel(GlobalHotel.GetName(), GlobalHotel.GetRoomSize(), GlobalHotel.GetPriceOfMeter(), GlobalHotel.GetServiceQuality(), GlobalHotel.GetAttractions(), GlobalHotel.GetNumOfStars(), GlobalHotel.GetFloor(), GlobalHotel.GetPhotoPath());
            Program.rentalPropetyCollection.RentalProperties.Add(hos);

            GlobalHotel.SetIsActive(true);
            this.Close();
        }
        private void ServiceQform_TextChanged(object sender, EventArgs e) { }
        private void HotelDetails_Load(object sender, EventArgs e) { }
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
            catch( Exception ex)
            {
               MessageBox.Show("Please enter other photo", "Save DataGirdView", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}