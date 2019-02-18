using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep_POS
{
    public static class MessageConstant
    {
        public static String INSERT_MSG = "Finished Insert Process !";
        public static String UPDATE_MSG = "Finished Update Process !";
        public static String DELETE_MSG = "Finished Delete Process !";

        public static String SAVE_CONFIRM = "Do You Want To Save !";
        public static String DELETE_CONFIRM = "Do You Want To Delete !";
        public static String SELECT_ONE = "Please Select One Row For Delete !";
        public static String SELECT_ONE_UPDATE = "Please Select One Row For Update !";

        public static String SUCCESS_PROGRESS = "Finished Change Progress !";
        public static String WARNING = "Warning Window";
        public static String INFORMATION = "Inforamtion Window";

        public static class LOGIN
        {
            public static String USER_ID = "Please Enter User ID !";
            public static String PASSWORD = "Please Enter Password !";
        }
        public static class STAFF
        {
            public static String ROLE = "Please Select Staff Role !";
            public static String PASSWORD = "Password should not be empty !";
            public static String COMFIRM_PASSWORD = "Please Enter Confirm Password !";
            public static String NOT_MATCH_PASSWORD = "Please Check Again Password and Confirm Password !";
            public static String PASSWORD_PATTERN_MSG = "Password must be at least 4 characters, \nno more than 8 characters, \nmust include at least one upper case letter, \none lower case letter, \none numeric digit.";
            public static String NAME = "Please Enter Staff Name !";
            public static String ADDRESS = "Please Enter Address !";
            public static String PHONE = "Please Enter Phone Number !";
            public static String CHECK_PHONE_NO = "Please Check Your Phone Number !";
            public static String NRC = "Please Enter NRC Number !";
            public static String GENDER = "Please Select Gender !";
            public static String DOB = "Please Enter Date Of Birth !";
            public static String CITY = "Please Enter City !";
            public static String STATE = "Please Select Satate !";
            public static String EMAIL = "Please Enter Email !";
            public static String CHECK_EMAIL_ADDRESS = "Please Check Your Email Address !";
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
            public static String PUB_ADD = "Please Enter Publisher Address !";
            public static String PUB_CITY = "Please Enter Publisher City !";
            public static String PUB_STATE = "Please Enter Publisher State !";
        }

        public static class CATEGORY
        {
            public static String CATEGORY_NAME = "Please Enter Category Name !";
            public static String EXISTING_CATEGORY_NAME = "Please Update Category Name Or Record New Category Name! \nThis One Is Existing !";

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
            public static String ORDER_FINISHED = "Success Order Process !";
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
