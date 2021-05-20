using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class Moat : DefenceUnit
    {
        private static int default_defense = 250;
        public CastleForm form;
        public Moat() : base()
        {
            form = CastleForm.rectangle;
        }
        public Moat(CastleForm _form) : base()
        {
            form = _form;
        }
    }
}
