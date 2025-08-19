namespace Eymyuvaman.CommonMethod
{
    public static class ResponseMessage
    {
        #region :: Common Message ::
        public static string Default = "An error occurred. Please try again later.";
        public static string UserNotFound = "User not found. Please make sure the user exists.";
        public static string PhoneAlreadyExists = "Phone number already exists.";
        public static string EmailAndPhoneAlreadyExist = "Email and phone number already exist.";
        public static string DataRetrieved = "Data retrieved successfully.";
        public static string NoDataFound = "No data found. Please try again later.";
        public static string UserInActive = "User inactive.";
        public static string AddUser = "User added successfully.";
        public static string UpdateUser = "User updated successfully.";
        public static string InvalidCredentials = "The mobile number or password you entered is incorrect. Please try again.";
        public static string EmptyCredentials = "Mobile number or password cannot be empty.";
        #endregion

        #region :: User Login ::
        public static string UserLogin = "Login successfully.";
        #endregion
    }
}
