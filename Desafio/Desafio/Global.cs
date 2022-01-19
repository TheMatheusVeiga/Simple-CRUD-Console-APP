using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Global
    {
        public static bool _update;
        public static int _id;
        public static bool Update
        {
            get
            {
                return _update;
            }
            set
            {
                _update = value;
            }
        }

        public static int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}
