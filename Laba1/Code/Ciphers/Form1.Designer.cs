namespace Ciphers
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMethod = new System.Windows.Forms.GroupBox();
            this.rbVigenere = new System.Windows.Forms.RadioButton();
            this.rbRailFence = new System.Windows.Forms.RadioButton();
            this.gbParams = new System.Windows.Forms.GroupBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.numRails = new System.Windows.Forms.NumericUpDown();
            this.lblRails = new System.Windows.Forms.Label();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbMethod.SuspendLayout();
            this.gbParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRails)).BeginInit();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMethod
            // 
            this.gbMethod.Controls.Add(this.rbVigenere);
            this.gbMethod.Controls.Add(this.rbRailFence);
            this.gbMethod.Location = new System.Drawing.Point(17, 16);
            this.gbMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMethod.Size = new System.Drawing.Size(420, 151);
            this.gbMethod.TabIndex = 0;
            this.gbMethod.TabStop = false;
            this.gbMethod.Text = "Метод шифрования";
            // 
            // rbVigenere
            // 
            this.rbVigenere.AutoSize = true;
            this.rbVigenere.Location = new System.Drawing.Point(9, 71);
            this.rbVigenere.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbVigenere.Name = "rbVigenere";
            this.rbVigenere.Size = new System.Drawing.Size(360, 29);
            this.rbVigenere.TabIndex = 1;
            this.rbVigenere.Text = "Виженер (прямой ключ)";
            this.rbVigenere.UseVisualStyleBackColor = true;
            this.rbVigenere.CheckedChanged += new System.EventHandler(this.rbVigenere_CheckedChanged);
            // 
            // rbRailFence
            // 
            this.rbRailFence.AutoSize = true;
            this.rbRailFence.Checked = true;
            this.rbRailFence.Location = new System.Drawing.Point(9, 32);
            this.rbRailFence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbRailFence.Name = "rbRailFence";
            this.rbRailFence.Size = new System.Drawing.Size(327, 29);
            this.rbRailFence.TabIndex = 0;
            this.rbRailFence.TabStop = true;
            this.rbRailFence.Text = "Железнодорожная изгородь";
            this.rbRailFence.UseVisualStyleBackColor = true;
            this.rbRailFence.CheckedChanged += new System.EventHandler(this.rbRailFence_CheckedChanged);
            // 
            // gbParams
            // 
            this.gbParams.Controls.Add(this.txtKey);
            this.gbParams.Controls.Add(this.lblKey);
            this.gbParams.Controls.Add(this.numRails);
            this.gbParams.Controls.Add(this.lblRails);
            this.gbParams.Location = new System.Drawing.Point(476, 16);
            this.gbParams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbParams.Name = "gbParams";
            this.gbParams.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbParams.Size = new System.Drawing.Size(469, 151);
            this.gbParams.TabIndex = 1;
            this.gbParams.TabStop = false;
            this.gbParams.Text = "Параметры";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(256, 68);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(132, 31);
            this.txtKey.TabIndex = 3;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblKey.Location = new System.Drawing.Point(251, 32);
            this.lblKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(65, 25);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Ключ";
            // 
            // numRails
            // 
            this.numRails.Location = new System.Drawing.Point(15, 71);
            this.numRails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numRails.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRails.Name = "numRails";
            this.numRails.Size = new System.Drawing.Size(160, 31);
            this.numRails.TabIndex = 1;
            this.numRails.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRails
            // 
            this.lblRails.AutoSize = true;
            this.lblRails.Location = new System.Drawing.Point(9, 32);
            this.lblRails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRails.Name = "lblRails";
            this.lblRails.Size = new System.Drawing.Size(183, 25);
            this.lblRails.TabIndex = 0;
            this.lblRails.Text = "Высота изгороди";
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.btnClearInput);
            this.gbInput.Controls.Add(this.txtInput);
            this.gbInput.Controls.Add(this.btnOpenFile);
            this.gbInput.Location = new System.Drawing.Point(17, 175);
            this.gbInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbInput.Name = "gbInput";
            this.gbInput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbInput.Size = new System.Drawing.Size(420, 290);
            this.gbInput.TabIndex = 2;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Входные данные";
            // 
            // btnClearInput
            // 
            this.btnClearInput.Location = new System.Drawing.Point(9, 210);
            this.btnClearInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(212, 60);
            this.btnClearInput.TabIndex = 2;
            this.btnClearInput.Text = "Очистить поле";
            this.btnClearInput.UseVisualStyleBackColor = true;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(9, 92);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(363, 109);
            this.txtInput.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(9, 32);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(212, 52);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Открыть файл";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.btnCopy);
            this.gbOutput.Controls.Add(this.txtOutput);
            this.gbOutput.Controls.Add(this.btnSaveFile);
            this.gbOutput.Location = new System.Drawing.Point(476, 175);
            this.gbOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutput.Size = new System.Drawing.Size(469, 290);
            this.gbOutput.TabIndex = 3;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Результат";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(15, 210);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(183, 60);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Копировать";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(15, 92);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(437, 109);
            this.txtOutput.TabIndex = 2;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(15, 32);
            this.btnSaveFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(183, 52);
            this.btnSaveFile.TabIndex = 0;
            this.btnSaveFile.Text = "Сохранить";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnClearAll);
            this.gbActions.Controls.Add(this.btnDecrypt);
            this.gbActions.Controls.Add(this.btnEncrypt);
            this.gbActions.Location = new System.Drawing.Point(17, 472);
            this.gbActions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbActions.Name = "gbActions";
            this.gbActions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbActions.Size = new System.Drawing.Size(928, 79);
            this.gbActions.TabIndex = 4;
            this.gbActions.TabStop = false;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(652, 19);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(245, 49);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Очистить всё";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(355, 19);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(191, 49);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "Расшифровать";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(23, 19);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(199, 49);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Зашифровать";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 580);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.gbParams);
            this.Controls.Add(this.gbMethod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ciphers";
            this.gbMethod.ResumeLayout(false);
            this.gbMethod.PerformLayout();
            this.gbParams.ResumeLayout(false);
            this.gbParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRails)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMethod;
        private System.Windows.Forms.GroupBox gbParams;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.RadioButton rbVigenere;
        private System.Windows.Forms.RadioButton rbRailFence;
        private System.Windows.Forms.Label lblRails;
        private System.Windows.Forms.NumericUpDown numRails;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

