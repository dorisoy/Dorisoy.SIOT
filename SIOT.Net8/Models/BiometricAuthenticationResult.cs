using SIOT.Enums;

namespace SIOT.Models;

public class BiometricAuthenticationResult
{
    public BiometricAuthenticationStatus Status { get; set; }
    public string ErrorMessage { get; set; }
}