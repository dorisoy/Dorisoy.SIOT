using SIOT.Models;

namespace SIOT.Services;

public interface IBiometricAuthenticationService
{
    public Task<bool> CheckIfBiometricsAreAvailableAsync();
    public Task<BiometricAuthenticationResult> AuthenticateAsync(string title, string message);
}