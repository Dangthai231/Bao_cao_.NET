# 🔐 ASP.NET Core JWT Authentication & Authorization

Module này cung cấp giải pháp xác thực (Authentication) và phân quyền (Authorization) sử dụng **JSON Web Token (JWT)** cho ứng dụng ASP.NET Core. Kiến trúc được thiết kế theo mô hình Clean Architecture / N-Tier giúp dễ dàng mở rộng và bảo trì.

## 🚀 Công nghệ sử dụng
*   **Framework:** ASP.NET Core (C#)
*   **Authentication:** JWT Bearer
*   **Mã hóa mật khẩu:** BCrypt.Net-Next
*   **Database ORM:** Entity Framework Core

---

## 📂 Cấu trúc thư mục

Module được tổ chức thành các thành phần chính sau:

```text
├── Controllers/
│   └── AuthController.cs      # Chứa các endpoint API Đăng nhập/Đăng ký
├── DTOs/Auth/                 # Các Object truyền nhận dữ liệu (Login/Register/Response)
├── Models/
│   └── User.cs                # Entity map với bảng Users trong Database
├── Services/
│   └── AuthService.cs         # Chứa Business logic (Hash mật khẩu, kiểm tra User)
└── Security/
    └── JwtTokenGenerator.cs   # Chịu trách nhiệm tạo chuỗi JWT an toàn