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
                if(i < inputs.Length)
                    lays[0].neu[i].input = inputs[i];
                else
                    lays[0].neu[i].input = 0f;
                //Console.WriteLine("network recieved: " + inputs[i]);
                i++;
            }

            //get outputs
            var r = lays[lays.Length - 1].neu.Length;//total amount of outputs
            var op = new float[r];
            var output_layer = lays.Length - 1;

            i = 0;
            while(i < r)
            {
                op[i] = lays[output_layer].neu[i].get(lays, output_layer);
                i++;
            }


            return op;
        }

        //<summary>Run with training/summary>
        public void train(data_set[] training_data, int cycles, float learning_rate)
        {
            
            for (int r = 0; r < cycles; r++)
            {
                
                


                for (var u = 1; u < lays.Length; u++)
                {
                    for (var t = 0; t < lays[u].neu.Length; t++)
                    {
                        foreach (data_set d in training_data)
                        {
                            var cost = get_cost(d.inputs, d.outputs);
                            var res_w = lays[u].neu[t].weights;
                            var res_b = lays[u].neu[t].bias;


                            for (int e = 0; e < lays[u].neu[t].weights.Length; e++)
                            {
                                lays[u].neu[t].weights[e] += (float)(Math.Sin(ran.Next()) * learning_rate * cost);
                            }
                            lays[u].neu[t].bias += (float)(Math.Sin(ran.Next()) * learning_rate * cost);



                            var w = get_cost(d.inputs, d.outputs);
                            if (w > cost)
                            {
                                //Console.WriteLine("FAILED  with a cost of: " + w.ToString());
                                lays[u].neu[t].bias = res_b;
                                lays[u].neu[t].weights = res_w;
                                //Console.WriteLine("FAILED");
                            }
                            else
                            {
                                //Console.WriteLine("SUCCESS with a cost of: " + cost);
                            }
                        }
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
                var t = outputs[i] - getting[i];
                cost += (t * t)/2;
                i++;
            }
            return cost;
        }



    }
}
