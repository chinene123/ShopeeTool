using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopee
{
    public class DataBitmap
    {
        public Bitmap network;
        public Bitmap google;
        public Bitmap user;
        public Bitmap anhshopee;
        public DataBitmap()
        {
            anhshopee = (Bitmap)Bitmap.FromFile("Img//anhshopee.png");
            user = (Bitmap)Bitmap.FromFile("Img//user.png");
            google = (Bitmap)Bitmap.FromFile("Img//google.png");
            network = (Bitmap)Bitmap.FromFile("Img//network.png");
        }
    }
}
