using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Controls;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math;
using Accord.Math.Optimization.Losses;
using Accord.Statistics;
using Accord.Statistics.Kernels;
using System.Data;
namespace QBM_LOGConsole
{
    class SVM_ZB
    {
        [MTAThread]//用于宣告这个程序的线程模型为多线程单元，如果说单线程则是STAThread
        
        public void linnerSVM(DataSet dataSet) {
            {
                
                int i = 0;
                string[] output = new string[dataSet.Tables[0].Rows.Count];//434行的数组
                
                int[] outputInt = new int[dataSet.Tables[0].Rows.Count];
                foreach (DataRow mDr in dataSet.Tables[0].Rows)
                {
                   output[i++] =mDr[dataSet.Tables[0].Columns.Count - 1].ToString();
                    if (output[i-1]=="差气层")
                    {
                        outputInt[i - 1] = 0;
                    }
                    else if (output[i - 1] == "气层")
                    {
                        outputInt[i - 1] = 1;
                    }
                    else if (output[i - 1] == "干层")
                    {
                        outputInt[i - 1] = -1;
                    }
                    else if (output[i - 1] == "水层")
                    {
                        outputInt[i - 1] = -1;
                    }
                    Console.WriteLine("{0},{1},{2}",output[i - 1],outputInt[i - 1], i - 1);//验证点
                 }
                
                double[][] inputs = new double[dataSet.Tables[0].Rows.Count][];
                
                Console.WriteLine(dataSet.Tables[0].Rows.Count);
                for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                {
                    inputs[j] = new double[11];//dataSet.Tables[0].Columns.Count-7
                    for (int k = 6; k < dataSet.Tables[0].Columns.Count - 1; k++)//k=6 是从第7列作为维度,-2是最后一列不算
                    {
                        Console.WriteLine(dataSet.Tables[0].Rows[j][k].ToString()); 
                        inputs[j][k-6] = Convert.ToDouble(dataSet.Tables[0].Rows[j][k].ToString());
                        Console.WriteLine("{0},{1}",j,k-6);//验证点
                    }
                    
                }              
               //var ksvm = new SupportVectorMachine(new Gaussian(), 2);
               //var ksvm = new SupportVectorMachine(11);

            //创建采用我们所给予的输入与输出的学习算法
            var smm = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 100
            };           
            
            var svm=smm.Learn(inputs, outputInt);                 
            bool[] prediction = svm.Decide(inputs);
            double error = new AccuracyLoss(outputInt).Loss(prediction);
            Console.WriteLine("error:" + error);
                // Show results on screen
                Console.WriteLine(prediction.ToZeroOne());
            ScatterplotBox.Show("Training data", inputs, outputInt);//这个窗口用于显示学习数据

            ScatterplotBox.Show("SVM results", inputs, prediction.ToZeroOne());
               


            Console.ReadKey();

        }
        }
    }

}

