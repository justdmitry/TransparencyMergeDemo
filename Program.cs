namespace TransparencyMergeDemo
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var bg = Bitmap.FromFile("bg.png");
            var cover = Bitmap.FromFile("cover.png");

            using (var g = Graphics.FromImage(bg))
            {
                g.DrawImage(cover, 0, 0);
            }

            bg.Save($"out-{Environment.OSVersion.Platform}.png", ImageFormat.Png);
        }
    }
}
