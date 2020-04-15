using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Commons
{
    public static class ACCOUNT
    {
        public static int WRONG_PASSWORD = -1;
        public static int WAS_BANNED = -2;
        public static int WAS_UNACTIVE = -3;
        public static int UNKNOW_ERROR = -4;
        public static int NOT_EXIST = -5;
        public static int LOGIN_SUCCESS = 1;
    }
}