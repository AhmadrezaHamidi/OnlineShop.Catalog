namespace Domain.Shop.Auth;

public class UserError
{
    public static readonly Error invalidPhoneUmber = new(
        "otp.InvalidPhonNumber",
        "PhoneNumber is not valid.");

    
    
    public static readonly Error userNotFound = new(
        "UserError.UserNotFound",
        "user is not Exist");

    

    public static readonly Error invalidNumber = new(
        "otp.InvalidNumber",
        "input  is not valid.");


    public static readonly Error expireCode = new(
        "otp.expireCode",
        "number is expired .");
}