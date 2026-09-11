using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPractics.Services
{
    public static class IdGenerator
    {
        private static int _id = 1;

        public static int GetNextId()
        {
            return _id++;
        }
    }
}
