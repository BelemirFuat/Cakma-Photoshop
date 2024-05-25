using System.Numerics;
using System.Security.Policy;
using System.Windows.Forms;

namespace cakmaPhotoshopV2
{
    public partial class Form1 : Form
    {
        class Edge
        {
            public Point startingPoint = new Point();
            public Point endingPoint = new Point();

            public Edge(int startX, int endX, int startY, int endY)
            {
                startingPoint.X = startX;
                startingPoint.Y = startY;
                endingPoint.X = endX;
                endingPoint.Y = endY;
            }
            public Edge(Point startPoint, Point EndPoint)
            {
                startingPoint = startPoint;
                endingPoint = EndPoint;
            }
            public int getstartX()
            {
                return startingPoint.X;
            }
            public int getendX()
            {
                return endingPoint.X;
            }
            public int getstartY() { return startingPoint.Y; }
            public int getendY() { return endingPoint.Y; }
        };

        private List<Edge> listOfEdges = new List<Edge>();
        private int OldWidth;
        private int OldHeight;
    
        private List<Point> listOfThePoints = new List<Point>();
        private Point thePrevPoint;
        int area;
        int[,] matriceOfInsidePoints;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OldWidth = this.Width;
            OldHeight = this.Height;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Width = (int)(control.Width * (float)this.Width / (float)this.OldWidth);
                control.Height = (int)(control.Height * (float)this.Height / (float)this.OldHeight);

                control.Left = (int)(control.Left * (float)this.Width / (float)this.OldWidth);
                control.Top = (int)(control.Top * (float)this.Height / (float)this.OldHeight);
            }
            OldWidth = this.Width;
            OldHeight = this.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogOfTheFile = new OpenFileDialog();

            dialogOfTheFile.Filter = "Resim Dosyaları (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";


            dialogOfTheFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (dialogOfTheFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(dialogOfTheFile.FileName);

                    
                    Bitmap inputImage = new Bitmap(pictureBox1.Image);
                    Bitmap croppedImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Graphics grafik = Graphics.FromImage(croppedImage);
                    grafik.DrawImage(inputImage, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    pictureBox1.Image = croppedImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1) || (comboBox2.SelectedIndex == -1) || (comboBox3.SelectedIndex == -1))
            {
                MessageBox.Show("Lütfen Önce Tüm Seçimleri Yapınız.");
            }
            else
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    applyMeanFilterToImage();
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    applyMedianFilterToImage();
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    applyGaussianFilterToImage();
                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    applyEdgeSharpenFilterToImage();
                }
                else if (comboBox2.SelectedIndex == 4)
                {
                    applykernelMatriceForGaussianMatriceFilterToImage();
                }
            }
        }

        private void applyMeanFilterToImage(int internalUsing = 0)
        {
            Bitmap inputImage, outputImage;
            inputImage = new Bitmap(pictureBox1.Image);
            int widthOfTheImage = inputImage.Width;
            int heightOfTheImage = inputImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);

            int sizeOfTheTemplate = 2 * comboBox3.SelectedIndex + 3;

            int meanr, meang, meanb;
            for (int i = (sizeOfTheTemplate - 1) / 2; i < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; i++) 
            {
                for (int j = (sizeOfTheTemplate - 1) / 2; j < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; j++) 
                {
                    if (matriceOfInsidePoints[i, j] == Math.Abs(area - internalUsing))
                    {
                        int sumR = 0, sumG = 0, sumB = 0; 
                        for (int x = -(sizeOfTheTemplate - 1) / 2; x <= (sizeOfTheTemplate - 1) / 2; x++) 
                        {
                            for (int y = -(sizeOfTheTemplate - 1) / 2; y <= (sizeOfTheTemplate - 1) / 2; y++) 
                            {
                                Color readColor = inputImage.GetPixel(i + x, j + y); 
                                sumR += readColor.R;
                                sumG += readColor.G;
                                sumB += readColor.B;
                            }
                        }
                        meanr = sumR / (sizeOfTheTemplate * sizeOfTheTemplate);
                        meang = sumG / (sizeOfTheTemplate * sizeOfTheTemplate);
                        meanb = sumB / (sizeOfTheTemplate * sizeOfTheTemplate);

                        if (meanr < 0)
                            meanr = 0;
                        if (meang < 0)
                            meang = 0;
                        if (meanb < 0)
                            meanb = 0;

                        if (meanr > 255)
                            meanr = 255;
                        if (meang > 255)
                            meang = 255;
                        if (meanb > 255)
                            meanb = 255;

                        outputImage.SetPixel(i, j, Color.FromArgb(meanr, meang, meanb)); 
                    }
                    else
                        outputImage.SetPixel(i, j, inputImage.GetPixel(i, j));
                }
            }           
            pictureBox2.Image = pictureBox1.Image;
            pictureBox1.Image = outputImage;

        }

        private void applyMedianFilterToImage()
        {
            Bitmap inputImage, outputImage;
            inputImage = new Bitmap(pictureBox1.Image);
            int widthOfTheImage = inputImage.Width;
            int heightOfTheImage = inputImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);

            int sizeOfTheTemplate = 2 * comboBox3.SelectedIndex + 3;


            for (int i = (sizeOfTheTemplate - 1) / 2; i < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; i++) 
            {
                for (int j = (sizeOfTheTemplate - 1) / 2; j < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; j++) 
                {
                    if (matriceOfInsidePoints[i, j] == area)
                    {
                        List<int> adjacentR = new List<int>();
                        List<int> adjacentG = new List<int>();
                        List<int> adjacentB = new List<int>();

                        for (int x = -(sizeOfTheTemplate - 1) / 2; x <= (sizeOfTheTemplate - 1) / 2; x++) 
                        {
                            for (int y = -(sizeOfTheTemplate - 1) / 2; y <= (sizeOfTheTemplate - 1) / 2; y++) 
                            {
                                Color readColor = inputImage.GetPixel(i + x, j + y); 
                                adjacentR.Add(readColor.R);
                                adjacentG.Add(readColor.G);
                                adjacentB.Add(readColor.B);
                            }
                        }
                        adjacentR.Sort();
                        adjacentG.Sort();
                        adjacentB.Sort();
                        int R, G, B;

                        R = adjacentR[sizeOfTheTemplate * sizeOfTheTemplate / 2];
                        G = adjacentG[sizeOfTheTemplate * sizeOfTheTemplate / 2];
                        B = adjacentB[sizeOfTheTemplate * sizeOfTheTemplate / 2];

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (R < 0) R = 0;
                        if (G < 0) G = 0;
                        if (B < 0) B = 0;

                        outputImage.SetPixel(i, j, Color.FromArgb(R, G, B)); 
                    }
                    else
                        outputImage.SetPixel(i, j, inputImage.GetPixel(i, j)); 
                }
            }
            pictureBox2.Image = pictureBox1.Image;
            pictureBox1.Image = outputImage;

        }

        private void applyGaussianFilterToImage()
        {
            Bitmap inputImage, outputImage;
            inputImage = new Bitmap(pictureBox1.Image);
            int widthOfTheImage = inputImage.Width;
            int heightOfTheImage = inputImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);

            int sizeOfTheTemplate = 2 * comboBox3.SelectedIndex + 3;

            double sigmaForGaussian = 1.5; 
            double[,] kernelMatriceForGaussian = new double[sizeOfTheTemplate, sizeOfTheTemplate];
            double sum = 0;
            for (int x = 0; x < sizeOfTheTemplate; x++)
            {
                for (int y = 0; y < sizeOfTheTemplate; y++)
                {
                    int breadthX = x - (sizeOfTheTemplate - 1) / 2;
                    int breadthY = y - (sizeOfTheTemplate - 1) / 2;
                    kernelMatriceForGaussian[x, y] = Math.Exp(-(breadthX * breadthX + breadthY * breadthY) / (2 * sigmaForGaussian * sigmaForGaussian));
                    sum += kernelMatriceForGaussian[x, y];
                }
            }

            for (int x = 0; x < sizeOfTheTemplate; x++)
            {
                for (int y = 0; y < sizeOfTheTemplate; y++)
                {
                    kernelMatriceForGaussian[x, y] /= sum;
                }
            }

            for (int i = (sizeOfTheTemplate - 1) / 2; i < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; i++)
            {
                for (int j = (sizeOfTheTemplate - 1) / 2; j < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; j++)
                {
                    if (matriceOfInsidePoints[i, j] == area)
                    {
                        double sumR = 0, sumG = 0, sumB = 0;
                        for (int x = 0; x < sizeOfTheTemplate; x++)
                        {
                            for (int y = 0; y < sizeOfTheTemplate; y++)
                            {
                                Color readColor = inputImage.GetPixel(i + x - (sizeOfTheTemplate - 1) / 2, j + y - (sizeOfTheTemplate - 1) / 2);
                                double weight = kernelMatriceForGaussian[x, y];
                                sumR += readColor.R * weight;
                                sumG += readColor.G * weight;
                                sumB += readColor.B * weight;
                            }
                        }
                        int R, G, B;

                        R = (int)sumR;
                        G = (int)sumG;
                        B = (int)sumB;

                        if (R > 255)
                            R = 255;
                        if (G > 255)
                            G = 255;
                        if (B > 255)
                            B = 255;

                        if (R < 0)
                            R = 0;
                        if (G < 0)
                            G = 0;
                        if (B < 0)
                            B = 0;

                        outputImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                    else
                        outputImage.SetPixel(i, j, inputImage.GetPixel(i, j));
                }
            }
            pictureBox2.Image = pictureBox1.Image;
            pictureBox1.Image = outputImage;

        }
        private Bitmap applyMeanFilterToImageButReturningABitmap(int internalUsing = 0)
        {
            Bitmap inputImage, outputImage;
            inputImage = new Bitmap(pictureBox1.Image);
            int widthOfTheImage = inputImage.Width;
            int heightOfTheImage = inputImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);

            int sizeOfTheTemplate = 2 * comboBox3.SelectedIndex + 3;

            int meanr, meang, meanb;
            for (int i = (sizeOfTheTemplate - 1) / 2; i < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; i++) 
            {
                for (int j = (sizeOfTheTemplate - 1) / 2; j < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; j++) 
                {
                    if (matriceOfInsidePoints[i, j] == Math.Abs(area - internalUsing))
                    {
                        int sumR = 0, sumG = 0, sumB = 0; 
                        for (int x = -(sizeOfTheTemplate - 1) / 2; x <= (sizeOfTheTemplate - 1) / 2; x++) 
                        {
                            for (int y = -(sizeOfTheTemplate - 1) / 2; y <= (sizeOfTheTemplate - 1) / 2; y++) 
                            {
                                Color readColor = inputImage.GetPixel(i + x, j + y); 
                                sumR += readColor.R;
                                sumG += readColor.G;
                                sumB += readColor.B;
                            }
                        }
                        meanr = sumR / (sizeOfTheTemplate * sizeOfTheTemplate);
                        meang = sumG / (sizeOfTheTemplate * sizeOfTheTemplate);
                        meanb = sumB / (sizeOfTheTemplate * sizeOfTheTemplate);

                        if (meanr < 0)
                            meanr = 0;
                        if (meang < 0)
                            meang = 0;
                        if (meanb < 0)
                            meanb = 0;

                        if (meanr > 255)
                            meanr = 255;
                        if (meang > 255)
                            meang = 255;
                        if (meanb > 255)
                            meanb = 255;

                        outputImage.SetPixel(i, j, Color.FromArgb(meanr, meang, meanb)); 

                    }
                    else
                        outputImage.SetPixel(i, j, inputImage.GetPixel(i, j)); 
                }
            }
            return outputImage;


        }

        private void applyEdgeSharpenFilterToImage()
        {

            Bitmap originalImage = new Bitmap(pictureBox1.Image);
            Bitmap blurredImage = applyMeanFilterToImageButReturningABitmap(0);

            Bitmap EdgeImage = removeOriginalFromBlurredImage(originalImage, blurredImage);
            Bitmap SummedImage = SumWithEdgeAndOriginal(originalImage, EdgeImage);
            
            pictureBox2.Image = pictureBox1.Image;
            pictureBox1.Image = SummedImage;
        }

        public Bitmap removeOriginalFromBlurredImage(Bitmap originalImage, Bitmap blurredImage)
        {
            Color readColor1, readColor2, convertedColor;
            Bitmap outputImage;
            int widthOfTheImage = originalImage.Width;
            int heightOfTheImage = originalImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);

            int R, G, B;
            double scaleValue = 2; 

            int sizeOfTheTemplate = 2 * comboBox3.SelectedIndex + 3;


            for (int x = (sizeOfTheTemplate - 1) / 2; x < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; x++) 
            {
                for (int y = (sizeOfTheTemplate - 1) / 2; y < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; y++) 
                {
                    if (matriceOfInsidePoints[x, y] == area)
                    {
                        readColor1 = originalImage.GetPixel(x, y);
                        readColor2 = blurredImage.GetPixel(x, y);
                        R = Convert.ToInt16(scaleValue * Math.Abs(readColor1.R - readColor2.R));
                        G = Convert.ToInt16(scaleValue * Math.Abs(readColor1.G - readColor2.G));
                        B = Convert.ToInt16(scaleValue * Math.Abs(readColor1.B - readColor2.B));

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (R < 0) R = 0;
                        if (G < 0) G = 0;
                        if (B < 0) B = 0;

                        convertedColor = Color.FromArgb(R, G, B);
                        outputImage.SetPixel(x, y, convertedColor);

                    }
                    else
                        outputImage.SetPixel(x, y, originalImage.GetPixel(x, y));
                }
            }
            return outputImage;
        }

        public Bitmap SumWithEdgeAndOriginal(Bitmap originalImage, Bitmap EdgeImage)
        {
            Color readColor1, readColor2, convertedColor;
            Bitmap outputImage;
            int widthOfTheImage = originalImage.Width;
            int heightOfTheImage = originalImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);
            int R, G, B;
            int sizeOfTheTemplate = 2 * comboBox3.SelectedIndex + 3;

            for (int x = (sizeOfTheTemplate - 1) / 2; x < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; x++) 
            {
                for (int y = (sizeOfTheTemplate - 1) / 2; y < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; y++) 
                {
                    if (matriceOfInsidePoints[x, y] == area)
                    {
                        readColor1 = originalImage.GetPixel(x, y);
                        readColor2 = EdgeImage.GetPixel(x, y);
                        R = readColor1.R + readColor2.R;
                        G = readColor1.G + readColor2.G;
                        B = readColor1.B + readColor2.B;

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (R < 0) R = 0;
                        if (G < 0) G = 0;
                        if (B < 0) B = 0;
                        convertedColor = Color.FromArgb(R, G, B);
                        outputImage.SetPixel(x, y, convertedColor);
                    }
                    else
                        outputImage.SetPixel(x, y, originalImage.GetPixel(x, y));
                }
            }
            return outputImage;
        }



        private void applykernelMatriceForGaussianMatriceFilterToImage()
        {
            Color readColor;
            Bitmap inputImage, outputImage;
            inputImage = new Bitmap(pictureBox1.Image);
            int widthOfTheImage = inputImage.Width;
            int heightOfTheImage = inputImage.Height;
            outputImage = new Bitmap(widthOfTheImage, heightOfTheImage);
            int sizeOfTheTemplate = 3;
            int elementSize = sizeOfTheTemplate * sizeOfTheTemplate;
            int i, j, SumR, SumG, SumB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int sumOfTheMatrice = 3;


            for (int x = (sizeOfTheTemplate - 1) / 2; x < matriceOfInsidePoints.GetLength(0) - (sizeOfTheTemplate - 1) / 2; x++) 
            {
                for (int y = (sizeOfTheTemplate - 1) / 2; y < matriceOfInsidePoints.GetLength(1) - (sizeOfTheTemplate - 1) / 2; y++) 
                {
                    if (matriceOfInsidePoints[x, y] == area)
                    {
                        SumR = 0;
                        SumG = 0;
                        SumB = 0;
                        int k = 0;
                        for (i = -((sizeOfTheTemplate - 1) / 2); i <= (sizeOfTheTemplate - 1) / 2; i++)
                        {
                            for (j = -((sizeOfTheTemplate - 1) / 2); j <= (sizeOfTheTemplate - 1) / 2; j++)
                            {
                                readColor = inputImage.GetPixel(x + i, y + j);
                                SumR = SumR + readColor.R * Matris[k];
                                SumG = SumG + readColor.G * Matris[k];
                                SumB = SumB + readColor.B * Matris[k];
                                k++;
                            }
                        }
                        R = SumR / sumOfTheMatrice;
                        G = SumG / sumOfTheMatrice;
                        B = SumB / sumOfTheMatrice;
                        if (R > 255)
                        {
                            R = 255;
                        }
                        if (G > 255)
                        {
                            G = 255;
                        }
                        if (B > 255)
                        {
                            B = 255;
                        }
                        if (R < 0)
                        {
                            R = 0;
                        }
                        if (G < 0)
                        {
                            G = 0;
                        }
                        if (B < 0)
                        {
                            B = 0;
                        }
                        outputImage.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    else
                        outputImage.SetPixel(x, y, inputImage.GetPixel(x, y));
                }
            }

            pictureBox2.Image = pictureBox1.Image;
            pictureBox1.Image = outputImage;
        }


        private bool checkIfItsAPolygonOrNot(int x, int y)
        {
            int numVertices = listOfEdges.Count;

            bool inside = false;
            for (int i = 0; i < numVertices; i++)
            {
                int startX = listOfEdges[i].getstartX();
                int startY = listOfEdges[i].getstartY();
                int endX = listOfEdges[i].getendX();
                int endY = listOfEdges[i].getendY();
                if (((startY > y) != (endY > y)) && (x < (endX - startX) * (y - startY) / (endY - startY) + startX))
                {
                    inside = !inside;
                }
            }
            return inside;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    
                    pictureBox1.Cursor = Cursors.Cross;
                    break;
                case 1:
                    
                    pictureBox1.Cursor = Cursors.Hand;
                    break;
                case 2:
                    pictureBox1.Cursor = Cursors.PanWest;
                    break;
                default:
                    pictureBox1.Cursor = Cursors.Default;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point em = pictureBox1.PointToClient(MousePosition);
            label4.Text = em.X.ToString() + " " + em.Y.ToString();
            label7.Text = pictureBox1.Size.ToString();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point em = pictureBox1.PointToClient(MousePosition);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    kalem(em);
                    break;
                case 1:
                    matriceOfInsidePoints = new int[pictureBox1.Image.Width, pictureBox1.Image.Height];

                    for (int i = 0; i < matriceOfInsidePoints.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriceOfInsidePoints.GetLength(1); j++)
                        {
                            if (checkIfItsAPolygonOrNot(i, j))
                            {
                                matriceOfInsidePoints[i, j] = 1;
                            }
                            else
                            {
                                matriceOfInsidePoints[i, j] = 0;
                            }
                        }
                    }

                    if (matriceOfInsidePoints[em.X, em.Y] == 1)
                        area = 1;
                    else
                        area = 0;



                    listBox2.Items.Add(area.ToString());
                    break;
                default:
                    MessageBox.Show("Önce tool seçiniz!");
                    break;
            }

        }
        private double breadth(Point startPoint, Point EndPoint)
        {
            double dx = EndPoint.X - startPoint.X;
            double dy = EndPoint.Y - startPoint.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        private void kalem(Point em)
        {
            if (listOfThePoints.Count != 0)
            {
                if (breadth(listOfThePoints.First(), em) <= 5)
                    em = listOfThePoints.First();
                thePrevPoint = listOfThePoints.Last();
                if (thePrevPoint != em)
                {
                    listBox1.Items.Add(em.ToString());
                    if (listOfThePoints.Count > 0)
                    {
                        listBox2.Items.Add(thePrevPoint.ToString() + "->" + em.ToString());
                        Edge geciciEdge = new Edge(thePrevPoint, em);
                        listOfEdges.Add(geciciEdge);
                        pictureBox1.Invalidate();
                    }
                    listOfThePoints.Add(em);
                }

            }
            else
            {
                listBox1.Items.Add(em.ToString());
                listOfThePoints.Add(em);
                pictureBox1.Invalidate();
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listOfThePoints.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listOfEdges.Clear();
            pictureBox1.Invalidate();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point point in listOfThePoints)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - 5, point.Y - 5, 10, 10);
            }
            Pen pen = new Pen(Pens.Red.Color, 3);
            
            if ((listOfThePoints.Count >= 2))
            {

                for (int i = 1; i < listOfThePoints.Count; i++)
                {
                    e.Graphics.DrawLine(pen, listOfThePoints[i - 1], listOfThePoints[i]);
                }
            }
        }
    }
}
