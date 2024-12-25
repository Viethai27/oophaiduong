namespace CALC227195._1
{
    public partial class Form1 : Form
    {
        private string currentInput = ""; // Biến lưu trữ đầu vào hiện tại
        private double result = 0; // Biến lưu trữ kết quả tính toán
        private string operation = ""; // Biến lưu trữ phép toán (+, -, *, /)

        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện bấm nút số (0-9)
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            currentInput += button.Text; // Thêm số vào currentInput
            richTextBoxScreen.Text = currentInput; // Hiển thị lên màn hình
        }

        // Sự kiện bấm các nút phép toán
        private void btnOperation_Click(object sender, EventArgs e)
        {
            if (currentInput != "") // Nếu có đầu vào số
            {
                double num = Convert.ToDouble(currentInput);

                // Thực hiện phép toán với kết quả cũ (nếu có)
                switch (operation)
                {
                    case "+":
                        result += num;
                        break;
                    case "-":
                        result -= num;
                        break;
                    case "x":
                        result *= num;
                        break;
                    case "/":
                        if (num != 0)
                        {
                            result /= num;
                        }
                        else
                        {
                            richTextBoxScreen.Text = "Cannot divide by zero!";
                            return;
                        }
                        break;
                    default:
                        result = num; // Nếu không có phép toán, gán giá trị đầu tiên
                        break;
                }

                // Ghi lại phép toán và số tiếp theo
                operation = (sender as Button).Text;
                currentInput = ""; // Xóa currentInput để người dùng nhập số tiếp theo
                richTextBoxScreen.Text = result.ToString(); // Hiển thị kết quả
            }
        }

        // Sự kiện bấm dấu "=" (tính toán)
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (currentInput != "") // Nếu có đầu vào số
            {
                double num = Convert.ToDouble(currentInput);

                // Thực hiện phép toán với kết quả hiện tại
                switch (operation)
                {
                    case "+":
                        result += num;
                        break;
                    case "-":
                        result -= num;
                        break;
                    case "x":
                        result *= num;
                        break;
                    case "/":
                        if (num != 0)
                        {
                            result /= num;
                        }
                        else
                        {
                            richTextBoxScreen.Text = "Cannot divide by zero!";
                            return;
                        }
                        break;
                }

                richTextBoxScreen.Text = result.ToString(); // Hiển thị kết quả
                currentInput = result.ToString(); // Lưu kết quả vào currentInput để có thể tiếp tục tính toán
                operation = ""; // Đặt lại phép toán
            }
        }

        // Sự kiện bấm dấu chấm thập phân
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                richTextBoxScreen.Text = currentInput;
            }
        }

        // Sự kiện bấm nút C (xóa)
        private void btnClear_Click(object sender, EventArgs e)
        {
            currentInput = "";
            result = 0;
            operation = "";
            richTextBoxScreen.Text = "";
        }

        // Gắn sự kiện cho tất cả các nút số
        private void InitializeButtons()
        {
            btnnum0.Click += btnNumber_Click;
            btnnum1.Click += btnNumber_Click;
            btnnum2.Click += btnNumber_Click;
            btnnum3.Click += btnNumber_Click;
            btnnum4.Click += btnNumber_Click;
            btnnum5.Click += btnNumber_Click;
            btnnum6.Click += btnNumber_Click;
            btnnum7.Click += btnNumber_Click;
            btnnum8.Click += btnNumber_Click;
            btnnum9.Click += btnNumber_Click;
        }

        // Gắn sự kiện cho tất cả các nút phép toán
        private void InitializeOperations()
        {
            btnAdd.Click += btnOperation_Click;
            btnSubtract.Click += btnOperation_Click;
            btnMultiply.Click += btnOperation_Click;
            btnDivide.Click += btnOperation_Click;
        }

        // Gọi hàm Initialize khi khởi tạo form
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeButtons();
            InitializeOperations();
            btnEquals.Click += btnEquals_Click;
            btnDecimal.Click += btnDecimal_Click;
        }
    }
}
