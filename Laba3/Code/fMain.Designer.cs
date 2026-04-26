namespace OpenKey
{
    partial class fMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pSide           = new System.Windows.Forms.Panel();
            this.pSideHeader     = new System.Windows.Forms.Panel();
            this.lAppTitle       = new System.Windows.Forms.Label();
            this.lAppSubtitle    = new System.Windows.Forms.Label();
            this.pParamsGroup    = new System.Windows.Forms.Panel();
            this.lGroupParams    = new System.Windows.Forms.Label();
            this.lPTitle         = new System.Windows.Forms.Label();
            this.tbP             = new System.Windows.Forms.TextBox();
            this.lGTitle         = new System.Windows.Forms.Label();
            this.tbQ             = new System.Windows.Forms.TextBox();
            this.lXTitle         = new System.Windows.Forms.Label();
            this.tbKC            = new System.Windows.Forms.TextBox();
            this.btnAcceptP      = new System.Windows.Forms.Button();
            this.pResultsGroup   = new System.Windows.Forms.Panel();
            this.lGroupResults   = new System.Windows.Forms.Label();
            this.lNLabel         = new System.Windows.Forms.Label();
            this.lNValue         = new System.Windows.Forms.Label();
            this.lYTitle         = new System.Windows.Forms.Label();
            this.lYValue         = new System.Windows.Forms.Label();
            this.lEilerTitle     = new System.Windows.Forms.Label();
            this.lEilerValue     = new System.Windows.Forms.Label();
            this.pFilesGroup     = new System.Windows.Forms.Panel();
            this.lGroupFiles     = new System.Windows.Forms.Label();
            this.btnOpenFile     = new System.Windows.Forms.Button();
            this.pActionsGroup   = new System.Windows.Forms.Panel();
            this.lGroupActions   = new System.Windows.Forms.Label();
            this.btnEncryption   = new System.Windows.Forms.Button();
            this.btnDecryption   = new System.Windows.Forms.Button();
            this.btnSaveFile     = new System.Windows.Forms.Button();
            this.btnExit         = new System.Windows.Forms.Button();
            // TableLayoutPanel делит правую часть на две равные строки
            this.tlpContent      = new System.Windows.Forms.TableLayoutPanel();
            this.lOpenedFile     = new System.Windows.Forms.Label();
            this.tbOpenedFile    = new System.Windows.Forms.TextBox();
            this.lResult         = new System.Windows.Forms.Label();
            this.tbResult        = new System.Windows.Forms.TextBox();
            this.openFileDialog  = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog  = new System.Windows.Forms.SaveFileDialog();

            this.pSide.SuspendLayout();
            this.pSideHeader.SuspendLayout();
            this.pParamsGroup.SuspendLayout();
            this.pResultsGroup.SuspendLayout();
            this.pFilesGroup.SuspendLayout();
            this.pActionsGroup.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.SuspendLayout();

            // ── Sidebar ───────────────────────────────────────────────────
            this.pSide.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.pSide.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pSide.Width     = 300;
            this.pSide.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pActionsGroup,
                this.pFilesGroup,
                this.pResultsGroup,
                this.pParamsGroup,
                this.pSideHeader
            });

            // ── Header ────────────────────────────────────────────────────
            this.pSideHeader.BackColor = System.Drawing.Color.FromArgb(49, 50, 68);
            this.pSideHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pSideHeader.Height    = 72;
            this.pSideHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lAppTitle, this.lAppSubtitle
            });

            this.lAppTitle.AutoSize  = true;
            this.lAppTitle.Location  = new System.Drawing.Point(16, 12);
            this.lAppTitle.Font      = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lAppTitle.ForeColor = System.Drawing.Color.FromArgb(203, 166, 247);
            this.lAppTitle.Text      = "RSA Шифрование";

            this.lAppSubtitle.AutoSize  = true;
            this.lAppSubtitle.Location  = new System.Drawing.Point(17, 40);
            this.lAppSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 132, 156);
            this.lAppSubtitle.Text      = "KC вводится  •  KO вычисляется";

            // ── Params Group ──────────────────────────────────────────────
            this.pParamsGroup.BackColor = System.Drawing.Color.Transparent;
            this.pParamsGroup.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pParamsGroup.Height    = 230;
            this.pParamsGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lGroupParams,
                this.lPTitle,  this.tbP,
                this.lGTitle,  this.tbQ,
                this.lXTitle,  this.tbKC,
                this.btnAcceptP
            });

            this.lGroupParams.AutoSize  = true;
            this.lGroupParams.Location  = new System.Drawing.Point(14, 12);
            this.lGroupParams.Font      = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lGroupParams.ForeColor = System.Drawing.Color.FromArgb(137, 180, 250);
            this.lGroupParams.Text      = "ПАРАМЕТРЫ КЛЮЧА";

            this.lPTitle.AutoSize  = true;
            this.lPTitle.Location  = new System.Drawing.Point(14, 34);
            this.lPTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lPTitle.ForeColor = System.Drawing.Color.FromArgb(166, 173, 200);
            this.lPTitle.Text      = "Простое число P";

            this.tbP.Location    = new System.Drawing.Point(14, 52);
            this.tbP.Size        = new System.Drawing.Size(272, 28);
            this.tbP.BackColor   = System.Drawing.Color.FromArgb(49, 50, 68);
            this.tbP.ForeColor   = System.Drawing.Color.FromArgb(205, 214, 244);
            this.tbP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbP.Font        = new System.Drawing.Font("Segoe UI", 10f);

            this.lGTitle.AutoSize  = true;
            this.lGTitle.Location  = new System.Drawing.Point(14, 86);
            this.lGTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lGTitle.ForeColor = System.Drawing.Color.FromArgb(166, 173, 200);
            this.lGTitle.Text      = "Простое число Q";

            this.tbQ.Location    = new System.Drawing.Point(14, 104);
            this.tbQ.Size        = new System.Drawing.Size(272, 28);
            this.tbQ.BackColor   = System.Drawing.Color.FromArgb(49, 50, 68);
            this.tbQ.ForeColor   = System.Drawing.Color.FromArgb(205, 214, 244);
            this.tbQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQ.Font        = new System.Drawing.Font("Segoe UI", 10f);

            this.lXTitle.AutoSize  = true;
            this.lXTitle.Location  = new System.Drawing.Point(14, 138);
            this.lXTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lXTitle.ForeColor = System.Drawing.Color.FromArgb(166, 173, 200);
            this.lXTitle.Text      = "Закрытый ключ KC (d)";

            this.tbKC.Location    = new System.Drawing.Point(14, 156);
            this.tbKC.Size        = new System.Drawing.Size(272, 28);
            this.tbKC.BackColor   = System.Drawing.Color.FromArgb(49, 50, 68);
            this.tbKC.ForeColor   = System.Drawing.Color.FromArgb(205, 214, 244);
            this.tbKC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbKC.Font        = new System.Drawing.Font("Segoe UI", 10f);

            this.btnAcceptP.Location                  = new System.Drawing.Point(14, 194);
            this.btnAcceptP.Size                      = new System.Drawing.Size(272, 30);
            this.btnAcceptP.Text                      = "Подтвердить параметры";
            this.btnAcceptP.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptP.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptP.FlatAppearance.BorderSize = 0;
            this.btnAcceptP.BackColor                 = System.Drawing.Color.FromArgb(137, 180, 250);
            this.btnAcceptP.ForeColor                 = System.Drawing.Color.FromArgb(30, 30, 46);
            this.btnAcceptP.Font                      = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnAcceptP.Click                    += new System.EventHandler(this.btnAcceptP_Click);

            // ── Results Group ─────────────────────────────────────────────
            this.pResultsGroup.BackColor = System.Drawing.Color.FromArgb(36, 37, 54);
            this.pResultsGroup.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pResultsGroup.Height    = 104;
            this.pResultsGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lGroupResults,
                this.lNLabel,     this.lNValue,
                this.lYTitle,     this.lYValue,
                this.lEilerTitle, this.lEilerValue
            });

            this.lGroupResults.AutoSize  = true;
            this.lGroupResults.Location  = new System.Drawing.Point(14, 8);
            this.lGroupResults.Font      = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lGroupResults.ForeColor = System.Drawing.Color.FromArgb(137, 180, 250);
            this.lGroupResults.Text      = "ВЫЧИСЛЕННЫЕ ЗНАЧЕНИЯ";

            this.lNLabel.AutoSize  = true;
            this.lNLabel.Location  = new System.Drawing.Point(14, 30);
            this.lNLabel.Font      = new System.Drawing.Font("Segoe UI", 9f);
            this.lNLabel.ForeColor = System.Drawing.Color.FromArgb(166, 173, 200);
            this.lNLabel.Text      = "n = P·Q:";

            this.lNValue.AutoSize  = true;
            this.lNValue.Location  = new System.Drawing.Point(68, 30);
            this.lNValue.Font      = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lNValue.ForeColor = System.Drawing.Color.FromArgb(250, 179, 135);
            this.lNValue.Text      = "—";

            this.lYTitle.AutoSize  = true;
            this.lYTitle.Location  = new System.Drawing.Point(14, 52);
            this.lYTitle.Font      = new System.Drawing.Font("Segoe UI", 9f);
            this.lYTitle.ForeColor = System.Drawing.Color.FromArgb(166, 173, 200);
            this.lYTitle.Text      = "KO (e):";

            this.lYValue.AutoSize  = true;
            this.lYValue.Location  = new System.Drawing.Point(62, 52);
            this.lYValue.Font      = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lYValue.ForeColor = System.Drawing.Color.FromArgb(166, 227, 161);
            this.lYValue.Text      = "—";

            this.lEilerTitle.AutoSize  = true;
            this.lEilerTitle.Location  = new System.Drawing.Point(14, 74);
            this.lEilerTitle.Font      = new System.Drawing.Font("Segoe UI", 9f);
            this.lEilerTitle.ForeColor = System.Drawing.Color.FromArgb(166, 173, 200);
            this.lEilerTitle.Text      = "φ(n):";

            this.lEilerValue.AutoSize  = true;
            this.lEilerValue.Location  = new System.Drawing.Point(50, 74);
            this.lEilerValue.Font      = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lEilerValue.ForeColor = System.Drawing.Color.FromArgb(166, 227, 161);
            this.lEilerValue.Text      = "—";

            // ── Files Group ───────────────────────────────────────────────
            this.pFilesGroup.BackColor = System.Drawing.Color.Transparent;
            this.pFilesGroup.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pFilesGroup.Height    = 66;
            this.pFilesGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lGroupFiles, this.btnOpenFile
            });

            this.lGroupFiles.AutoSize  = true;
            this.lGroupFiles.Location  = new System.Drawing.Point(14, 8);
            this.lGroupFiles.Font      = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lGroupFiles.ForeColor = System.Drawing.Color.FromArgb(137, 180, 250);
            this.lGroupFiles.Text      = "ФАЙЛЫ";

            this.btnOpenFile.Location                   = new System.Drawing.Point(14, 28);
            this.btnOpenFile.Size                       = new System.Drawing.Size(272, 30);
            this.btnOpenFile.Text                       = "Выбрать файл";
            this.btnOpenFile.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(250, 179, 135);
            this.btnOpenFile.FlatAppearance.BorderSize  = 1;
            this.btnOpenFile.BackColor                  = System.Drawing.Color.Transparent;
            this.btnOpenFile.ForeColor                  = System.Drawing.Color.FromArgb(250, 179, 135);
            this.btnOpenFile.Font                       = new System.Drawing.Font("Segoe UI", 9f);
            this.btnOpenFile.Click                     += new System.EventHandler(this.btnOpenFile_Click);

            // ── Actions Group ─────────────────────────────────────────────
            this.pActionsGroup.BackColor = System.Drawing.Color.Transparent;
            this.pActionsGroup.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pActionsGroup.Height    = 118;
            this.pActionsGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lGroupActions,
                this.btnEncryption, this.btnDecryption,
                this.btnSaveFile,   this.btnExit
            });

            this.lGroupActions.AutoSize  = true;
            this.lGroupActions.Location  = new System.Drawing.Point(14, 8);
            this.lGroupActions.Font      = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lGroupActions.ForeColor = System.Drawing.Color.FromArgb(137, 180, 250);
            this.lGroupActions.Text      = "ДЕЙСТВИЯ";

            this.btnEncryption.Location                  = new System.Drawing.Point(14, 28);
            this.btnEncryption.Size                      = new System.Drawing.Size(128, 34);
            this.btnEncryption.Text                      = "Зашифровать";
            this.btnEncryption.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnEncryption.Enabled                   = false;
            this.btnEncryption.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncryption.FlatAppearance.BorderSize = 0;
            this.btnEncryption.BackColor                 = System.Drawing.Color.FromArgb(166, 227, 161);
            this.btnEncryption.ForeColor                 = System.Drawing.Color.FromArgb(30, 30, 46);
            this.btnEncryption.Font                      = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnEncryption.Click                    += new System.EventHandler(this.btnEncryption_Click);

            this.btnDecryption.Location                  = new System.Drawing.Point(150, 28);
            this.btnDecryption.Size                      = new System.Drawing.Size(136, 34);
            this.btnDecryption.Text                      = "Дешифровать";
            this.btnDecryption.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnDecryption.Enabled                   = false;
            this.btnDecryption.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecryption.FlatAppearance.BorderSize = 0;
            this.btnDecryption.BackColor                 = System.Drawing.Color.FromArgb(245, 194, 231);
            this.btnDecryption.ForeColor                 = System.Drawing.Color.FromArgb(30, 30, 46);
            this.btnDecryption.Font                      = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnDecryption.Click                    += new System.EventHandler(this.btnDecryption_Click);

            this.btnSaveFile.Location                   = new System.Drawing.Point(14, 70);
            this.btnSaveFile.Size                       = new System.Drawing.Size(196, 30);
            this.btnSaveFile.Text                       = "Сохранить результат";
            this.btnSaveFile.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFile.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(88, 91, 112);
            this.btnSaveFile.FlatAppearance.BorderSize  = 1;
            this.btnSaveFile.BackColor                  = System.Drawing.Color.Transparent;
            this.btnSaveFile.ForeColor                  = System.Drawing.Color.FromArgb(166, 173, 200);
            this.btnSaveFile.Font                       = new System.Drawing.Font("Segoe UI", 9f);
            this.btnSaveFile.Click                     += new System.EventHandler(this.btnSaveFile_Click);

            this.btnExit.Location                   = new System.Drawing.Point(218, 70);
            this.btnExit.Size                       = new System.Drawing.Size(68, 30);
            this.btnExit.Text                       = "Выход";
            this.btnExit.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(243, 139, 168);
            this.btnExit.FlatAppearance.BorderSize  = 1;
            this.btnExit.BackColor                  = System.Drawing.Color.Transparent;
            this.btnExit.ForeColor                  = System.Drawing.Color.FromArgb(243, 139, 168);
            this.btnExit.Font                       = new System.Drawing.Font("Segoe UI", 9f);
            this.btnExit.Click                     += new System.EventHandler(this.btnExit_Click);

            // ── TableLayoutPanel (правая часть) ───────────────────────────
            // Две строки по 50%: верхняя — файл, нижняя — результат.
            // Dock=Fill — автоматически заполняет всё пространство справа.
            // Нет фиксированных Size у дочерних элементов — всё через Dock внутри ячеек.
            this.tlpContent.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.BackColor     = System.Drawing.Color.FromArgb(24, 24, 37);
            this.tlpContent.Padding       = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.tlpContent.ColumnCount   = 1;
            this.tlpContent.RowCount      = 4;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 100f));
            // Строка 0: заголовок файла (фикс. высота)
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 26f));
            // Строка 1: поле файла (50% оставшегося места)
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 50f));
            // Строка 2: заголовок результата (фикс. высота)
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 26f));
            // Строка 3: поле результата (50% оставшегося места)
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 50f));

            this.tlpContent.Controls.Add(this.lOpenedFile,  0, 0);
            this.tlpContent.Controls.Add(this.tbOpenedFile, 0, 1);
            this.tlpContent.Controls.Add(this.lResult,      0, 2);
            this.tlpContent.Controls.Add(this.tbResult,     0, 3);

            // Заголовок «Содержимое файла»
            this.lOpenedFile.AutoSize  = false;
            this.lOpenedFile.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lOpenedFile.Font      = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lOpenedFile.ForeColor = System.Drawing.Color.FromArgb(137, 180, 250);
            this.lOpenedFile.Text      = "СОДЕРЖИМОЕ ФАЙЛА";
            this.lOpenedFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Поле содержимого файла — Dock=Fill, никакого Size
            this.tbOpenedFile.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.tbOpenedFile.Multiline   = true;
            this.tbOpenedFile.ReadOnly    = true;
            this.tbOpenedFile.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOpenedFile.BackColor   = System.Drawing.Color.FromArgb(36, 37, 54);
            this.tbOpenedFile.ForeColor   = System.Drawing.Color.FromArgb(205, 214, 244);
            this.tbOpenedFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbOpenedFile.Font        = new System.Drawing.Font("Consolas", 9.5f);

            // Заголовок «Результат»
            this.lResult.AutoSize  = false;
            this.lResult.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lResult.Font      = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lResult.ForeColor = System.Drawing.Color.FromArgb(166, 227, 161);
            this.lResult.Text      = "РЕЗУЛЬТАТ";
            this.lResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Поле результата — Dock=Fill, никакого Size
            this.tbResult.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.Multiline   = true;
            this.tbResult.ReadOnly    = true;
            this.tbResult.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.BackColor   = System.Drawing.Color.FromArgb(36, 37, 54);
            this.tbResult.ForeColor   = System.Drawing.Color.FromArgb(205, 214, 244);
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbResult.Font        = new System.Drawing.Font("Consolas", 9.5f);

            // ── fMain ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(24, 24, 37);
            this.ClientSize          = new System.Drawing.Size(820, 620);
            this.MinimumSize         = new System.Drawing.Size(640, 500);
            this.Text                = "RSA — Шифрование с открытым ключом";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            // pSide — Left, tlpContent — Fill. Порядок важен: сначала Fill, потом Left.
            this.Controls.Add(this.tlpContent);
            this.Controls.Add(this.pSide);

            this.pActionsGroup.ResumeLayout(false);
            this.pActionsGroup.PerformLayout();
            this.pFilesGroup.ResumeLayout(false);
            this.pFilesGroup.PerformLayout();
            this.pResultsGroup.ResumeLayout(false);
            this.pResultsGroup.PerformLayout();
            this.pParamsGroup.ResumeLayout(false);
            this.pParamsGroup.PerformLayout();
            this.pSideHeader.ResumeLayout(false);
            this.pSideHeader.PerformLayout();
            this.pSide.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel            pSide;
        private System.Windows.Forms.Panel            pSideHeader;
        private System.Windows.Forms.Label            lAppTitle;
        private System.Windows.Forms.Label            lAppSubtitle;
        private System.Windows.Forms.Panel            pParamsGroup;
        private System.Windows.Forms.Label            lGroupParams;
        private System.Windows.Forms.Label            lPTitle;
        private System.Windows.Forms.TextBox          tbP;
        private System.Windows.Forms.Label            lGTitle;
        private System.Windows.Forms.TextBox          tbQ;
        private System.Windows.Forms.Label            lXTitle;
        private System.Windows.Forms.TextBox          tbKC;
        private System.Windows.Forms.Button           btnAcceptP;
        private System.Windows.Forms.Panel            pResultsGroup;
        private System.Windows.Forms.Label            lGroupResults;
        private System.Windows.Forms.Label            lNLabel;
        private System.Windows.Forms.Label            lNValue;
        private System.Windows.Forms.Label            lYTitle;
        private System.Windows.Forms.Label            lYValue;
        private System.Windows.Forms.Label            lEilerTitle;
        private System.Windows.Forms.Label            lEilerValue;
        private System.Windows.Forms.Panel            pFilesGroup;
        private System.Windows.Forms.Label            lGroupFiles;
        private System.Windows.Forms.Button           btnOpenFile;
        private System.Windows.Forms.Panel            pActionsGroup;
        private System.Windows.Forms.Label            lGroupActions;
        private System.Windows.Forms.Button           btnEncryption;
        private System.Windows.Forms.Button           btnDecryption;
        private System.Windows.Forms.Button           btnSaveFile;
        private System.Windows.Forms.Button           btnExit;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.Label            lOpenedFile;
        private System.Windows.Forms.TextBox          tbOpenedFile;
        private System.Windows.Forms.Label            lResult;
        private System.Windows.Forms.TextBox          tbResult;
        private System.Windows.Forms.OpenFileDialog   openFileDialog;
        private System.Windows.Forms.SaveFileDialog   saveFileDialog;
    }
}
