# 🚀 OS Simulator - Round Robin Scheduling

Đây là dự án Web Application mô phỏng thuật toán điều phối CPU **Round Robin (RR)**, được thiết kế với giao diện Dark Theme hiện đại và các hiệu ứng trực quan sinh động. Dự án phục vụ cho việc học tập, nghiên cứu và báo cáo môn Hệ Điều Hành.

## ✨ Tính năng nổi bật (Features)

* **🧮 Mô phỏng trực quan (Gantt Chart):** Thể hiện chi tiết quá trình cấp phát CPU cho từng tiến trình theo thời gian thực với hiệu ứng trượt mượt mà.
* **📊 Phân tích hiệu suất (Data Visualization):** Tích hợp `Chart.js` để tự động vẽ biểu đồ cột so sánh Thời gian chờ (Waiting Time) và Thời gian hoàn thành (Turnaround Time).
* **📸 Xuất báo cáo nhanh (Export to Image):** Hỗ trợ "chụp ảnh" toàn bộ biểu đồ và kết quả tính toán thành file PNG cực nét chỉ với 1 click (Sử dụng `html2canvas`).
* **🛡️ Bẫy lỗi thông minh:** Validate dữ liệu đầu vào (Arrival Time, Burst Time, Quantum) nghiêm ngặt với giao diện cảnh báo `SweetAlert2`.
* **📖 Gia sư ảo (Solution Guide):** Tự động sinh ra bảng giải thích chi tiết từng bước áp dụng công thức toán học.
* **📝 Hệ thống Trắc nghiệm (Mini Quiz):** Ngân hàng câu hỏi xáo trộn ngẫu nhiên giúp sinh viên ôn tập lý thuyết hệ điều hành, lệnh Linux, và lập trình C (fork, wait).

## 🛠️ Công nghệ sử dụng (Tech Stack)

* **Back-end:** C#, ASP.NET Core MVC
* **Front-end:** HTML5, CSS3, JavaScript (Vanilla)
* **Libraries:** Chart.js, SweetAlert2, html2canvas
* **Công cụ Demo:** Ngrok (Hỗ trợ public localhost để thuyết trình trực tiếp)

## 🚀 Hướng dẫn chạy dự án (How to run)

1. Clone repository này về máy:
   ```bash
   git clone [https://github.com/yzziHoV/MoPhongQuantum.git](https://github.com/yzziHoV/MoPhongQuantum.git)

2. Mở file MoPhongQuantum.sln bằng Visual Studio.

3. Bấm tổ hợp phím Ctrl + Shift + B để Build project.

4. Bấm F5 hoặc nút Play xanh lá để chạy ứng dụng trên trình duyệt (localhost).

<img width="1907" height="961" alt="image" src="https://github.com/user-attachments/assets/16201bdb-e8eb-4911-b6ab-51c8c7344145" />
