using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harmanjit_race_assignment
{
    public interface run{
        int running();
    }
   public class Ground : run
    {
        //object of the random class 
        Random obj_rd = new Random();
        int width = 680;

        // find the winner dog from the game 
        public int winnerdog(Timer tm,PictureBox pb, int dog) {
            if (pb.Left > width)
            {
                tm.Stop();
                return dog;
            }
            else {
                return 0;
            }
        }

        // random no of the dog 
        public int running() {
            return obj_rd.Next(1,40);
        }


    }
}
