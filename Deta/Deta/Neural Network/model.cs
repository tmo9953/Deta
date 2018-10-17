using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deta.Neural_Network
{
    class model
    {
        //coco butter
        public layer[] lays;
        public string name;
        public Random ran;

        //initalisation
        //<param name = "sizes" > Length of the array is amount of layers in your model and each int is the amount of neurons in that specific layer</param>
        public model(int[] sizes, string _name, int seed)
        {
            ran = new Random();
            name = _name;
            //size is a array of the layer sizes
            lays = new layer[sizes.Length];
            var i = 1;
            lays[0] = new layer(sizes[0], 0, i);//input layer is initalised before bc theres nothing before it
            while (i < lays.Length)
            {
                lays[i] = new layer(sizes[i], sizes[i-1],i);
                i++;
            }
        }

        //<summary>standard run, no training</summary>
        public float[] run(float[] inputs)
        {
            //input inputs
            var i = 0;
            while(i < lays[0].neu.Length)
            {
                lays[0].neu[i].input = inputs[i];
                //Console.WriteLine("network recieved: " + inputs[i]);
                i++;
            }

            //get outputs
            var r = lays[lays.Length - 1].neu.Length;//total amount of outputs
            var op = new float[r];

            i = 0;
            while(i < r)
            {
                op[i] = lays[r].neu[i].get(lays,r);
                i++;
            }


            return op;
        }

        //<summary>Run with training/summary>
        public void train(float[] inputs,float[] outputs, int cycles, float learning_rate)
        {
            for (int r = 0; r < cycles; r++)
            {
                var cost = get_cost(inputs, outputs);
                var restore = lays;


                for (var u = 1; u < lays.Length; u++)
                {
                    for (var t = 0; t < lays[u].neu.Length; t++)
                    {
                        for (int e = 0; e < lays[u].neu[t].weights.Length; e++)
                        {
                            lays[u].neu[t].weights[e] += (float)(Math.Sin(ran.Next()) * learning_rate * cost);
                        }
                        lays[u].neu[t].bias += (float)(Math.Sin(ran.Next()) * learning_rate * cost);
                    }
                }



                var w = get_cost(inputs, outputs);
                if (w > cost)
                {
                    //Console.WriteLine("FAILED  with a cost of: " + w.ToString());
                    lays = restore;
                    Console.WriteLine("FAILED");
                }
                else
                {
                    try
                    {
                        Console.WriteLine("SUCCESS with a cost of: " + w.ToString().Substring(0, 6) + "    " + cost);
                    }
                    catch
                    {
                        
                    }
                }
            }
        }

        public float get_cost(float[] inputs, float[] outputs)
        {
            var getting = run(inputs);
            //get cost
            var cost = 0f;
            var i = 0;
            while (i < outputs.Length)
            {
                var t =  getting[i] - outputs[i];
                cost += t * t;
                i++;
            }
            return cost;
        }



    }
}
