namespace Nero_Network
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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.bGive = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.lGuess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbWM = new System.Windows.Forms.PictureBox();
            this.cbWM = new System.Windows.Forms.ComboBox();
            this.lEpoch = new System.Windows.Forms.Label();
            this.lRight = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.ListBox();
            this.bTeachTest = new System.Windows.Forms.Button();
            this.chbCenter = new System.Windows.Forms.CheckBox();
            this.bIndexLeft = new System.Windows.Forms.Button();
            this.bIndexRight = new System.Windows.Forms.Button();
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.bHelp = new System.Windows.Forms.Button();
            this.bStartTesting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMain.Location = new System.Drawing.Point(252, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(100, 100);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            // 
            // bGive
            // 
            this.bGive.Location = new System.Drawing.Point(258, 123);
            this.bGive.Name = "bGive";
            this.bGive.Size = new System.Drawing.Size(88, 24);
            this.bGive.TabIndex = 1;
            this.bGive.Text = "Дать";
            this.bGive.UseVisualStyleBackColor = true;
            this.bGive.Click += new System.EventHandler(this.bGive_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(258, 153);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(88, 24);
            this.bClear.TabIndex = 1;
            this.bClear.Text = "Очистить";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // lGuess
            // 
            this.lGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGuess.Location = new System.Drawing.Point(92, 12);
            this.lGuess.Name = "lGuess";
            this.lGuess.Size = new System.Drawing.Size(157, 100);
            this.lGuess.TabIndex = 2;
            this.lGuess.Text = "Близнецы";
            this.lGuess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Альфа";
            // 
            // pbWM
            // 
            this.pbWM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM.Location = new System.Drawing.Point(371, 12);
            this.pbWM.Name = "pbWM";
            this.pbWM.Size = new System.Drawing.Size(100, 100);
            this.pbWM.TabIndex = 0;
            this.pbWM.TabStop = false;
            this.pbWM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            // 
            // cbWM
            // 
            this.cbWM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWM.FormattingEnabled = true;
            this.cbWM.Location = new System.Drawing.Point(371, 123);
            this.cbWM.Name = "cbWM";
            this.cbWM.Size = new System.Drawing.Size(100, 21);
            this.cbWM.TabIndex = 6;
            this.cbWM.SelectedIndexChanged += new System.EventHandler(this.cbWM_SelectedIndexChanged);
            // 
            // lEpoch
            // 
            this.lEpoch.AutoSize = true;
            this.lEpoch.Location = new System.Drawing.Point(19, 153);
            this.lEpoch.Name = "lEpoch";
            this.lEpoch.Size = new System.Drawing.Size(37, 13);
            this.lEpoch.TabIndex = 7;
            this.lEpoch.Text = "Эпохи";
            // 
            // lRight
            // 
            this.lRight.AutoSize = true;
            this.lRight.Location = new System.Drawing.Point(19, 173);
            this.lRight.Name = "lRight";
            this.lRight.Size = new System.Drawing.Size(44, 13);
            this.lRight.TabIndex = 7;
            this.lRight.Text = "Угадал";
            // 
            // logs
            // 
            this.logs.FormattingEnabled = true;
            this.logs.Location = new System.Drawing.Point(15, 194);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(456, 238);
            this.logs.TabIndex = 8;
            // 
            // bTeachTest
            // 
            this.bTeachTest.Location = new System.Drawing.Point(15, 61);
            this.bTeachTest.Name = "bTeachTest";
            this.bTeachTest.Size = new System.Drawing.Size(85, 51);
            this.bTeachTest.TabIndex = 5;
            this.bTeachTest.Text = "Обучение и тест";
            this.bTeachTest.UseVisualStyleBackColor = true;
            this.bTeachTest.Click += new System.EventHandler(this.bTeachTest_Click);
            // 
            // chbCenter
            // 
            this.chbCenter.AutoSize = true;
            this.chbCenter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbCenter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbCenter.Location = new System.Drawing.Point(183, 125);
            this.chbCenter.Name = "chbCenter";
            this.chbCenter.Size = new System.Drawing.Size(57, 17);
            this.chbCenter.TabIndex = 9;
            this.chbCenter.Text = "Центр";
            this.chbCenter.UseVisualStyleBackColor = true;
            // 
            // bIndexLeft
            // 
            this.bIndexLeft.Location = new System.Drawing.Point(371, 153);
            this.bIndexLeft.Name = "bIndexLeft";
            this.bIndexLeft.Size = new System.Drawing.Size(50, 23);
            this.bIndexLeft.TabIndex = 10;
            this.bIndexLeft.Text = "<";
            this.bIndexLeft.UseVisualStyleBackColor = true;
            this.bIndexLeft.Click += new System.EventHandler(this.bIndexLeft_Click);
            // 
            // bIndexRight
            // 
            this.bIndexRight.Location = new System.Drawing.Point(421, 153);
            this.bIndexRight.Name = "bIndexRight";
            this.bIndexRight.Size = new System.Drawing.Size(50, 23);
            this.bIndexRight.TabIndex = 10;
            this.bIndexRight.Text = ">";
            this.bIndexRight.UseVisualStyleBackColor = true;
            this.bIndexRight.Click += new System.EventHandler(this.bIndexRight_Click);
            // 
            // nudAlpha
            // 
            this.nudAlpha.DecimalPlaces = 2;
            this.nudAlpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudAlpha.Location = new System.Drawing.Point(15, 33);
            this.nudAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlpha.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(68, 20);
            this.nudAlpha.TabIndex = 3;
            this.nudAlpha.Value = new decimal(new int[] {
            30,
            0,
            0,
            131072});
            // 
            // bHelp
            // 
            this.bHelp.Location = new System.Drawing.Point(291, 444);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(180, 24);
            this.bHelp.TabIndex = 11;
            this.bHelp.Text = "Напоминалка по знакам";
            this.bHelp.UseVisualStyleBackColor = true;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // bStartTesting
            // 
            this.bStartTesting.Location = new System.Drawing.Point(15, 118);
            this.bStartTesting.Name = "bStartTesting";
            this.bStartTesting.Size = new System.Drawing.Size(85, 29);
            this.bStartTesting.TabIndex = 1;
            this.bStartTesting.Text = "Тест";
            this.bStartTesting.UseVisualStyleBackColor = true;
            this.bStartTesting.Click += new System.EventHandler(this.bStartTesting_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(488, 476);
            this.Controls.Add(this.bHelp);
            this.Controls.Add(this.bIndexRight);
            this.Controls.Add(this.bIndexLeft);
            this.Controls.Add(this.chbCenter);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.lRight);
            this.Controls.Add(this.lEpoch);
            this.Controls.Add(this.cbWM);
            this.Controls.Add(this.bTeachTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAlpha);
            this.Controls.Add(this.lGuess);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bStartTesting);
            this.Controls.Add(this.bGive);
            this.Controls.Add(this.pbWM);
            this.Controls.Add(this.pbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нейронка";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button bGive;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label lGuess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbWM;
        private System.Windows.Forms.ComboBox cbWM;
        private System.Windows.Forms.Label lEpoch;
        private System.Windows.Forms.Label lRight;
        private System.Windows.Forms.ListBox logs;
        private System.Windows.Forms.Button bTeachTest;
        private System.Windows.Forms.CheckBox chbCenter;
        private System.Windows.Forms.Button bIndexLeft;
        private System.Windows.Forms.Button bIndexRight;
        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.Button bHelp;
        private System.Windows.Forms.Button bStartTesting;
    }
}

