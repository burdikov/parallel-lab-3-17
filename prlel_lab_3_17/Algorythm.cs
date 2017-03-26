using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prlel_lab_3_17
{
    class Instance
    {
        /// <summary>
        /// Количество атрибутов наблюдений.
        /// </summary>
        public static int AttributeCount;

        /// <summary>
        /// Имена атрибутов.
        /// </summary>
        public static string[] AttributeNames = null;

        /// <summary>
        /// Значения атрибутов.
        /// </summary>
        public double[] AttributeValues;

        /// <summary>
        /// Принадлежность к кластеру.
        /// </summary>
        public int Cluster;

        /// <summary>
        /// Убедитесь в том, что значение AttributeCount отлично от 0, прежде
        /// чем вызывать этот конструктор.
        /// </summary>
        public Instance()
        {
            AttributeValues = new double[AttributeCount];
        }

    }

    class Algorythm
    {
        public static List<Instance> Instances = null;

        public static int ReadInstancesFromFile(
            string path,
            char attribDelimeter = ',',
            char instDelimeter = '\n'
            )
        {
            var f = File.ReadAllText(path);
            var arrs = f
                .Split(instDelimeter)
                .Select(str => str.Split(attribDelimeter))
                .ToArray();

            Instance.AttributeCount = arrs[0].Length;
            Instance.AttributeNames = arrs[0];

            Instances = new List<Instance>();

            for (int i = 1; i < arrs.Length; i++)
            {
                var ok = true;
                var inst = new Instance();

                for (int j = 0; j < arrs[i].Length; j++)
                {
                    double d;
                    if (!Double.TryParse(arrs[i][j], out d)) { ok = false; break; }
                    else inst.AttributeValues[j] = d;
                }
                if (ok) Instances.Add(inst);
            }

            return Instances.Count();
        }
    }
}
