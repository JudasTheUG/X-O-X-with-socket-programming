using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimSinamaOdev
{
    public class Reflex
    {
        private int count=0;
        private int buttonHolder = 0;
        private List<Button> buttons ;
        private Random rand;
        private int check=0;

        public Reflex()
        {
            buttons = new List<Button>();
            rand = new Random();
            buttonHolder = rand.Next(0, 8);
        }

        private void receptorControl(Button button1, Button button2, Button button3)
        {
            if ((button1.Text == button2.Text) && (button3.Image == null) && (button1.Image != null))
            { button3.PerformClick(); count++; }
            else if ((button1.Text == button3.Text) && (button2.Image == null) && (button1.Image != null))
            { button2.PerformClick(); count++; }
            else if ((button2.Text == button3.Text) && (button1.Image == null) && (button2.Image != null))
            { button1.PerformClick(); count++; }
            else
            { check++;}



        }

        public void suddenReflex(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6, Button b7, Button b8, Button b9)
        {
            buttons.Add(b1); buttons.Add(b2); buttons.Add(b3); buttons.Add(b4); buttons.Add(b5); buttons.Add(b6); buttons.Add(b7); buttons.Add(b8); buttons.Add(b9);

            if (check==0)
            {
                receptorControl(b1, b2, b3);
            }
            if (check ==1)
            {
                receptorControl(b4, b5, b6);
            }
            if (check ==2)
            {
                receptorControl(b7, b8, b9);
            }
            if (check ==3)
            {
                receptorControl(b1, b4, b7);
            }
            if (check ==4)
            {
                receptorControl(b2, b5, b8);
            }
            if (check ==5)
            {
                receptorControl(b3, b6, b9);
            }
            if (check ==6)
            {
                receptorControl(b1, b5, b9);
            }
            if (check ==7)
            {
                receptorControl(b3, b5, b7);
            }

            if (count == 0)
            {
                while (buttons[buttonHolder].Image != null)
                {
                    buttonHolder = rand.Next(0, 8);
                }

                buttons[buttonHolder].PerformClick();
            }

            check = 0;



        }


    }
}
