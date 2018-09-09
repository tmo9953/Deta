using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deta.Neural_Network
{
    class neuron
    {
        public float[] weights;
        public float bias;
        public float input;

        public neuron(int pre_layer_amount)
        {
            weights = new float[pre_layer_amount];
            var i = 0;
            var r = new Random(69);
            while(i < weights.Length)
            {
                weights[i] = (r.Next(5000)/2500f)-1;
                i++;
            }
            bias = (r.Next(5000) / 2500f)-1;
        }



        public float get(layer[] lay,int index)
        {
            var op = 0f;

            //get values from previous layer
            var i = 0;
            foreach (neuron n in lay[index-1].neu)
            {
                var u = 0f;
                if (index > 1)
                {
                    u = n.get(lay, index - 1);
                }
                else
                {
                    //if the input layer is before
                    u = lay[index-1].neu[i].input;
                }
                op += u*weights[i];
                i++;
            }
            op = sigmoid(op+bias);

            return op;
        }




        float sigmoid(float x)
        {
            return 1 / (1 + (float)Math.Exp(-x));
        }
    }







    class layer
    {
        int size;
        public neuron[] neu;

        public layer(int _size,int pre_layer_size, int index)
        {
            //Initalisation
            size = _size;
            neu = new neuron[size];
            var i = 0;
            while(i < neu.Length)
            {
                neu[i] = new neuron(pre_layer_size);
                i++;
            }
        }


    }

}
