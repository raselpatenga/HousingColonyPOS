namespace Common
{
    public static class Constants
    {
        #region Replaceable Messages
        public static readonly string NotFound = "{0} not found";
        public static readonly string Invalid = "{0} is invalid";
        #endregion
        public static readonly string ExceptionMessage = "Something went wrong. Please try after sometime.";
        public static readonly string AccountLocked = "Account is locked, Please try after sometime.";
        public static readonly string UserCreation = "User created Successfully.";
        public static readonly string ServerError = "Something went wrong, please try again after sometime";
        public static readonly string SuccessfulLogin = "Login successful";
        public static readonly string FailedLogin = "Username or password is wrong";
        public static readonly string AddSuccess = "Added successfully";
        public static readonly string UpdateSuccess = "Updated successfully";
        public static readonly string AlreadyExists = "This name already exists";
        public static readonly string RemoveSuccess = "Removed successfully";
        public static readonly string AlreadyDeactive = "Already Deactive"; 
        public static readonly string AlreadyActive = "Already Active";  
        public static readonly string SentEamil = "If email is correct then email sent to user successfully";  
        public static int UserId;
        public static void SetUserID(int Userid)
        {
            UserId = Userid;

        }
    }
}
