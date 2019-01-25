using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep_POS
{
    public static class MessageConstant
    {
        public static String INSERT_MSG = "Finished Insert !";
        public static String UPDATE_MSG = "Finished Update !";
        public static String DELETE_MSG = "Finished Delete !";

        public static String SAVE_CONFIRM = "Are You Sure Save !";
        public static String DELETE_CONFIRM = "Are You Sure Delete !";

        public static class LOGIN
        {
            public static String USER_ID = "Please Enter User ID !";
            public static String PASSWORD = "Please Enter Password !";
        }
        public static class STAFF
        {
            public static String ROLE = "Please Select Staff Role !";
            public static String PASSWORD = "Please Enter Password !";
            public static String COMFIRM_PASSWORD = "Please Enter Confirm Password !";
            public static String NOT_MATCH_PASSWORD = "Please Check Again Password and Confirm Password !";
            public static String NAME = "Please Enter Staff Name !";
            public static String ADDRESS = "Please Enter Address !";
            public static String PHONE = "Please Enter Phone Number !";
            public static String NRC = "Please Enter NRC Number !";
            public static String GENDER = "Please Select Gender !";
            public static String City = "Please Enter City !";
            public static String STATE = "Please Select Satate !";
            public static String EMAIL = "Please Enter Email !";
        }

        public static class AUTHOR
        {
            public static String AUTHOR_NAME = "Please Enter Author Name !";
        }
       
    }
}
