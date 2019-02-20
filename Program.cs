namespace TransparencyMergeDemo
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using SixLabors.ImageSharp.Processing;
    using SixLabors.ImageSharp;
    using ISImage = SixLabors.ImageSharp.Image;

    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var bg = Bitmap.FromFile("bg.png"))
            {
                using (var cover = Bitmap.FromFile("cover.png"))
                {

                    using (var g = Graphics.FromImage(bg))
                    {
                        g.DrawImage(cover, 0, 0);
                    }
                }
                bg.Save($"out-drawingcommon-{Environment.OSVersion.Platform.ToString().ToLowerInvariant()}.png", ImageFormat.Png);
            }

            using (var bg = ISImage.Load("bg.png"))
            {
                using (var cover = ISImage.Load("cover.png"))
                {
                    bg.Mutate(o => o.DrawImage(cover, 1));
                }

                bg.Save($"out-imagesharp-{Environment.OSVersion.Platform.ToString().ToLowerInvariant()}.png");
            }
        }
    }
}
