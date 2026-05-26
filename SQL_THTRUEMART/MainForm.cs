using System;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load để tải ảnh Online
            this.Load += MainForm_Load;

            // Đăng ký sự kiện Resize để xử lý co dãn giao diện (Responsive)
            this.Resize += MainForm_Resize;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // --- 1. TẮT TỰ ĐỘNG FOCUS & MỞ FULL MÀN HÌNH ---
            this.ActiveControl = lblLogo;
            this.WindowState = FormWindowState.Maximized; // Tự động phóng to toàn màn hình máy tính

            // --- 2. SỬA LỖI TEXT BỊ CẮT VÀ CĂN GIỮA ICON ---

            // Tăng chiều cao của các label mô tả để không bị mất chữ khi rớt dòng (wrap text)
            if (lblFeatDesc1 != null) lblFeatDesc1.Height = 80;
            if (lblFeatDesc2 != null) lblFeatDesc2.Height = 80;
            if (lblFeatDesc3 != null) lblFeatDesc3.Height = 80;
            if (lblBrandDesc != null) { lblBrandDesc.Height = 100; lblBrandDesc.Width = 350; }

            // Căn giữa các Icon Emoji vào chính giữa các hộp vuông ở phần Trust Section
            if (lblIcon1 != null && pnlIcon1 != null) { lblIcon1.Left = (pnlIcon1.Width - lblIcon1.Width) / 2; lblIcon1.Top = (pnlIcon1.Height - lblIcon1.Height) / 2; }
            if (lblIcon2 != null && pnlIcon2 != null) { lblIcon2.Left = (pnlIcon2.Width - lblIcon2.Width) / 2; lblIcon2.Top = (pnlIcon2.Height - lblIcon2.Height) / 2; }
            if (lblIcon3 != null && pnlIcon3 != null) { lblIcon3.Left = (pnlIcon3.Width - lblIcon3.Width) / 2; lblIcon3.Top = (pnlIcon3.Height - lblIcon3.Height) / 2; }


            // --- 3. LOAD ẢNH TỪ INTERNET ASYNC ---

            LoadImageAsync(pbHero, "https://lh3.googleusercontent.com/aida-public/AB6AXuBX2SqhOUKGujqi1FDFy2VHjLuZNL4j0mGzVM6SCL7hq1O8MdPSwNzQwtxKFhhOCpz70q8odHREa4rfCyHK-DBRRx1tKMnMkS81WO3seMKrYd4KKukEIGEF_ZRlnIM7CdRXhNDrxBQk8MkwyVVb_LuCXl9Uz2nGUjGWlSXKx6xJxcChsQ2n5xlMOQ9tHkS3T7Fy4hLw0Sc0bCFBEg3nnAjr67ScqKVa3DOXG2ivFdxykqduACLJ8NUb5qXPHt0j30UPDma_68p-lMkz");

            LoadImageAsync(pbCat1, "https://lh3.googleusercontent.com/aida-public/AB6AXuCV9QKkwXnI-QCk9EON3_wJr0TIggwVIL-xXKssE4jADzLWZkYEYOeJ0105aOQxpnKqUvzVED-e_c_ibwVEHf_u55pJJQASInznBB1lYWW8MiOjQ27XNRrph7INvO-p52hG2vV36QUMOswZJSL9f3x8ov3v6Kfibfv6nHxPhCKP2w_n8_brYFKWtwYJA-e4ufMexCiUr6MjUYkmK-4iqJ-yC7Y8ShTg115fB-wzoUFvStqtEIasDJZcUJBybY40slAiialFyvwW6hFM");
            LoadImageAsync(pbCat2, "https://lh3.googleusercontent.com/aida-public/AB6AXuDwE9Iw5FupQ_pqUGiWmOTE72oSqG5ycFasXIcDMNWAzUSkoymVoSx6vDRUoWwEdYVcUmVdgsfs1zCHN2Mhx1Nqo4PqhLFkVGGS1G_iC4iBs9c7YQ1fQszCypVhfNSXDZsL44JOjJqZdjyV5c9XNHflNC-Za_yR8yvYGBNmPd1BMsxrgcqfqALo8B4PFXLF-xj0X0rEV1oT8RSfav84efyB7myv5lZu4TDhaUBMr_o5t9I0m9h0O5rrx5Doj6xxZ_Pictd-6_-emar8");
            LoadImageAsync(pbCat3, "https://lh3.googleusercontent.com/aida-public/AB6AXuAGZsH9KOYFEA7Ost-A_gI5_H-5aPlcKhKzLf_Wensp1eoR4LeFPhKqFinf7-1nkBm5rdinkH844wY4enkIHN4NolyibMI6KK-kKZVxZU6Wm7LPLPCciYNl9mLEWREQHexcsdHayl5zilD_yOUWCBQVjWSxvM7Q9HMNsFVoyfSKzfVuN4yqXKKaGItvYo74VhzKmpkyT9TfBSI8fBEhcgxI4Sta1WwwBeUUqnJYiMXd1DEX6RsnUMcFvPHapLW9T9QHjLfrdbc3hSno");
            LoadImageAsync(pbCat4, "https://lh3.googleusercontent.com/aida-public/AB6AXuDt_6SjJYiqCeXv6NPZNt4wAW7F-GTP-JMlY6xVD3JVmtGRBSJc7g-PcdppMkEXQnj2tAHBRMIDuHcqhpAlGCUYDi8aZNnazuYQCHCeCkXrxc9S8kMtMFp4POfN5x7FyBlWvRRM48tExxQjwWt5MkMBAGy0n7ZPykPZTHWrRQt4fef5V7dD_9gEF3RumLkK0aNMg10zQe0huPCmkw1eFZAoVQoYzS3cLHCLbjXUZsIVCOn5k9G8sJTSkIyGfORJ3bzDOMQU4nuN0OeV");

            LoadImageAsync(pbPromoBg, "https://lh3.googleusercontent.com/aida-public/AB6AXuAUdhLvQDqTx1A4a1CNOWa38ZpVdPeY3GGKVJwzq4UdVOiHZHDFBKnCywdbhu2jjGm7Mcl2M7qXRb6opNKgDphpYT8gQ3kt7HI7LLJo84m3OgZ4KS6G4xnSW-CpWP3JSi4obYqvdtjX4JFyxgu3lCWGkfxCTm_WFPcKTJ3MXbU-fG5T7t5j7op_2g52GZ3IcfjQBhYcwJs7-zW0thkBR7kWo5UXR3n_I6vL_T-r4V4mnbhALKuX6GAKX-vCVBAWckC5Z9v8w2_BsWQ1");

            LoadImageAsync(pbCard1, "https://lh3.googleusercontent.com/aida-public/AB6AXuDmRZryfTde7agcBw2ddbfxhU8dPuUcwTsbKJ_2VA6PcbQ9vBQNX9gZWqhqZLmcnGkxjBnLDvJIjEa3fsdgZNylkLoBlhqJsofWFnQInMM0PJbmyjUQkCR6PZ-CoQT0vBROX6wGYK59dKa6JYwPcquhMyo9tmJ5ExByNIVyRBHzbPanBXSJSunt4tYpp_wXt73_9Ehu7rTSIa2mKFEyc6rxOOHn-XiuljAYjstu3tdBs77-IDZc9EVzYAUwXZyctGgFzJMhiksdiv_8");
            LoadImageAsync(pbCard2, "https://lh3.googleusercontent.com/aida-public/AB6AXuA4w8iDxDwxugLWPw7Xaj3XFRPRIBab83VKLTnvzBrVVzPV-okdiJlHuauWUdwwC5OnBt7q9gLiErZMOBz0cPCRgrTgPEj0oanYrWnMRLP7VhMzfvpn83taus65U2W0VHkHj_fpp3UKZK7NcI4HiW33oOJD561nnr_Dv2Q8nFLv3sho_aKAMcIjFr2dg4PMaxQj685Q3RM7OMrR6GS1RzQfpS70H8tgEsBzagN8MD_NJ2BjTG3_ROR60od6XQvGsPklI_WEDQPx1xyZ");
            LoadImageAsync(pbCard3, "https://lh3.googleusercontent.com/aida-public/AB6AXuDc5BWm8GYH3rNC4tTtN7EwoQJPIUydlePxG_EdK8bBf27ruPhKSL40-kN7lBb686VP10ytzXMN1f17ouhTDK-2ntJWA0LhEOCjPG98kwgHXS1E6gO3B9BW0gVQQvpSeXSNrakrhusRKvF7vpuE-bavgPgrPrZMizGLWrI2zXWxxfTQFfDgi4L0p3aXEX0OWHrsI-f3iquYodLIKlDYXEzu0T7j6iSVw1-FcRHVB7M1rmXutV9Axt-NC5narDfc2BnP9P0XoMWqw24q");
            LoadImageAsync(pbCard4, "https://lh3.googleusercontent.com/aida-public/AB6AXuApfqkUbCnJ7XMs_f1__1P_0mqWowwKjDLi9apjgajsfACdWiHoj1lhTKjNZ35eGdEGlmnm3McnIQLda5YqwFjJJFSgxV6Es-AyULLuyPEWfg9EG_klXeBtavtNEvzzUaESRbGf-NwUt2QrmC5c-ryNAByZvl7U0DidOVYx1QWsaU-Ud4VDbJHg4_1ZiO9X-WaWfHNWoWkT6--oCTGFKToAIsU3dDIHm7BEyL2H_Tu3GOjbabq5ONrHj3xes5OTsBzR_Xd2UGFlj-WP");

            LoadImageAsync(pbJuice, "https://lh3.googleusercontent.com/aida-public/AB6AXuDdWW2sGrjh_WUuU8pUq9iQOrzD4kisOed1nmNBC22H6-_eaI2Btza6Lioup1h8WxXm6ECIUIImMNO4luZuJLOeK-6tAc-os1D_HsuXblQtOiKLXUsHOSb8kSGNfliklV00e3etL7QR8IfT5orHHD54dj3pJz8V8nUoKpGF9plPxEMqjWezImA_8x2Mq-QFX1SCybqYXN9SbunOsw8dReCMabtsVW1Wef6juTyn6qIz3SgtNyPsL8NLCOBNeCdVWw87H0FH8QyzF35n");

            // Kích hoạt tính toán Responsive lần đầu
            MainForm_Resize(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý Responsive: Tự động co dãn khi kích thước Form (cửa sổ máy tính) thay đổi
        /// </summary>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            int newWidth = this.ClientSize.Width;
            int padding = 80; // Căn lề trái phải

            // 1. Co dãn chiều rộng các Panel background chính
            Control[] fullWidthPanels = { pnlHeader, pnlHero, pnlCat, pnlPromo, pnlBest, pnlNew, pnlTrust, pnlFooter };
            foreach (var pnl in fullWidthPanels)
            {
                if (pnl != null) pnl.Width = newWidth;
            }

            // 2. Header - Neo các nút Đăng nhập / Đăng ký bên phải
            if (btnRegister != null) btnRegister.Left = newWidth - btnRegister.Width - padding;
            if (btnLogin != null) btnLogin.Left = btnRegister.Left - btnLogin.Width - 10;
            if (pnlSearch != null) pnlSearch.Left = btnLogin.Left - pnlSearch.Width - 30;

            // 3. Hero Section - Neo hình ảnh sang bên phải
            if (pbHero != null) pbHero.Left = newWidth - pbHero.Width - padding;

            // 4. Categories & Best Sellers - Tính toán khoảng cách (Gap) trải đều các item
            int availableWidth = newWidth - (padding * 2);
            int itemWidth = 260; // Chiều rộng cố định của từng Card
            int gap = (availableWidth - (4 * itemWidth)) / 3;
            if (gap < 20) gap = 20; // Đảm bảo luôn có khoảng cách tối thiểu

            if (pnlCatItem1 != null) pnlCatItem1.Left = padding;
            if (pnlCatItem2 != null) pnlCatItem2.Left = padding + itemWidth + gap;
            if (pnlCatItem3 != null) pnlCatItem3.Left = padding + (itemWidth + gap) * 2;
            if (pnlCatItem4 != null) pnlCatItem4.Left = padding + (itemWidth + gap) * 3;

            if (pnlCard1 != null) pnlCard1.Left = padding;
            if (pnlCard2 != null) pnlCard2.Left = padding + itemWidth + gap;
            if (pnlCard3 != null) pnlCard3.Left = padding + (itemWidth + gap) * 2;
            if (pnlCard4 != null) pnlCard4.Left = padding + (itemWidth + gap) * 3;
            if (lblViewAll != null) lblViewAll.Left = newWidth - lblViewAll.Width - padding;

            // 5. Promo Banner - Co dãn dải banner ở giữa
            if (pnlPromoCard != null)
            {
                pnlPromoCard.Width = availableWidth;
                if (pbPromoBg != null) pbPromoBg.Left = pnlPromoCard.Width - pbPromoBg.Width; // Đẩy hình nền sang phải banner
            }

            // 6. New Products (Bento Grid) - Khối bên trái giãn ra lấp đầy chỗ trống
            if (pnlBentoRT != null) pnlBentoRT.Left = newWidth - pnlBentoRT.Width - padding;
            if (pnlBentoRB != null) pnlBentoRB.Left = newWidth - pnlBentoRB.Width - padding;
            if (pnlBentoLeft != null)
            {
                pnlBentoLeft.Width = pnlBentoRT.Left - padding - 30; // 30 là gap ở giữa
                if (pbJuice != null) pbJuice.Width = pnlBentoLeft.Width;
                if (pnlJuiceOverlay != null) pnlJuiceOverlay.Width = pnlBentoLeft.Width;
            }

            // 7. Trust Section - Trải đều 3 item (Trái - Giữa - Phải chuẩn xác)
            if (pnlFeat1 != null) pnlFeat1.Left = padding;
            if (pnlFeat2 != null) pnlFeat2.Left = (newWidth - pnlFeat2.Width) / 2; // Căn chính giữa hoàn hảo
            if (pnlFeat3 != null) pnlFeat3.Left = newWidth - padding - pnlFeat3.Width; // Căn mép phải

            // 8. Footer - Neo 3 cột nội dung sang bên phải với khoảng cách đều nhau
            if (lblFooterCol3 != null) lblFooterCol3.Left = newWidth - padding - lblFooterCol3.Width;
            if (lblFooterCol2 != null) lblFooterCol2.Left = lblFooterCol3.Left - lblFooterCol2.Width - 150; // Giữ khoảng cách cố định 150px
            if (lblFooterCol1 != null) lblFooterCol1.Left = lblFooterCol2.Left - lblFooterCol1.Width - 150;
            if (lblCopy != null) lblCopy.Width = availableWidth; // Dàn text bản quyền full width để căn giữa
        }

        /// <summary>
        /// Hàm load ảnh từ internet bất đồng bộ để Form không bị lag lúc mở
        /// </summary>
        private void LoadImageAsync(PictureBox pb, string url)
        {
            try
            {
                pb.LoadAsync(url);
            }
            catch
            {
                // Bỏ qua lỗi nếu không load được hình ảnh
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DangNhap loginForm = new DangNhap();

            // 1. Đổi 'frm' thành 'loginForm' cho khớp với tên biến bạn vừa tạo ở trên
            loginForm.FormClosed += (s, args) => this.Close();

            // 2. Dùng Show() thay vì ShowDialog() để code tiếp tục chạy xuống lệnh Hide()
            loginForm.Show();

            // 3. Ẩn form hiện tại đi
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DangKy registerForm = new DangKy();

            // 1. Đổi 'frm' thành 'registerForm' cho khớp với tên biến bạn vừa tạo ở trên
            registerForm.FormClosed += (s, args) => this.Close();

            // 2. Dùng Show() thay vì ShowDialog() để code tiếp tục chạy xuống lệnh Hide()
            registerForm.Show();

            // 3. Ẩn form hiện tại đi
            this.Hide();
        }
    }
}