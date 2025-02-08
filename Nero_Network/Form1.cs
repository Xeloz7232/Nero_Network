using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nero_Network
{
    public partial class Form1 : Form
    {
        public const int N = 10000;
        public static string[] NeuronNames = { "Овен", "Телец", "Близнецы", "Рак", 
                                               "Лев", "Дева", "Весы", "Скорпион",
                                               "Стрелец", "Козерог", "Водолей", "Рыбы"};
        public static int NeuronCount = NeuronNames.Length;
        public Neuron[] neuron = new Neuron[NeuronCount];
        public int lastX, lastY;
        public int[] X = new int[N];
        public const int SampleSize = 30;
        public static int[][] SampleNormal = new int[NeuronCount * SampleSize][];
        public static int[][] SampleCenter = new int[NeuronCount * SampleSize][];
        public const int TestSize = 10;
        public static int[][] TestNormal = new int[NeuronCount * TestSize][];
        public static int[][] TestCenter = new int[NeuronCount * TestSize][];
        public static Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < NeuronCount; i++)
            {
                neuron[i] = new Neuron(N, i);
                neuron[i].LoadWeight();
            }

            if (File.Exists($"Weights/time.txt"))
            {
                StreamReader load = new StreamReader($"Weights/time.txt");
                int time = Convert.ToInt32(load.ReadLine());
                int epoch = Convert.ToInt32(load.ReadLine());
                lEpoch.Text = $"Эпохи = {epoch} ({string.Format("{0:0.000}", time / 1000f)} сек)";
                load.Close();
            }

            cbWM.Items.AddRange(NeuronNames);
            cbWM.SelectedIndex = 0;
            ShowWeightMap();
            Clear(); 
            for (int n = 0; n < NeuronCount; n++)
            {
                for (int j = 0; j < SampleSize; j++)
                {
                    SampleNormal[j + n * SampleSize] = new int[N];
                    SampleCenter[j + n * SampleSize] = new int[N];
                    Bitmap bm = (Bitmap)Image.FromFile($"Sample/{NeuronNames[n]}-{j}.png");
                    for (int k = 0; k < N; k++)
                    {
                        SampleNormal[j + n * SampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Centering(bm);
                    for (int k = 0; k < N; k++)
                    {
                        SampleCenter[j + n * SampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                }
                for (int j = 0; j < TestSize; j++)
                {
                    TestNormal[j + n * TestSize] = new int[N];
                    TestCenter[j + n * TestSize] = new int[N];
                    Bitmap bm = (Bitmap)Image.FromFile($"Test/{NeuronNames[n]}-{j}.png");
                    for (int k = 0; k < N; k++)
                    {
                        TestNormal[j + n * TestSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Centering(bm);
                    for (int k = 0; k < N; k++)
                    {
                        TestCenter[j + n * TestSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                }
            }
        }

        private void Clear()
        {
            pbMain.Image = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(pbMain.Image);
            g.Clear(Color.FromArgb(255, 255, 255, 255));
            lGuess.Text = string.Empty;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void bGive_Click(object sender, EventArgs e)
        {
            Neuron.guessCount = 0;
            Neuron.guessIndex = -1;
            Bitmap bm = (Bitmap)pbMain.Image;
            if (chbCenter.Checked) pbMain.Image = Centering(bm);
            for (int i = 0; i < N; i++)
            {
                X[i] = bm.GetPixel(i % 100, i / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
            }
            for (int i = 0; i < NeuronCount; i++)
            {
                neuron[i].Check(X);
                if (neuron[i].guess && Neuron.guessCount == 0)
                {
                    Neuron.guessCount++;
                    Neuron.guessIndex = i;
                }
                else if (neuron[i].guess && Neuron.guessCount > 0)
                {
                    Neuron.guessCount++;
                    Neuron.guessIndex = -1;
                }
            }
            if (Neuron.guessIndex == -1) lGuess.Text = "?";
            else lGuess.Text = NeuronNames[Neuron.guessIndex];
        }

        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X, y = e.Y;
            Pen p = new Pen(Color.Black, 5);
            Graphics g = Graphics.FromImage(pbMain.Image);
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, lastX, lastY, x, y);
            }
            p.Dispose(); g.Dispose();
            pbMain.Invalidate();
            lastX = x; lastY = y;
        }

        private void StartTraining()
        {
            int[][] Sample = chbCenter.Checked ? SampleCenter : SampleNormal;
            lRight.Text = "Угадал";
            bool noMistakes = false;
            int Epoch = -1;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int n = 0; n < NeuronCount; n++)
            {
                for (int i = 0; i < N; i++)
                {
                    neuron[n].weight[i] = r.Next(-30, 30) / 100f;
                }
            }
            do
            {
                Epoch++;
                noMistakes = true;
                int[] Counter = new int[NeuronCount * SampleSize];
                for (int i = 0; i < SampleSize * NeuronCount; i++)
                {
                    Counter[i] = i;
                }
                do
                {
                    int g = r.Next(0, Counter.Length); 
                    for (int i = 0; i < NeuronCount; i++)
                    {
                        neuron[i].Check(Sample[Counter[g]]);
                        if (neuron[i].guess && i != Counter[g] / SampleSize || !neuron[i].guess && i == Counter[g] / SampleSize)
                        {
                            neuron[i].ChangeWeight((float)nudAlpha.Value, Sample[Counter[g]]);
                            noMistakes = false;
                        }
                    }
                    for (int i = g; i < Counter.Length - 1; i++)
                    {
                        Counter[g] = Counter[g + 1];
                    }
                    Array.Resize(ref Counter, Counter.Length - 1);
                } while (Counter.Length != 0);
            } while (!noMistakes);
            stopWatch.Stop();
            lEpoch.Text = $"Эпохи = {Epoch} ({string.Format("{0:0.000}", stopWatch.ElapsedMilliseconds / 1000f)} сек)";
            ShowWeightMap();
            logs.Items.Clear();
            if (lGuess.Text != string.Empty)
                lGuess.Text = "Повторите";
            for (int i = 0; i < NeuronCount; i++)
            {
                neuron[i].SaveWeight();
            }
            StreamWriter time = new StreamWriter($"Weights/time.txt");
            time.WriteLine(stopWatch.ElapsedMilliseconds);
            time.WriteLine(Epoch);
            time.Close();

        }
        private void bStartTesting_Click(object sender, EventArgs e)
        {
            logs.Items.Clear();
            int[][] Test = chbCenter.Checked ? TestCenter : TestNormal;
            bool Mistake = false;
            float Right = 0; float Wrong = 0;
            int[] Counter = new int[NeuronCount * TestSize];
            var errNeuron = new List<string>();
            for (int k = 0; k < TestSize * NeuronCount; k++)
            {
                Mistake = false;
                for (int i = 0; i < NeuronCount; i++)
                {
                    neuron[i].Check(Test[k]);
                    if (neuron[i].guess && i != k / TestSize || !neuron[i].guess && i == k / TestSize)
                    {
                        Mistake = true;
                        errNeuron.Add(NeuronNames[i]);
                    }
                }
                if (Mistake)
                {
                    Wrong++;
                    logs.Items.Add($"Изображение ({NeuronNames[k / TestSize]}-{k - (k / TestSize) * TestSize}) - не угадал.");
                    logs.Items.Add("Ошибка на:");
                    foreach (var error in errNeuron)
                    {
                        logs.Items.Add($"- {error}");
                    }
                    logs.Items.Add("");
                    errNeuron.Clear();
                }
                else Right++;
            }
            lRight.Text = $"Угадал = {Math.Round(Right / (Right + Wrong) * 100f, 2)}% ({Right}/{Wrong})";
        }
        private void bTeachTest_Click(object sender, EventArgs e)
        {
            StartTraining();
            bStartTesting_Click(sender, e);
        }

        #region Карта весов
        private void cbWM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowWeightMap();
        }
        public float function(float x, float a, float b)
        {
            float y;
            if (x <= a)
                y = 0;
            else if (x > a && x < b)
                y = (x - a) / (b - a);
            else y = 1;
            return y;
        }
        public void ShowWeightMap()
        {
            float temp;
            Bitmap bm = new Bitmap(100, 100);
            for (int i = 0; i < N; i++)
            {
                temp = 1 - function(neuron[cbWM.SelectedIndex].weight[i], -1f, 1f);
                bm.SetPixel(i % 100, i / 100, Color.FromArgb(255, (int)(255 * temp), (int)(255 * temp), (int)(255 * temp)));
            }
            pbWM.Image = bm;
        }

        private void bIndexLeft_Click(object sender, EventArgs e)
        {
            if (cbWM.SelectedIndex > 0)
                cbWM.SelectedIndex--;
            else cbWM.SelectedIndex = NeuronNames.Length - 1;
        }
        private void bIndexRight_Click(object sender, EventArgs e)
        {
            if (cbWM.SelectedIndex < NeuronNames.Length - 1)
                cbWM.SelectedIndex++;
            else cbWM.SelectedIndex = 0;
        }

        #endregion

        private void bHelp_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Show();
        }

        public Bitmap Centering(Bitmap bm)
        {
            int height, width;
            int minX = 100, maxX = 0, minY = 100, maxY = 0;
            int[] imageArray = new int[10000];
            for (int i = 0; i < N; i++)
            {
                int curX = i % 100;
                int curY = i / 100;
                imageArray[i] = bm.GetPixel(curX, curY) == Color.FromArgb(255, 255, 255, 255) ? 0 : 1;
                if (imageArray[i] == 1)
                {
                    if (curX > maxX) maxX = curX;
                    if (curX < minX) minX = curX;
                    if (curY > maxY) maxY = curY;
                    if (curY < minY) minY = curY;
                }
            }
            width = maxX - minX + 1;
            height = maxY - minY + 1;

            int offsetX = (100 - width) / 2;
            int offsetY = (100 - height) / 2;
            if (!(width < 0 || height < 0))
            {
                Bitmap png = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int index = (y + minY) * 100 + (x + minX);
                        if (imageArray[index] == 1)
                            png.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                        else
                            png.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                    }
                }
                Bitmap centeredPNG = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(centeredPNG);
                g.Clear(Color.FromArgb(255, 255, 255, 255));
                g.DrawImage(png, offsetX, offsetY);
                return centeredPNG;
            }
            else
                MessageBox.Show("При центрировании произошла ошибка!");
            return bm;
        }
    }    
}
