using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptography
{
    public partial class Form1 : Form
    {
        private StatusStrip statusStrip;
        private FlowLayoutPanel layoutPanel; 
        private Panel mainPanel; 

        public Form1()
        {
            InitializeComponent();
            CustomizeControls();
            InitializeStatusStrip();
            CreateLayout();

            // Maximize the form to fit the screen
            this.WindowState = FormWindowState.Maximized;
            this.Resize += Form1_Resize; // Add resize event handler
        }

        private void CreateLayout()
        {
            // Create a panel for input and output
            mainPanel = new Panel // Fixing the scope issue
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(40, 44, 52), // Dark background
            };
            this.Controls.Add(mainPanel);

            // Create the FlowLayoutPanel to handle control alignment
            layoutPanel = new FlowLayoutPanel // Fixing the scope issue
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(20),
                WrapContents = false,
                Anchor = AnchorStyles.None // Center the panel
            };
            mainPanel.Controls.Add(layoutPanel);

            // Add a title label
            Label titleLabel = new Label
            {
                Text = "Cryptography Tool",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 15) // Increased margin
            };
            layoutPanel.Controls.Add(titleLabel);

            // Add labels and controls
            Label inputLabel = new Label
            {
                Text = "Input Message:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5) // Increased margin
            };
            Label keyLabel = new Label
            {
                Text = "Key:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5) // Increased margin
            };
            Label methodLabel = new Label
            {
                Text = "Cryptography Method:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5) // Increased margin
            };
            Label outputLabel = new Label
            {
                Text = "Output:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5) // Increased margin
            };

            // Create a FlowLayoutPanel for the first button group (Encrypt/Decrypt)
            FlowLayoutPanel buttonGroup1 = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0, 15, 0, 15) // Adjusted margin
            };
            buttonGroup1.Controls.Add(button1); // Encrypt
            buttonGroup1.Controls.Add(button2); // Decrypt

            // Add controls to the layout panel
            layoutPanel.Controls.Add(methodLabel);
            layoutPanel.Controls.Add(methodCmb);
            layoutPanel.Controls.Add(inputLabel);
            layoutPanel.Controls.Add(inputTxt);
            layoutPanel.Controls.Add(keyLabel);
            layoutPanel.Controls.Add(keyTxt);
            layoutPanel.Controls.Add(buttonGroup1); // Add grouped buttons
            layoutPanel.Controls.Add(outputLabel);

            // Adjust output text box size
            outputTxt.Width = 400; // Set width to match other components
            outputTxt.Height = 60; // Optional: Increase height for better usability
            layoutPanel.Controls.Add(outputTxt); // Use outputTxt instead of outputLbl

            // Add a separator label for spacing
            Label separator = new Label
            {
                Height = 1,
                Width = 400,
                BackColor = Color.FromArgb(70, 70, 70), // Light gray line
                Margin = new Padding(0, 20, 0, 20) // Adjusted margin for spacing
            };
            layoutPanel.Controls.Add(separator);

            // Add heading for file management
            Label fileManagementLabel = new Label
            {
                Text = "File Management",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 20, 0, 10) // Increased margin
            };
            layoutPanel.Controls.Add(fileManagementLabel);

            // Create a FlowLayoutPanel for the second button group (Encrypt Files/Decrypt Files)
            FlowLayoutPanel buttonGroup2 = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0, 20, 0, 0) // Increased margin for separation
            };

            // Update button texts
            EncryptFileBtn.Text = "Encrypt Files";
            DecryptFileByn.Text = "Decrypt Files";

            buttonGroup2.Controls.Add(EncryptFileBtn);
            buttonGroup2.Controls.Add(DecryptFileByn);

            // Add file operation buttons to the layout panel
            layoutPanel.Controls.Add(buttonGroup2);

            // Center the layout panel vertically
            CenterLayoutPanel();
        }
        

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (mainPanel != null && layoutPanel != null)
            {
                layoutPanel.Location = new Point((mainPanel.Width - layoutPanel.Width) / 2, 20);
            }
        }

        private void CenterLayoutPanel()
        {
            if (mainPanel != null && layoutPanel != null)
            {
                int panelWidth = Math.Max(440, layoutPanel.PreferredSize.Width); // Minimum width of 440 or content width
                layoutPanel.Size = new Size(panelWidth, layoutPanel.PreferredSize.Height);
                layoutPanel.Location = new Point((mainPanel.Width - layoutPanel.Width) / 2, 20);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            methodCmb.Items.AddRange(new string[]
            {
            "Caesar",
            "Vigenère",
            "Transposition",
            "Vernam",
            "Color Code",
            "Custom",
            "Product Cipher"
            });
            methodCmb.SelectedIndex = 0; // Default to first method
        }

        private void CustomizeControls()
        {
            // Customize buttons with more polish and animation
            CustomizeButton(button1);
            CustomizeButton(button2);
            CustomizeButton(EncryptFileBtn);
            CustomizeButton(DecryptFileByn);

            // Customize text boxes with modern design
            CustomizeTextBox(inputTxt);
            CustomizeTextBox(keyTxt);

            // Set consistent font
            Font commonFont = new Font("Segoe UI", 10);
            foreach (Control control in this.Controls)
            {
                control.Font = commonFont;
            }

            // Customize combo box
            methodCmb.Width = 400;
            methodCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            methodCmb.BackColor = Color.FromArgb(240, 240, 240);
            methodCmb.ForeColor = Color.Black;
            methodCmb.Margin = new Padding(0, 10, 0, 10);

            // Add tooltips to all controls for better usability
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(button1, "Encrypt the input text");
            toolTip.SetToolTip(button2, "Decrypt the input text");
            toolTip.SetToolTip(EncryptFileBtn, "Encrypt a file");
            toolTip.SetToolTip(DecryptFileByn, "Decrypt a file");
            toolTip.SetToolTip(inputTxt, "Enter text to encrypt or decrypt");
            toolTip.SetToolTip(keyTxt, "Enter the key for encryption/decryption");
            toolTip.SetToolTip(methodCmb, "Select the encryption method");
        }

        private void InitializeStatusStrip()
        {
            statusStrip = new StatusStrip
            {
                BackColor = Color.FromArgb(40, 44, 52) // Dark status bar background
            };
            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel("Ready")
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Italic)
            };
            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);
            statusStrip.Dock = DockStyle.Bottom;
        }

        private void methodCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add code here to handle changes in the ComboBox selection if needed
        }

        private void CustomizeButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(30, 144, 255); // DodgerBlue
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Width = 150; // Slightly wider buttons
            button.Height = 40;
            button.Margin = new Padding(5, 0, 5, 0); // Add horizontal spacing between buttons
            button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(70, 130, 180); // Hover color
            button.MouseLeave += (s, e) => button.BackColor = Color.FromArgb(30, 144, 255); // Original color
        }

        private void CustomizeTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ForeColor = Color.Black;
            textBox.BackColor = Color.FromArgb(240, 240, 240); // Light gray background
            textBox.Width = 400; // Increased width for better usability
            textBox.Height = 30;
            textBox.Font = new Font("Segoe UI", 10);
            textBox.Margin = new Padding(0, 10, 0, 10);
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }


        public string CaesarEncrypt(string input, int shift)
        {
            try
            {
                StringBuilder result = new StringBuilder();

                foreach (char c in input)
                {
                    if (c >= 32 && c <= 126)
                    {
                        char encryptedChar = (char)(((c - 32 + shift) % 95) + 32);
                        result.Append(encryptedChar);
                    }
                    else
                    {
                        result.Append(c);
                    }
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caesar Encrypt Error: {ex.Message}");
                return string.Empty;
            }
        }

        public string CaesarDecrypt(string input, int shift)
        {
            try
            {
                return CaesarEncrypt(input, 95 - (shift % 95));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caesar Decrypt Error: {ex.Message}");
                return string.Empty;
            }
        }

        // Vigenère Encryption Method
        public string VigenereEncrypt(string input, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                StringBuilder result = new StringBuilder();
                int keyIndex = 0;
                int printableRange = 95;

                foreach (char c in input)
                {
                    if (c >= 32 && c <= 126)
                    {
                        int shift = key[keyIndex % key.Length] % printableRange;
                        char encryptedChar = (char)(((c - 32 + shift) % printableRange) + 32);
                        result.Append(encryptedChar);
                        keyIndex++;
                    }
                    else
                    {
                        result.Append(c);
                    }
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vigenère Encrypt Error: {ex.Message}");
                return string.Empty;
            }
        }

        public string VigenereDecrypt(string input, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                StringBuilder result = new StringBuilder();
                int keyIndex = 0;
                int printableRange = 95;

                foreach (char c in input)
                {
                    if (c >= 32 && c <= 126)
                    {
                        int shift = key[keyIndex % key.Length] % printableRange;
                        char decryptedChar = (char)(((c - 32 - shift + printableRange) % printableRange) + 32);
                        result.Append(decryptedChar);
                        keyIndex++;
                    }
                    else
                    {
                        result.Append(c);
                    }
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vigenère Decrypt Error: {ex.Message}");
                return string.Empty;
            }
        }


        // Prepare the columns for transposition method
        private int[] GetKeyOrder(string key)
        {
            char[] keyChars = key.ToUpper().ToCharArray();
            int[] order = new int[key.Length];
            var sorted = keyChars
                .Select((ch, index) => new { Char = ch, Index = index })
                .OrderBy(x => x.Char)
                .ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                order[i] = sorted[i].Index;
            }

            return order;
        }

        // Transposition Encryption Method
        public string TranspositionEncrypt(string plaintext, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                int[] keyOrder = GetKeyOrder(key);
                int numCols = key.Length;
                int numRows = (int)Math.Ceiling((double)plaintext.Length / numCols);
                char[,] grid = new char[numRows, numCols];

                int index = 0;
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        grid[r, c] = index < plaintext.Length ? plaintext[index++] : 'X';
                    }
                }

                StringBuilder result = new StringBuilder();
                for (int k = 0; k < numCols; k++)
                {
                    int col = keyOrder[k];
                    for (int r = 0; r < numRows; r++)
                    {
                        result.Append(grid[r, col]);
                    }
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transposition Encrypt Error: {ex.Message}");
                return string.Empty;
            }
        }


        // Transposition Decryption Method
        public string TranspositionDecrypt(string ciphertext, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                int[] keyOrder = GetKeyOrder(key);
                int numCols = key.Length;
                int numRows = (int)Math.Ceiling((double)ciphertext.Length / numCols);
                char[,] grid = new char[numRows, numCols];

                int totalChars = ciphertext.Length;
                int fullCells = numRows * numCols;
                int paddingCount = fullCells - totalChars;

                int[] colHeights = Enumerable.Repeat(numRows, numCols).ToArray();
                for (int i = numCols - paddingCount; i < numCols; i++)
                    colHeights[keyOrder[i]]--;

                int index = 0;
                for (int k = 0; k < numCols; k++)
                {
                    int col = keyOrder[k];
                    for (int r = 0; r < colHeights[col]; r++)
                    {
                        grid[r, col] = ciphertext[index++];
                    }
                }

                StringBuilder result = new StringBuilder();
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        if (grid[r, c] != '\0')
                            result.Append(grid[r, c]);
                    }
                }

                return result.ToString().TrimEnd('X');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transposition Decrypt Error: {ex.Message}");
                return string.Empty;
            }
        }

        // Vernam Encryption Method
        // Vernam Encryption Method (returns Base64)
        private string ExtendKey(string key, int length)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                StringBuilder extended = new StringBuilder();
                while (extended.Length < length)
                {
                    extended.Append(key);
                }
                return extended.ToString(0, length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Key Extension Error: {ex.Message}");
                return string.Empty;
            }
        }

        public string VernamEncrypt(string plaintext, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                key = ExtendKey(key, plaintext.Length);

                byte[] encryptedBytes = new byte[plaintext.Length];
                for (int i = 0; i < plaintext.Length; i++)
                {
                    encryptedBytes[i] = (byte)(plaintext[i] ^ key[i]);
                }

                return Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vernam Encrypt Error: {ex.Message}");
                return string.Empty;
            }
        }

        public string VernamDecrypt(string base64Ciphertext, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be empty.");
                byte[] encryptedBytes = Convert.FromBase64String(base64Ciphertext);
                key = ExtendKey(key, encryptedBytes.Length);

                byte[] decryptedBytes = new byte[encryptedBytes.Length];
                for (int i = 0; i < encryptedBytes.Length; i++)
                {
                    decryptedBytes[i] = (byte)(encryptedBytes[i] ^ key[i]);
                }

                return Encoding.UTF8.GetString(decryptedBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vernam Decrypt Error: {ex.Message}");
                return string.Empty;
            }
        }


        // Color Code Encryption and Decryption
        private Dictionary<char, string> CreateColorMap()
        {
            return new Dictionary<char, string>
            {
                {'A', "Red"},
                {'B', "Blue"},
                {'C', "Green"},
                {'D', "Yellow"},
                {'E', "Purple"},
                {'F', "Orange"},
                {'G', "Pink"},
                {'H', "Brown"},
                {'I', "Gray"},
                {'J', "Cyan"},
                {'K', "Magenta"},
                {'L', "Lime"},
                {'M', "Teal"},
                {'N', "Navy"},
                {'O', "Violet"},
                {'P', "Coral"},
                {'Q', "Maroon"},
                {'R', "Olive"},
                {'S', "Gold"},
                {'T', "Silver"},
                {'U', "Indigo"},
                {'V', "Peach"},
                {'W', "Lavender"},
                {'X', "Mint"},
                {'Y', "Tan"},
                {'Z', "Burgundy"}
            };
        }

        public List<string> ColorCodeEncrypt(string input)
        {
            var colorMap = CreateColorMap();
            List<string> result = new List<string>();

            foreach (char c in input.ToUpper())
            {
                if (colorMap.ContainsKey(c))
                {
                    result.Add(colorMap[c]);
                }
                else
                {
                    result.Add($"HEX:{((int)c):X2}"); // Add hex format, e.g., HEX:21 for '!'
                }
            }

            return result;
        }

        public string ColorCodeDecrypt(List<string> colors)
        {
            var colorMap = CreateColorMap();
            var reverseMap = colorMap.ToDictionary(x => x.Value, x => x.Key);
            StringBuilder result = new StringBuilder();

            foreach (string color in colors)
            {
                if (reverseMap.ContainsKey(color))
                {
                    result.Append(reverseMap[color]);
                }
                else if (color.StartsWith("HEX:"))
                {
                    string hex = color.Substring(4); // Remove "HEX:"
                    int ascii = Convert.ToInt32(hex, 16);
                    result.Append((char)ascii);
                }
                else
                {
                    result.Append(color); // fallback
                }
            }

            return result.ToString();
        }

        public static string CustomEncrypt(string input)
        {
            // Example: Reverse the string and shift each char by +2
            char[] chars = input.Reverse().ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] + 2);
            }
            return new string(chars);
        }

        public static string CustomDecrypt(string input)
        {
            // Reverse of CustomEncrypt: shift -2 then reverse string
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] - 2);
            }
            Array.Reverse(chars);
            return new string(chars);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string input = inputTxt.Text;
            string key = keyTxt.Text; // optional, depending on method
            string result = "";

            // Check if a method is selected
            if (methodCmb.SelectedItem == null || methodCmb.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an encryption method from the list.", "Missing Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string method = methodCmb.SelectedItem.ToString();

            // Check if input text is empty or whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter text to encrypt.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Switch based on the selected method
            switch (method)
            {
                case "Caesar":
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Please enter a key before encrypting.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (int.TryParse(key, out int shift))
                    {
                        result = CaesarEncrypt(input, shift);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid shift number for Caesar cipher.");
                        return; // Exit method if invalid input for Caesar cipher
                    }
                    break;

                case "Vigenère":
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Please enter a key before encrypting.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    result = VigenereEncrypt(input, key);
                    break;

                case "Transposition":
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Please enter a key before encrypting.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    result = TranspositionEncrypt(input, key);
                    break;

                case "Vernam":
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Please enter a key before encrypting.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    result = VernamEncrypt(input, key);
                    break;

                case "Color Code":
                    result = string.Join(", ", ColorCodeEncrypt(input)); // Assuming ColorCodeEncrypt returns a list/array
                    break;

                case "Custom":
                    result = CustomEncrypt(input);
                    break;

                case "Product Cipher":
                    // Apply Caesar cipher first, then Vigenère cipher
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Please enter a key before encrypting.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (int.TryParse(key, out int shift))
                    {
                        // First apply Caesar encryption
                        string caesarResult = CaesarEncrypt(input, shift);

                        // Then apply Vigenère encryption on Caesar result
                        string vigenereResult = VigenereEncrypt(caesarResult, key);

                        result = vigenereResult; // The final product cipher result
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid key for Product Cipher.");
                        return; // Exit method if invalid input for Product Cipher
                    }
                    break;

                default:
                    MessageBox.Show("Invalid encryption method selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Output the result
            outputTxt.Text = result;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string input = inputTxt.Text;
            string key = keyTxt.Text;
            string result = "";
            int shift = 0;

            /// Ensure cmbMethod is initialized and has a valid selection
            if (methodCmb == null || methodCmb.SelectedItem == null || string.IsNullOrWhiteSpace(methodCmb.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select an encryption method from the list.", "Missing Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string method = methodCmb.SelectedItem.ToString(); 

            // Check if input text is provided
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter text to decrypt.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (method)
                {
                    case "Caesar":
                        // Key is required for Caesar decryption
                        if (int.TryParse(key, out shift))
                        {
                            result = CaesarDecrypt(input, shift);
                        }
                        else if (string.IsNullOrWhiteSpace(key))
                        {
                            MessageBox.Show("Please enter a key (shift number) for Caesar cipher decryption.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid shift number for Caesar cipher decryption.", "Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case "Vigenère":
                        // Key is required for Vigenère decryption
                        if (string.IsNullOrWhiteSpace(key))
                        {
                            MessageBox.Show("Please enter a key for Vigenère cipher decryption.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            result = VigenereDecrypt(input, key);
                        }
                        break;

                    case "Transposition":
                        // Key is required for Transposition decryption
                        if (string.IsNullOrWhiteSpace(key))
                        {
                            MessageBox.Show("Please enter a key for Transposition cipher decryption.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            result = TranspositionDecrypt(input, key);
                        }
                        break;

                    case "Vernam":
                        // Key is required for Vernam decryption
                        if (string.IsNullOrWhiteSpace(key))
                        {
                            MessageBox.Show("Please enter a key for Vernam cipher decryption.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            result = VernamDecrypt(input, key);
                        }
                        break;

                    case "Color Code": // Decryption for Color Code
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            MessageBox.Show("Please enter the color code text to decrypt.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Decrypt Color Code text
                            var colorsList = input.Split(new[] { ", " }, StringSplitOptions.None).ToList();
                            result = ColorCodeDecrypt(colorsList);
                        }
                        break;

                    case "Custom":
                        result = CustomDecrypt(input);
                        break;

                    case "Product Cipher":
                        // Apply Vigenère decryption first, then Caesar decryption
                        if (string.IsNullOrWhiteSpace(key))
                        {
                            MessageBox.Show("Please enter a key for Product Cipher decryption.", "Missing Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            // First apply Vigenère decryption
                            string vigenereDecrypted = VigenereDecrypt(input, key);

                            // Then apply Caesar decryption on the Vigenère decrypted text
                            if (int.TryParse(key, out shift))
                            {
                                result = CaesarDecrypt(vigenereDecrypted, shift);
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid key for Caesar cipher decryption.");
                                return;
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Invalid decryption method selected.", "Invalid Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during decryption: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Output the result of decryption
            outputTxt.Text = result;
        }



        public byte[] LoadFileBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public void SaveFileBytes(string filePath, byte[] data)
        {
            File.WriteAllBytes(filePath, data);
        }

        public byte[] EncryptStringToBytes(string plaintext, Func<string, string> encryptionFunc)
        {
            string encrypted = encryptionFunc(plaintext);
            return Encoding.UTF8.GetBytes(encrypted);
        }

        public string DecryptBytesToString(byte[] encryptedBytes, Func<string, string> decryptionFunc)
        {
            string encryptedText = Encoding.UTF8.GetString(encryptedBytes);
            return decryptionFunc(encryptedText);
        }

        public byte[] CaesarByteEncrypt(byte[] data, int shift)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)((data[i] + shift) % 256); // Byte-safe Caesar
            }
            return result;
        }

        public byte[] CaesarByteDecrypt(byte[] data, int shift)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)((256 + data[i] - shift) % 256); // reverse shift
            }
            return result;
        }

        public byte[] VigenereByteEncrypt(byte[] data, byte[] key)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)((data[i] + key[i % key.Length]) % 256);
            }
            return result;
        }

        public byte[] VigenereByteDecrypt(byte[] data, byte[] key)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)((256 + data[i] - key[i % key.Length]) % 256);
            }
            return result;
        }

        public byte[] VernamByteEncrypt(byte[] data, byte[] key)
        {
            if (data.Length != key.Length)
                throw new ArgumentException("Key must be the same length as the file content.");

            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ key[i]); // XOR
            }
            return result;
        }

        public byte[] TranspositionByteEncrypt(byte[] data, string key)
        {
            int[] keyOrder = GetKeyOrder(key);
            int numCols = key.Length;
            int numRows = (int)Math.Ceiling((double)data.Length / numCols);
            byte[,] grid = new byte[numRows, numCols];

            // Fill grid row-wise
            int index = 0;
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    grid[r, c] = index < data.Length ? data[index++] : (byte)'X'; // pad
                }
            }

            // Read column-wise by key order
            List<byte> result = new List<byte>();
            foreach (int col in keyOrder)
            {
                for (int r = 0; r < numRows; r++)
                {
                    result.Add(grid[r, col]);
                }
            }

            return result.ToArray();
        }

        public byte[] TranspositionByteDecrypt(byte[] data, string key)
        {
            int[] keyOrder = GetKeyOrder(key);
            int numCols = key.Length;
            int numRows = (int)Math.Ceiling((double)data.Length / numCols);
            byte[,] grid = new byte[numRows, numCols];

            // Fill columns by key order
            int index = 0;
            foreach (int col in keyOrder)
            {
                for (int r = 0; r < numRows; r++)
                {
                    if (index < data.Length)
                        grid[r, col] = data[index++];
                }
            }

            // Read row-wise
            List<byte> result = new List<byte>();
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    result.Add(grid[r, c]);
                }
            }

            return result.ToArray(); // No trimming — preserves binary structure
        }

        public byte[] GenerateRandomKey(int length)
        {
            byte[] key = new byte[length];
            new Random().NextBytes(key);
            return key;
        }

        private byte ReverseBits(byte b)
        {
            byte result = 0;
            for (int i = 0; i < 8; i++)
            {
                result <<= 1;
                result |= (byte)(b & 1);
                b >>= 1;
            }
            return result;
        }

        private byte[] CustomEncrypt(byte[] inputBytes)
        {
            byte[] result = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                byte original = inputBytes[i];
                byte reversed = ReverseBits(original);
                result[i] = reversed;
            }

            return result;
        }


        private byte[] CustomDecrypt(byte[] encryptedBytes)
        {
            byte[] result = new byte[encryptedBytes.Length];

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                byte encrypted = encryptedBytes[i];
                byte reversed = ReverseBits(encrypted); // Same bit-reversing logic
                result[i] = reversed;
            }

            return result;
        }

        private void EncryptFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string method = methodCmb.SelectedItem.ToString();
                string key = keyTxt.Text;

                byte[] fileBytes = LoadFileBytes(ofd.FileName);
                byte[] encryptedBytes = null;

                switch (method)
                {
                    case "Caesar":
                        if (int.TryParse(key, out int shift))
                        {
                            encryptedBytes = CaesarByteEncrypt(fileBytes, shift);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Caesar shift.");
                            return;
                        }
                        break;

                    case "Vigenère":
                        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                        encryptedBytes = VigenereByteEncrypt(fileBytes, keyBytes);
                        break;

                    case "Transposition":
                        encryptedBytes = TranspositionByteEncrypt(fileBytes, key);
                        break;

                    case "Vernam":
                        byte[] keyBytesV = GenerateRandomKey(fileBytes.Length);
                        encryptedBytes = VernamByteEncrypt(fileBytes, keyBytesV);
                        File.WriteAllBytes("vernam_key.key", keyBytesV);  // Save the Vernam key separately
                        break;

                    case "Color Code":
                        var inputText = Encoding.UTF8.GetString(fileBytes);
                        var colors = ColorCodeEncrypt(inputText);
                        var encryptedText = string.Join(",", colors); // Removed space after comma for consistency
                        encryptedBytes = Encoding.UTF8.GetBytes(encryptedText);
                        break;



                    case "Custom":
                        encryptedBytes = CustomEncrypt(fileBytes);

                        break;

                    case "Product Cipher":
                        if (int.TryParse(key, out int productShift))
                        {
                            // 1. Caesar encrypt
                            byte[] caesarEncrypted = CaesarByteEncrypt(fileBytes, productShift);

                            // 2. Vigenère encrypt
                            byte[] vigenereKey = Encoding.UTF8.GetBytes(key);
                            encryptedBytes = VigenereByteEncrypt(caesarEncrypted, vigenereKey);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Caesar shift for Product Cipher.");
                            return;
                        }
                        break;

                    default:
                        MessageBox.Show("Unknown encryption method.");
                        return;
                }

                // Save encrypted file once after encryption
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFileBytes(saveFileDialog.FileName, encryptedBytes);
                    MessageBox.Show($"File encrypted successfully using {method}.");
                }
            }
        }


        private void DecryptFileByn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string method = methodCmb.SelectedItem.ToString();
                string key = keyTxt.Text;
                byte[] fileBytes = LoadFileBytes(ofd.FileName);
                byte[] decryptedBytes = null;

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                switch (method)
                {
                    case "Caesar":
                        if (int.TryParse(key, out int shift))
                        {
                            decryptedBytes = CaesarByteDecrypt(fileBytes, shift);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Caesar shift.");
                        }
                        break;

                    case "Vigenère":
                        byte[] keyBytesV = Encoding.UTF8.GetBytes(key);
                        decryptedBytes = VigenereByteDecrypt(fileBytes, keyBytesV);
                        break;

                    case "Transposition":
                        decryptedBytes = TranspositionByteDecrypt(fileBytes, key);
                        break;

                    case "Vernam":
                        byte[] keyBytes = File.ReadAllBytes("vernam_key.key");
                        decryptedBytes = VernamByteEncrypt(fileBytes, keyBytes); // Same method for decrypt
                        break;

                    case "Color Code":
                        string encryptedColorText = Encoding.UTF8.GetString(fileBytes); // Read the encrypted file as string
                        List<string> colorList = encryptedColorText
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(c => c.Trim()) // Trim to clean any leading/trailing spaces
                            .ToList();

                        string decryptedText = ColorCodeDecrypt(colorList); // Convert back to text
                        decryptedBytes = Encoding.UTF8.GetBytes(decryptedText); // Convert to bytes for saving
                        break;

                    case "Custom":
                        decryptedBytes = CustomDecrypt(fileBytes);

                        break;

                    case "Product Cipher":
                        if (int.TryParse(key, out int productShift))
                        {
                            // 1. Vigenère decrypt
                            byte[] vigenereKey = Encoding.UTF8.GetBytes(key);
                            byte[] vigenereDecrypted = VigenereByteDecrypt(fileBytes, vigenereKey);

                            // 2. Caesar decrypt
                            decryptedBytes = CaesarByteDecrypt(vigenereDecrypted, productShift);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Caesar shift for Product Cipher.");
                            return;
                        }
                        break;

                    default:
                        MessageBox.Show("Unknown Decryption method.");
                        return;

                }

                if (decryptedBytes != null)
                {
                    saveFileDialog.FileName = "decrypted_" + Path.GetFileName(ofd.FileName);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveFileBytes(saveFileDialog.FileName, decryptedBytes);
                        MessageBox.Show("File decrypted successfully.");
                    }
                    

                }
            }
        }
    }
}