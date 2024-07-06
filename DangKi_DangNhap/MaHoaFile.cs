using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKi_DangNhap
{
    public partial class MaHoaFile : Form
    {
        public MaHoaFile()
        {
            InitializeComponent();
            errorLabel.Text = "";
        }

        public string key;
        static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
        private string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.GenerateIV(); // Generate a random IV
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    byte[] iv = aesAlg.IV;
                    byte[] encryptedBytes = msEncrypt.ToArray();
                    byte[] result = new byte[iv.Length + encryptedBytes.Length];
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);
                    return Convert.ToBase64String(result);
                }
            }
        }

        private string Decrypt(string cipherText, string key)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];
            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipher))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        private void FileToHex(string inputFilePath, string outputHexPath)
        {
            try
            {
                // Đọc toàn bộ dữ liệu từ tệp vào một mảng byte
                byte[] fileBytes = File.ReadAllBytes(inputFilePath);

                // Chuyển đổi mỗi byte thành một chuỗi hex
                StringBuilder hexString = new StringBuilder();
                foreach (byte b in fileBytes)
                {
                    hexString.Append(b.ToString("X2"));
                }

                // Ghi chuỗi hex vào tệp đích
                File.WriteAllText(outputHexPath, hexString.ToString());


            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
               // MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HexToFile(string inputHexPath, string outputFilePath)
        {
            try
            {
                // Đọc chuỗi hex từ tệp
                string hexString = File.ReadAllText(inputHexPath);

                // Chuyển đổi chuỗi hex thành mảng byte
                byte[] fileBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                }

                // Ghi mảng byte vào tệp đích
                File.WriteAllBytes(outputFilePath, fileBytes);


            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
               // MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string GetMiddle16Chars(string input)
        {
            if (input.Length >= 16)
            {
                // Lấy 16 ký tự từ trái và 16 ký tự từ phải
                string leftSubstring = input.Substring(0, 8);
                string rightSubstring = input.Substring(input.Length - 8);
                return leftSubstring + rightSubstring;
            }
            else
            {
                return input; // Trả về toàn bộ chuỗi nếu chuỗi đầu vào ngắn hơn 32 ký tự
            }
        }

        private void encrypt_btn_Click(object sender, EventArgs e)
        {
            string KEY = Key.Text;
            string TB = tb_link.Text;
            string SAVE = save.Text;
            if( KEY.Length == 0 || TB.Length == 0 || SAVE.Length == 0)
            {
                errorLabel.Text = " Vui lòng nhập đầy đủ thông tin !";
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hashedValue = GetHash(sha256Hash, Key.Text);
                string key = GetMiddle16Chars(hashedValue);
                Console.WriteLine("Giá trị đã băm: " + hashedValue);


                try
                {
                    FileToHex(tb_link.Text, "..\\net8.0-windows\\pdf.hex");
                    string filename = Path.GetFileNameWithoutExtension(tb_link.Text);

                    string Extention = Path.GetExtension(tb_link.Text);
                    string fileExtension = Extention.TrimStart('.');
                    string plain_text = File.ReadAllText("..\\net8.0-windows\\pdf.hex");
                    string cipher_path = $"{save.Text}\\{filename}_{fileExtension}.hex";
                    string cipher_text = Encrypt(plain_text, key);

                    File.WriteAllText(cipher_path, cipher_text);

                    MessageBox.Show("Mã hóa thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void decrypt_btn_Click(object sender, EventArgs e)
        {
            string KEY = Key.Text;
            string TB = tb_link.Text;
            string SAVE = save.Text;
            if (KEY.Length == 0 || TB.Length == 0 || SAVE.Length == 0)
            {
                errorLabel.Text = " Vui lòng nhập đầy đủ thông tin !";
            }
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hashedValue = GetHash(sha256Hash, Key.Text);
                string key = GetMiddle16Chars(hashedValue);
                Console.WriteLine("Giá trị đã băm: " + hashedValue);

                try
                {

                    string cipher_path = tb_link.Text;

                    string filename = Path.GetFileNameWithoutExtension(cipher_path);

                    string extension = "";
                    int underscoreIndex = filename.LastIndexOf('_'); // Find the last underscore index
                    if (underscoreIndex != -1 && underscoreIndex < filename.Length - 1) // Check if underscore exists and it's not the last character
                    {
                        extension = filename.Substring(underscoreIndex + 1); // Get the substring after the underscore
                        int dotIndex = extension.LastIndexOf('.'); // Find the last dot index
                        if (dotIndex != -1) // Check if dot exists
                        {
                            extension = extension.Substring(0, dotIndex); // Exclude the .hex part
                        }
                    }

                    string cipher_text = File.ReadAllText(cipher_path);
                    string plain_convert = Decrypt(cipher_text, key);
                    string plain_conver_path = "..\\net8.0-windows\\plain_convert.hex";

                    File.WriteAllText(plain_conver_path, plain_convert);

                    HexToFile(plain_conver_path, $"{save.Text}\\{filename}.{extension}");
                    MessageBox.Show("Giải mã thành công file đã được lưu vào download!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                   // MessageBox.Show($"error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Title = "Select All file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tb_link.Text = openFileDialog.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    save.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
