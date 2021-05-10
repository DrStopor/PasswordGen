using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGen.buildSymbols
{
    class BuildingSymbols
    {
        private Array languages;
        private List<char> listSetSymbols = new List<char>();
        public BuildingSymbols(Array listLang)
        {
            if (listLang == null || listLang.Length == 0)
            {
                throw new Exception("Intialized array can't empty");
            }

            foreach (string value in listLang)
            {
                switch (value)
                {
                    case "rusLarge":
                        listSetSymbols.AddRange(RusLarge());
                        break;
                    case "rusSmall":
                        listSetSymbols.AddRange(RusSmall());
                        break;
                    case "engLarge":
                        listSetSymbols.AddRange(EngLarge());
                        break;
                    case "engSmall":
                        listSetSymbols.AddRange(EngSmall());
                        break;
                    case "number":
                        listSetSymbols.AddRange(Number());
                        break;
                    case "symbol":
                        listSetSymbols.AddRange(Symbol());
                        break;
                    default:
                        break;
                }
            }
        }

        public List<char> GetListSetSymbols()
        {
            return listSetSymbols;
        }

        private static List<char> EngSmall()
        {
            List<char> result = new List<char>();
            for (int i = 93; i < 124; i++)
            {
                result.Add((char)i);
            }
            return result;
        }

        private static List<char> EngLarge()
        {
            List<char> result = new List<char>();
            for (int i = 65; i < 92; i++)
            {
                result.Add((char)i);
            }
            return result;
        }

        private static List<char> RusSmall()
        {
            List<char> result = new List<char>();
            for (int i = 1072; i < 1105; i++)
            {
                result.Add((char)i);
            }
            return result;
        }

        private static List<char> RusLarge()
        {
            List<char> result = new List<char>();
            for (int i = 1040; i < 1072; i++)
            {
                result.Add((char)i);
            }
            return result;
        }

        private static List<char> Number()
        {
            List<char> result = new List<char>();
            for (int i = 48; i < 58; i++)
            {
                result.Add((char)i);
            }
            return result;
        }

        private static List<char> Symbol()
        {
            List<int> setValue = new List<int>();

            for(int i = 33, end = 48; i < end; i++)
            {
                setValue.Add(i);
            }
            for (int i = 58, end = 65; i < end; i++)
            {
                setValue.Add(i);
            }
            for (int i = 91, end = 97; i < end; i++)
            {
                setValue.Add(i);
            }
            for (int i = 123, end = 127; i < end; i++)
            {
                setValue.Add(i);
            }
            // 33 - 47      58 - 64     91 - 96     123 - 126       один из пробелов 127
            List<char> result = new List<char>();
            setValue.ForEach(delegate(int value)
            {
                result.Add((char)value);
            });
            return result;
        }
    }


}
