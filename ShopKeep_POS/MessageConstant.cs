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
        public static String SELECT_ONE = "Please Select One Row For Delete !";

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
            public static String DOB = "Please Enter Date Of Birth !";
            public static String City = "Please Enter City !";
            public static String STATE = "Please Select Satate !";
            public static String EMAIL = "Please Enter Email !";
        }

        public static class AUTHOR
        {
            public static String AUTHOR_NAME = "Please Enter Author Name !";
        }

        public static class PUBLISHER
        {
            public static String PUB_NAME = "Please Enter Publisher Name !";
            public static String PUB_PHONE = "Please Enter Publisher Phone !";
            public static String PUB_EMAIL = "Please Enter Publisher Email !";
            public static String PUB_CITY = "Please Enter Publisher City !";
            public static String PUB_STATE = "Please Enter Publisher State !";
        }

        public static class CATEGORY
        {
            public static String CATEGORY_NAME = "Please Enter Category Name !";

        }

        public static class BOOK
        {
            public static String BOOK_TITLE = "Please Enter Book Name !";
            public static String BOOK_PRICE = "Please Enter Book Price !";
            public static String PRICE_FORMAT = "Please Check Your Price !";
        }

        public static class PURCAHSE
        {
            public static String PURCHASE_QTY = "Please Enter Quantity !";
            public static String SELECT_ONE = "Please Select One Row For Delete !";
            public static String ORDER_CONFIRM = "Please Add One Record !";
        }

        public static class SALE
        {
            public static String SALE_CONFIRM = "Please Add One Record !";
            public static String SALE_SUCCESS = "Finished Sale !";
        }

        public static class DAMAGE
        {
            public static String BOOK_NAME = "Please Choose Book Name !";
            public static String BOOK_QTY = "Please Add Book Qty !";
            public static String BOOK_REMARK = "Please Add Remark !";
            public static String CHECK_QTY = "Please Check Qty Format !";
        }

    }
}
