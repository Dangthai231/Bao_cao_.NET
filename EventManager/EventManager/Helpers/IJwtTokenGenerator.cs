# Interface định nghĩa các hàm xử lý Auth
namespace EventManager.Helpers;

public interface IJwtTokenGenerator
{
    string GenerateToken(string userId, string userName);
    bool ValidateToken(string token, out userId, out userName);
}
```
