using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TextToImage
{
    public partial class Form1 : Form
    {
        public Bitmap TextImage;
        private Color unknown = Color.White;
        private string OkChars = @"!""#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private string BlueChars = @"!""#$%&'()*+,-./";
        private string MagentaChars = @"0123456789:;<=>";
        private string RedChars = @"?@ABCDEFGHIJKLMN";
        private string YellowChars = @"OPQRSTUVWXYZ[\]^";
        private string GreenChars = @"_`abcdefghijklmn";
        private string CyanChars = @"opqrstuvwxyz{|}~";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length < 1)
            {
                return;
            }
            string[] boxl = richTextBox1.Lines;
            int height = boxl.Length;
            int width = 0;
            for (var i = 0; i < boxl.Length; i++)
            {
                if (boxl[i].Length > width)
                {
                    width = boxl[i].Length;
                }
            }
            TextImage = new Bitmap(width,height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    TextImage.SetPixel(x,y,Color.Black);
                }
            }
            for (var i = 0; i < boxl.Length; i++)
            {
                for (var i1 = 0; i1 < boxl[i].ToCharArray().Length; i1++)
                {
                    char c = boxl[i].ToCharArray()[i1];
                    if (OkChars.Contains(c))
                    {
                        Color pixelColor = new Color();
                        //===========================
                        
                        //B->M:(0, 0, 255)
                        //    +..
                        if (BlueChars.Contains(c))
                        {
                            double hoff = 255 / BlueChars.Length;
                            double intensity = BlueChars.IndexOf(c) * hoff;
                            pixelColor = Color.FromArgb((int) intensity, 0, 255);
                        }
                        //M->R:(255, 0, 255)
                        //    ..-
                        if (MagentaChars.Contains(c))
                        {
                            double hoff = 255 / MagentaChars.Length;
                            double intensity = MagentaChars.IndexOf(c) * hoff;
                            pixelColor = Color.FromArgb(255, 0, 255 - (int)intensity);
                        }
                        //R->Y:(255, 0, 0)
                        //    .+.
                        if (RedChars.Contains(c))
                        {
                            double hoff = 255 / RedChars.Length;
                            double intensity = RedChars.IndexOf(c) * hoff;
                            pixelColor = Color.FromArgb(255, (int) intensity, 0);
                        }
                        //Y->G:(255, 255, 0)
                        //    -..
                        if (YellowChars.Contains(c))
                        {
                            double hoff = 255 / YellowChars.Length;
                            double intensity = YellowChars.IndexOf(c) * hoff;
                            pixelColor = Color.FromArgb(255 - (int) intensity, 255, 0);
                        }
                        //G->C:(0, 255, 0)
                        //    ..+
                        if (GreenChars.Contains(c))
                        {
                            double hoff = 255 / GreenChars.Length;
                            double intensity = GreenChars.IndexOf(c) * hoff;
                            pixelColor = Color.FromArgb(0, 255, (int) intensity);
                        }
                        //C->B:(0, 255, 255)
                        //    .-.
                        if (CyanChars.Contains(c))
                        {
                            double hoff = 255 / CyanChars.Length;
                            double intensity = CyanChars.IndexOf(c) * hoff;
                            pixelColor = Color.FromArgb(0, 255 - (int) intensity, 255);
                        }
                        //============================
                        TextImage.SetPixel(i1,i,pixelColor);
                    }
                    else
                    {
                        if (c != ' ')
                        {
                            TextImage.SetPixel(i1, i, unknown);
                        }
                    }
                }
            }
            //save bitmap
            TextImage.Save(@"C:\Users\usagi\Desktop\image.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            int width = (int) numericUpDown1.Value;
            int height = (int)Math.Ceiling((double) text.Length / width);
            int x = 0;
            int y = 0;
            TextImage = new Bitmap(width, height);
            for (int y1 = 0; y1 < height; y1++)
            {
                for (int x1 = 0; x1 < width; x1++)
                {
                    TextImage.SetPixel(x1,y1,Color.Black);
                }
            }
            foreach (char c in text)
            {
                if (x >= width)
                {
                    x = 0;
                    y++;
                }
                if (OkChars.Contains(c))
                {
                    Color pixelColor = new Color();
                    //===========================

                    //B->M:(0, 0, 255)
                    //    +..
                    if (BlueChars.Contains(c))
                    {
                        double hoff = 255 / BlueChars.Length;
                        double intensity = BlueChars.IndexOf(c) * hoff;
                        pixelColor = Color.FromArgb((int)intensity, 0, 255);
                    }
                    //M->R:(255, 0, 255)
                    //    ..-
                    if (MagentaChars.Contains(c))
                    {
                        double hoff = 255 / MagentaChars.Length;
                        double intensity = MagentaChars.IndexOf(c) * hoff;
                        pixelColor = Color.FromArgb(255, 0, 255 - (int)intensity);
                    }
                    //R->Y:(255, 0, 0)
                    //    .+.
                    if (RedChars.Contains(c))
                    {
                        double hoff = 255 / RedChars.Length;
                        double intensity = RedChars.IndexOf(c) * hoff;
                        pixelColor = Color.FromArgb(255, (int)intensity, 0);
                    }
                    //Y->G:(255, 255, 0)
                    //    -..
                    if (YellowChars.Contains(c))
                    {
                        double hoff = 255 / YellowChars.Length;
                        double intensity = YellowChars.IndexOf(c) * hoff;
                        pixelColor = Color.FromArgb(255 - (int)intensity, 255, 0);
                    }
                    //G->C:(0, 255, 0)
                    //    ..+
                    if (GreenChars.Contains(c))
                    {
                        double hoff = 255 / GreenChars.Length;
                        double intensity = GreenChars.IndexOf(c) * hoff;
                        pixelColor = Color.FromArgb(0, 255, (int)intensity);
                    }
                    //C->B:(0, 255, 255)
                    //    .-.
                    if (CyanChars.Contains(c))
                    {
                        double hoff = 255 / CyanChars.Length;
                        double intensity = CyanChars.IndexOf(c) * hoff;
                        pixelColor = Color.FromArgb(0, 255 - (int)intensity, 255);
                    }
                    //============================
                    TextImage.SetPixel(x, y, pixelColor);
                    x++;
                }
                else
                {
                    if (c != ' ')
                    {
                        TextImage.SetPixel(x, y, unknown);
                        x++;
                    }
                }
            }
            TextImage.Save(@"C:\Users\usagi\Desktop\image.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;
            List<int[]> it = new List<int[]>();
            foreach (var l in lines)
            {
                char[] c = l.ToCharArray();
                int[] t = new int[c.Length];
                for (var i = 0; i < c.Length; i++)
                {
                    t[i] = c[i];
                }
                it.Add(t);
            }
            richTextBox1.Text = "";
            foreach (var its in it)
            {
                foreach (var i in its)
                {
                    char[] chr = ("" + i).ToCharArray();
                    string total = "";
                    for (var i1 = 0; i1 < chr.Length; i1++)
                    {
                        string cur = "";
                        char c = chr[i1];
                        if (c == '0')
                        {
                            cur = "z#Ro`";
                        }
                        if (c == '1')
                        {
                            cur = "%iNg`";
                        }
                        if (c == '2')
                        {
                            cur = "tW!n`";
                        }
                        if (c == '3')
                        {
                            cur = "t#rE`";
                        }
                        if (c == '4')
                        {
                            cur = "SqU*`";
                        }
                        if (c == '5')
                        {
                            cur = "P3Nt`";
                        }
                        if (c == '6')
                        {
                            cur = "H#6a`";
                        }
                        if (c == '7')
                        {
                            cur = "W3Ek`";
                        }
                        if (c == '8')
                        {
                            cur = ")Ct0`";
                        }
                        if (c == '9')
                        {
                            cur = "N1n#`";
                        }
                        total += cur;
                    }
                    richTextBox1.Text += total+ @" ";
                }
                richTextBox1.Text += "\n";
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}