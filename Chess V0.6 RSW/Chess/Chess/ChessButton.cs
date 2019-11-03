using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Chess
{
    public class ChessButton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Dolumu { get; set; }
        public Board ChessBoard { get; set; }
       
        public Tas Tas { get; set; }
        
        public void GetBackgroundİmage()
        {
            if (this.Tas==null)
            {
                this.Image = null;
            }
            else
            {
                this.Image = Image.FromFile(this.Tas.Backgroundİmage);
            }
            
        }
    }
   
  
}
