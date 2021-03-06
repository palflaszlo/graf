﻿using System;
using System.Collections.Generic;

namespace GrafFeladat_CSharp
{
    /// <summary>
    /// Irányítatlan, egyszeres gráf.
    /// </summary>
    class Graf
    {
        int csucsokSzama;
        /// <summary>
        /// A gráf élei.
        /// Ha a lista tartalmaz egy(A, B) élt, akkor tartalmaznia kell
        /// a(B, A) vissza irányú élt is.
        /// </summary>
        readonly List<El> elek = new List<El>();
        /// <summary>
        /// A gráf csúcsai.
        /// A gráf létrehozása után új csúcsot nem lehet felvenni.
        /// </summary>
        readonly List<Csucs> csucsok = new List<Csucs>();

        /// <summary>
        /// Létehoz egy úgy, N pontú gráfot, élek nélkül.
        /// </summary>
        /// <param name="csucsok">A gráf csúcsainak száma</param>
        public Graf(int csucsok)
        {
            this.csucsokSzama = csucsok;

            // Minden csúcsnak hozzunk létre egy új objektumot
            for (int i = 0; i < csucsok; i++)
            {
                this.csucsok.Add(new Csucs(i));
            }
        }

        /// <summary>
        /// Hozzáad egy új élt a gráfhoz.
        /// Mindkét csúcsnak érvényesnek kell lennie:
        /// 0 &lt;= cs &lt; csúcsok száma.
        /// </summary>
        /// <param name="cs1">Az él egyik pontja</param>
        /// <param name="cs2">Az él másik pontja</param>
        public void Hozzaad(int cs1, int cs2)
        {
            if (cs1 < 0 || cs1 >= csucsokSzama ||
                cs2 < 0 || cs2 >= csucsokSzama)
            {
                throw new ArgumentOutOfRangeException("Hibas csucs index");
            }

            // Ha már szerepel az él, akkor nem kell felvenni
            foreach (var el in elek)
            {
                if (el.Csucs1 == cs1 && el.Csucs2 == cs2)
                {
                    return;
                }
            }

            elek.Add(new El(cs1, cs2));
            elek.Add(new El(cs2, cs1));
        }

        public override string ToString()
        {
            string str = "Csucsok:\n";
            foreach (var cs in csucsok)
            {
                str += cs + "\n";
            }
            str += "Elek:\n";
            foreach (var el in elek)
            {
                str += el + "\n";
            }
            return str;
        }



        public void szelessegiBejar(int kezdoPont)
        {
            bool[] bejart = new bool[csucsokSzama];
            Stack<int> stack = new Stack<int>();
            bejart[kezdoPont] = true;
            stack.Push(kezdoPont);
            while(stack.Count != 0)
            {
                kezdoPont = stack.Pop();
                Console.WriteLine("következő -> " + kezdoPont);
                foreach (int i in )
                {
                    if (!bejart[i])
                    {
                        bejart[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }


        public void melysegBejar(int kezdoPont)
        {
            //bool[] bejart = new bool[csucsokSzama];
            List<int> bejart = new List<int>();
            //bejart[kezdoPont] = true;
            bejart.Add(kezdoPont);
            
            
        }

        public void meylsegrekrz(int KezdoPont, List<int> marbejart)
        {
            Console.WriteLine(this.csucsok[KezdoPont]);
            foreach (var item in this.elek)
            {
                if (true)
                {
                    marbejart.Add();
                    this.meylsegrekrz();
                }
            }
        }


        public void osszefuggoseg()
        {
            for (int i = 0; i < Aristas.GetLength(0); i++)
            {
                // Assume it's not connected unless shown otherwise.
                bool nodeIsConnected = false;

                // Check the column and row at the same time:
                for (int j = 0; j < Aristas.GetLength(1); j++)
                {
                    if (Aristas[i, j] != 0 || Aristas[j, i] != 0)
                    {
                        // It was non-zero; must have at least one connection.
                        nodeIsConnected = true;
                        break;
                    }
                }

                // Is the current node connected?
                if (!nodeIsConnected)
                {
                    return false;
                }

            }

            // All ok otherwise:
            return true;
        }

    }
}