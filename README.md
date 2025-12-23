<p align="center">
  <img width="250" height="250" src="./Client/Resources/chitchat_logo.png">
</p>

# chitchat
Một ứng dụng nhắn tin local đơn giản sử dụng C# và Windows Forms.

# Tại sao lại nhắn tin qua LAN?

Thời đại nay có nhiều ứng dụng nhắn tin qua một server thống nhất qua internet nhưng có những lúc mình chỉ cần hoạt động trong một mạng cục bộ và có tốc độ truyền tải nhanh nhẹn và vững chắc. Việc sử dụng LAN có thể cho phép được cài đặt trực tiếp trên một máy chủ của một tập thể, công ty và bảo mật được thông tin tin nhắn của người dùng khỏi một tập thể khác.

# Thành viên nhóm

| MSSV | Họ và tên | Vai trò |
|---|---|---|
| 24520763 | Nguyễn Tuấn Khang | Xây dựng backend và thiết kế giao diện |
| 24520644 | Trần Hữu Quốc Hướng | Xây dựng frontend |
| 24520680 | Nguyễn Lê Đức Huy | Xây dựng frontend |

# Tính năng
## 1. Tự cài đặt máy chủ
- Mỗi người dùng có thể tự mở một máy chủ để mọi người kết nối trong mạng cục bộ.

## 2. Sử dụng tên cá nhân và ảnh đại diện đồng bộ
- Đa số hệ thống decentralized sẽ bắt người dùng tạo một hồ sơ sử dụng tên cá nhân với ảnh đại diện mới cho một máy chủ khác. Nhưng ứng dụng chúng mình ra một giải pháp khác. Mỗi cá nhân sẽ được nhận diện bởi IP thay vì tên cá nhân nên sẽ cho phép trùng lặp, ảnh đại diện sẽ được gán một mã guid khi được đăng lần đầu lên một máy chủ và được sử dụng lại sau này hoặc được đăng lại với mã cũ cho một máy chủ mới. Khả năng trùng lặp guid rất thấp nên giải pháp này khá ổn định.

- ***Giới hạn***: bởi vì người dùng được nhận diện bằng IP nên ứng dụng sẽ không thể nhận diện được tin nhắn của bạn sau khi IP được thay đổi. Vì vậy ứng dụng không cho phép chỉnh sửa tin nhắn cũ hoàn toàn. Chúng mình đề xuất các bạn để máy chủ ở một mạng cố định mà không thay đổi IP quá thường xuyên.

## 3. Chia sẻ tệp tin
- Chia sẻ tệp tin trực tiếp qua mạng cục bộ với tốc độ cực nhanh và không mất nét.
## 4. Thả reaction
- Các bạn có thể thả reaction cho các tin nhắn (mới có 3 loại reaction được cài đặt)
- ***Giới hạn***: Bởi vì người dùng được nhận diện bởi IP, bạn sẽ không thể gỡ reaction nếu IP của bạn thay đổi đột ngột.

# Hướng dẫn sử dụng
Clone repo về máy rồi sử dụng Visual Studio hoặc VSCode hoặc Jetbrains Rider để mở tệp `.sln` rồi build solution. 

Vào thư mục `bin\Debug` hoặc `bin\Release` của `Client` để mở ứng dụng trực tiếp từ tệp `.exe`, và của `Server` để mở một máy chủ cho mọi người kết nối. 

# Một vài easter egg
Splashscreen của ứng dụng sẽ tạo một hoạt ảnh ngẫu nhiên khi khởi động, thể hiện tính decentralization của cách các người dùng kết nối với nhau :)

<p align="center">
   <img width="750" height="398" alt="image" src="https://github.com/user-attachments/assets/4fb5ab69-7dc4-494a-a686-827b8784002f" />
   <img width="714" height="355" alt="image" src="https://github.com/user-attachments/assets/b52e21cc-2b13-4a2b-bbda-5de94b49b974" />
</p>

