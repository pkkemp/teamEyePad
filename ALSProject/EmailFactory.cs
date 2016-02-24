using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{
    public static class EmailFactory
    {
        private static ComposeEmail ComposeEmail;

        public static ComposeEmail GetComposeEmail()
        {
            if (ComposeEmail == null)
                ComposeEmail = new ComposeEmail(true);      //Change this
            return ComposeEmail;
        }
    }
}
