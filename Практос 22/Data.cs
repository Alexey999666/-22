using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практос_22.ModelsDB;

namespace Практос_22
{
     class Data
    {
        public static Subscription? subscription;
        public static bool Login = false;
        public static string UserSurname;
        public static string UserName;
        public static string UserPatronymic;
        public static string Right;
    }
    public static class Flags
    {
        public static bool FlagADD { get; set; } = false;
        public static bool FlagEdit { get; set; } = false;
        public static bool FlagView { get; set;} = false;

    }

}
