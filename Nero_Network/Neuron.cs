using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nero_Network
{
    public class Neuron
    {
        public static int guessCount = 0;
        public static int guessIndex = -1;
        public bool guess;
        public float[] weight;
        public int index;

        public Neuron(int N, int i)
        {
            weight = new float[N];
            index = i;
        }
        public void ChangeWeight(float Alpha, int[] X)
        {
            int length = X.Length;
            for (int i = 0; i < length; i++)       
            {                                       
                if (X[i] == 1)                   
                {
                    if (guess)
                        weight[i] -= Alpha;
                    else
                        weight[i] += Alpha;
                }
            }
        }
        public void SaveWeight()
        {
            StreamWriter save = new StreamWriter($"Weights/Weight-{index}.txt");
            for (int i = 0; i < weight.Length; i++)
            {
                save.WriteLine(weight[i]);
            }
            save.Close();
        }
        public void LoadWeight()
        {
            if (File.Exists($"Weights/Weight-{index}.txt"))
            {
                StreamReader load = new StreamReader($"Weights/Weight-{index}.txt");
                for (int i = 0; i < weight.Length; i++)
                {
                    weight[i] = Convert.ToSingle(load.ReadLine());
                }
                load.Close();
            }
        }        

        public void Check(int[] X)
        {
            float s = 0;
            int length = X.Length;
            for (int i = 0; i < length; i++)
            {
                if (X[i] == 1) //s=summ(i = 1, N, Xi * Wi)
                {
                    s += weight[i];
                }
            }
            guess = s >= 0;
        }
    }
}
