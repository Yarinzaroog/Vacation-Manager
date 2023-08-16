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
    public partial class VillaDetails : Form
    {
        public Classes.Villa GlobalVilla;

        public VillaDetails(Classes.Villa villa)
        {
            InitializeComponent();
            GlobalVilla = villa;
            VillaNameForm.Text = villa.GetName();
            PoolForm.Text = villa.GetHavePool().ToString();
            YardForm.Text = villa.Getsizeofyard().ToString();
            pricemeter.Text = villa.GetPriceOfMeter().ToString();
            roomsize11.Text = villa.GetRoomSize().ToString();
            textBoxLoadPic.Text = villa.GetPhotoPath();
        }
        private void VillaDetails_Load(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) // Buttom Type too add
        {
            GlobalVilla.SetName(VillaNameForm.Text);
            GlobalVilla.SetHavePool(true);
            GlobalVilla.SetSizeOfYard(Int32.Parse(YardForm.Text));
            GlobalVilla.SetPriceOfMeter(Int32.Parse(pricemeter.Text));
            GlobalVilla.SetRoomSize(Int32.Parse(roomsize11.Text));
            GlobalVilla.SetPhotoPath(textBoxLoadPic.Text);

            // הכנסת האיבר החדש לתוך הרשימה המקושרת של התכנית
            Classes.Villa hos = new Classes.Villa(GlobalVilla.GetName(), GlobalVilla.GetRoomSize(), GlobalVilla.GetPriceOfMeter(), GlobalVilla.GetHavePool(), GlobalVilla.Getsizeofyard(), GlobalVilla.GetPhotoPath());
            Program.rentalPropetyCollection.RentalProperties.Add(hos);

            GlobalVilla.SetIsActive(true);
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e) // Buttom load image
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
