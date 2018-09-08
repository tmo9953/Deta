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


        //initalisation
        //<param name = "sizes" > Length of the array is amount of layers in your model and each int is the amount of neurons in that specific layer</param>
        public model(int[] sizes)
        {
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
                Console.WriteLine("network recieved: " + inputs[i]);
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
        public float[] train(float[] inputs,float[] outputs)
        {
            var getting = run(inputs);
            //get cost
            var cost = 0f;
            var i = 0;
            while(i < outputs.Length)
            {
                var t = (getting[i] - outputs[i]);
                cost += t*t;
                i++;
            }
            return null;
        }


    }
}
