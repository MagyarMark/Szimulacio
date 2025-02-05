using System.Drawing;
using System.Windows.Forms;

namespace KalandJatek
{
    public partial class Form2 : Form
    {

        public Form2() 
        {
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Image myimage = new Bitmap("main.png");
            this.BackgroundImage = myimage;
        }

    }
}