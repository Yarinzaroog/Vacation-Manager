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
    public partial class HotelForm : Form
    {
        Classes.Hotel GlobalHotel;
        public HotelForm()
        {
            InitializeComponent();
        }
        public HotelForm(Classes.Hotel hotel)
        {
            InitializeComponent();
            // מכניס לתוך הטקסט בוקס את פרטי האיבר    
            hotelname.Text = hotel.GetName();
            starsForm.Text = hotel.GetNumOfStars().ToString();
            numFloor.Text = hotel.GetFloor().ToString();
            NumAttraction.Text = hotel.GetAttractions().ToString();
            ServiceQformhotel.Text = hotel.GetServiceQuality().ToString();
            price.Text = hotel.GetPriceForNight().ToString();

            if (hotel.GetPhotoPath() != "")
            {
                WebRequest request = WebRequest.Create(hotel.GetPhotoPath());
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        pictureBox1.Image = Bitmap.FromStream(str);
                    }
                }

            }
            GlobalHotel = hotel;

        }
        private void HotelForm_Load(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) // Buttom Delete
        {
            GlobalHotel.SetIsActive(false);
            Program.rentalPropetyCollection.RentalProperties.Remove(GlobalHotel);
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) // Buttom Update
        {
            GlobalHotel.Name = hotelname.Text;
            GlobalHotel.Stars = int.Parse(starsForm.Text);
            GlobalHotel.Floor = int.Parse(numFloor.Text);
            GlobalHotel.Attractions = int.Parse(NumAttraction.Text);
            GlobalHotel.ServiceQuality = int.Parse(ServiceQformhotel.Text);
            price.Text = GlobalHotel.GetPriceForNight().ToString();
        }
    }
}
