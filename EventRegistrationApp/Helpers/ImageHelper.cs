using System.Drawing;
using System.IO;

namespace EventRegistrationApp.Helpers
{

    public static class ImageHelper
    {
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null) return null;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }


}
