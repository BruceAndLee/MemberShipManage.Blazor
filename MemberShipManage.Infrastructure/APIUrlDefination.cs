using System;
using System.Collections.Generic;
using System.Text;

namespace MemberShipManage.Infrastructurer
{
    public class APIUrlDefination
    {
        #region customer

        public const string CUSTOMER_CREATE = "customer/create";
        public const string CUSTOMER_UPDATE = "customer/update";
        public const string CUSTOMER_GET_ALL = "customer/get/all";
        public const string CUSTOMER_GET = "customer/get";

        #endregion

        #region

        public const string USER_GET = "user/get?userno={0}&password={1}";

        #endregion

        #region token
        public const string TOKEN_GENERATE = "tokengenerate/generatejwt";
        #endregion
    }
}
