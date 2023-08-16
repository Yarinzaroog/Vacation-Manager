using MyVacationManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVacationManager
{
    public partial class VillaForm : Form
    {
        Classes.Villa GlobalVilla;
        public VillaForm()
        {
            InitializeComponent();
        }
        public VillaForm(Classes.Villa villa)
        {
            InitializeComponent();
            // מכניס לתוך הטקסט בוקס את פרטי האיבר    
            VillaNameForm.Text = villa.GetName();
            PoolForm.Text = villa.GetHavePool().ToString();
            YardForm.Text = villa.Getsizeofyard().ToString();
            PriceVillaForm.Text = villa.GetPriceForNight().ToString();

            if (villa.GetPhotoPath() != "")
            {
                WebRequest request = WebRequest.Create(villa.GetPhotoPath());
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        pictureBox1.Image = Bitmap.FromStream(str);
                    }
                }
            }
            GlobalVilla = villa;
        }
        private void button1_Click(object sender, EventArgs e) // Buttom Delete
        {
            GlobalVilla.SetIsActive(false);
            Program.rentalPropetyCollection.RentalProperties.Remove(GlobalVilla);
            this.Close();
        }
        private void VillaForm_Load(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) // Buttom Update
        {
            GlobalVilla.Name = VillaNameForm.Text;
            GlobalVilla.HavePool = bool.Parse(PoolForm.Text);
            GlobalVilla.Yard = int.Parse(YardForm.Text);
            PriceVillaForm.Text = GlobalVilla.GetPriceForNight().ToString();
        }
    }
}
