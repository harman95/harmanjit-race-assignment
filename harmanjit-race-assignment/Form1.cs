using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harmanjit_race_assignment
{
    public partial class Form1 : Form
    {
        String Player = "";
        int selectedDog = 0;
        int winnerDog = 0;

        //object of the another class that is used to start the task of the game 
        Ground obj_ground = new Ground();
        Player obj_Player1 =null;


        //calling the method of the result to declare the budget 
        public void callingResult()
        {
            String[] Data = rb1.Text.ToString().Split(' ');
            if (Data.Length > 1)
            {
                String[] details =lblHarman.Text.ToString().Split(' ');
                obj_Player1 = new Player("Harman",Convert.ToInt32(details[3]),Convert.ToInt32(Data[2]),Convert.ToInt32(Data[8]));
                lblHarman.Text = obj_Player1.result(winnerDog);
                
            }

            String[] Data2 = rb2.Text.ToString().Split(' ');
            if (Data2.Length > 1)
            {
                String[] details2 = lblLaddi.Text.ToString().Split(' ');
                obj_Player1 = new Player("Laddi", Convert.ToInt32(details2[3]), Convert.ToInt32(Data2[2]), Convert.ToInt32(Data2[8]));
                lblLaddi.Text = obj_Player1.result(winnerDog);

            }

            String[] Data3 = rb3.Text.ToString().Split(' ');
            if (Data3.Length > 1)
            {
                String[] details3 = lblPinda.Text.ToString().Split(' ');
                obj_Player1 = new Player("Pinda",Convert.ToInt32(details3[3]),Convert.ToInt32(Data3[2]),Convert.ToInt32(Data3[8]));
                lblPinda.Text = obj_Player1.result(winnerDog);

            }




        }


        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1.Checked==true) {
                Player = "Harman";
            }
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2.Checked == true)
            {
                Player = "Laddi";
            }

        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3.Checked == true)
            {
                Player = "Pinda";
            }
        }

        private void rbDog1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDog1.Checked==true) {
                selectedDog = 1;
            }
        }

        private void rbDog2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDog2.Checked == true)
            {
                selectedDog = 2;
            }
        }

        private void rbDog3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDog3.Checked == true)
            {
                selectedDog = 3;
            }
        }

        private void rbDog4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDog4.Checked == true)
            {
                selectedDog = 4;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  record the details of the game that is used to set  the gamee 
            if (!Player.Equals("") && selectedDog > 0 && nmBet.Value > 0)
            {
                if (Player.Equals("Harman")) {
                    rb1.Text = "Harman choose " + selectedDog + " dog with the bet amount " + nmBet.Value;
                    button3.Enabled = true;
                }
                if (Player.Equals("Laddi"))
                {
                    rb2.Text = "Laddi choose " + selectedDog + " dog with the bet amount " + nmBet.Value;
                    button3.Enabled = true;
                }
                if (Player.Equals("Pinda"))
                {
                    rb3.Text = "Pinda choose " + selectedDog + " dog with the bet amount " + nmBet.Value;
                    button3.Enabled = true;
                }



            }
            else {
                MessageBox.Show("Select the player , dog and set the amount for the bet ");
            }

        }

        //  race  start with the timer 
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int dog = 0;
            //code to move the image 
            pbDog1.Left += obj_ground.running();
            pbDog2.Left += obj_ground.running();
            pbDog3.Left += obj_ground.running();
            pbDog4.Left += obj_ground.running();

            dog = obj_ground.winnerdog(timer1, pbDog1, 1);

            // find the winner 
            switch (dog) {
                case 1:
                    label2.Text = "Dog " + dog + " won the Race";
                    winnerDog = 1;
                    callingResult();
                break;
                case 0:
                    dog = obj_ground.winnerdog(timer1, pbDog2, 2);
                    switch (dog) {
                        case 2:
                            label2.Text = "Dog " + dog + " won the Race";
                            winnerDog = 2;
                            callingResult();
                            break;
                        default:
                            dog = obj_ground.winnerdog(timer1, pbDog3, 3);
                            switch (dog) {
                                case 3:
                                    label2.Text = "Dog " + dog + " won the Race";
                                    winnerDog = 3;
                                    callingResult();
                                    break;
                                default:
                                    dog = obj_ground.winnerdog(timer1, pbDog4, 4);
                                    switch (dog) {
                                        case 4:
                                            label2.Text = "Dog " + dog + " won the Race";
                                            winnerDog = 4;
                                            callingResult();
                                            break;

                                    }
                                    break;
                            }
                        break;
                    }
                    button2.Enabled = true;
                break;
            }
            
            

            

        }
        // reset the game 
        private void button2_Click(object sender, EventArgs e)
        {

            Player = "";

            selectedDog = 0;

            button2.Enabled = false;
            button3.Enabled = false;

            nmBet.Value = 0;

            pbDog1.Left = 0;
            pbDog2.Left = 0;
            pbDog3.Left = 0;
            pbDog4.Left = 0;

            rb1.Text = "Harman";
            rb2.Text = "Laddi";
            rb3.Text = "Pinda";


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
