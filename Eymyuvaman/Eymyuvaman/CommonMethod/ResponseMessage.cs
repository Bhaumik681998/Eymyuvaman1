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
        public static string UserInActive = "User account is not active.Kindly activate the account to proceed.";
        public static string AddUser = "User added successfully.";
        public static string UpdateUser = "User updated successfully.";
        public static string InvalidCredentials = "The mobile number or password you entered is incorrect. Please try again.";
        public static string EmptyCredentials = "Mobile number or password cannot be empty.";
        #endregion

        #region :: User Login ::
        public static string UserLogin = "Login successfully.";
        #endregion

        #region :: Yuvak Detail ::
        public static string AddNewYuvak = "New yuvak details have been added successfully.";
        public static string UpdateYuvakDetail = "yuvak details have been updated successfully.";
        #endregion

        #region :: sabhaSession ::
        public static string AddSabhaSession = "Sabha detail has been added successfully.";
        public static string UpdateSabhaSession = "Sabha detail has been updated successfully.";
        #endregion

        #region :: New yuvak Sabha Attend ::
        public static string AddNewYuvakSabhaAttend = "New yuvak sabha attendance has been added successfully.";
        public static string UpdateNewYuvakSabhaAttend = "yuvak sabha attendance details have been updated successfully.";
        #endregion

        #region :: Evant Detail ::
        public static string AddNewEvantDetail = "New evant details has been added successfully.";
        public static string UpdateEvantDetail = "Evant details have been updated successfully.";

        public static string AddNewEvantAreaDetail = "New evant area details has been added successfully.";
        public static string UpdateEvantAreaDetail = "Evant area details have been updated successfully.";

        public static string AddNewEvantEntryDetail = "New evant entry details has been added successfully.";
        public static string UpdateEvantEntryDetail = "Evant entry details have been updated successfully.";
        #endregion

        #region :: City ::
        public static string AddNewCityDetail = "New city details has been added successfully.";
        public static string UpdateCityDetail = "City details have been updated successfully.";
        #endregion

        #region :: Zones ::
        public static string AddNewZonesDetail = "New zones details has been added successfully.";
        public static string UpdateZonesDetail = "Zones details have been updated successfully.";
        #endregion

        #region :: Area ::
        public static string AddNewAreaDetail = "New area details has been added successfully.";
        public static string UpdateAreaDetail = "Area details have been updated successfully.";
        public static string AreaCodeAlreadyExists = "The area code already exists. Please use a different area code.";
        #endregion

        #region :: kishore ::
        public static string AddNewKishoreDetail = "New kishore details has been added successfully.";
        public static string UpdateKishoreDetail = "Kishore details have been updated successfully.";
        public static string InvalidAreaCode = "Area code is missing or invalid.";
        #endregion

        #region :: Designation ::
        public static string AddNewDesignationDetail = "New designation details has been added successfully.";
        public static string UpdateDesignationDetail = "Designation details have been updated successfully.";
        #endregion
    }
}
