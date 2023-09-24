

#region using statements


#endregion

namespace RandomUSD
{

    #region class MainForm
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    partial class MainForm
    {

        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Methods

        #region Dispose(bool disposing)
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitializeComponent()
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            StatusLabel = new Label();
            Graph = new ProgressBar();
            CreatePropsButton = new DataJuggler.Win.Controls.Button();
            NumberPropsControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            FileNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            OutputFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            CreateCubesButton = new DataJuggler.Win.Controls.Button();
            ScenesPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            SaveSceneButton = new DataJuggler.Win.Controls.Button();
            SceneNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            SceneSelector = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            PropsPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            SavePropButton = new DataJuggler.Win.Controls.Button();
            PropNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            PropSelector = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            MaterialsPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            MaterialTypeComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            SaveMaterialsButton = new DataJuggler.Win.Controls.Button();
            MaterialSelector = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            TabHostControl = new DataJuggler.Win.Controls.TabHostControl();
            CreateBubblesButton = new DataJuggler.Win.Controls.Button();
            ScenesPanel.SuspendLayout();
            PropsPanel.SuspendLayout();
            MaterialsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(58, 689);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(1130, 29);
            StatusLabel.TabIndex = 10;
            StatusLabel.Text = "Status:";
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Graph
            // 
            Graph.Location = new Point(57, 722);
            Graph.Name = "Graph";
            Graph.Size = new Size(1131, 23);
            Graph.TabIndex = 9;
            Graph.Visible = false;
            // 
            // CreatePropsButton
            // 
            CreatePropsButton.BackColor = Color.Transparent;
            CreatePropsButton.ButtonText = "Create Props";
            CreatePropsButton.FlatStyle = FlatStyle.Flat;
            CreatePropsButton.ForeColor = Color.LemonChiffon;
            CreatePropsButton.Location = new Point(377, 615);
            CreatePropsButton.Margin = new Padding(4);
            CreatePropsButton.Name = "CreatePropsButton";
            CreatePropsButton.Size = new Size(178, 44);
            CreatePropsButton.TabIndex = 11;
            CreatePropsButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            CreatePropsButton.Click += CreatePropsButton_Click;
            // 
            // NumberPropsControl
            // 
            NumberPropsControl.BackColor = Color.Transparent;
            NumberPropsControl.BottomMargin = 0;
            NumberPropsControl.Editable = true;
            NumberPropsControl.Encrypted = false;
            NumberPropsControl.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            NumberPropsControl.Inititialized = true;
            NumberPropsControl.LabelBottomMargin = 0;
            NumberPropsControl.LabelColor = Color.LemonChiffon;
            NumberPropsControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            NumberPropsControl.LabelText = "# Props:";
            NumberPropsControl.LabelTopMargin = 0;
            NumberPropsControl.LabelWidth = 140;
            NumberPropsControl.Location = new Point(57, 621);
            NumberPropsControl.MultiLine = false;
            NumberPropsControl.Name = "NumberPropsControl";
            NumberPropsControl.OnTextChangedListener = null;
            NumberPropsControl.PasswordMode = false;
            NumberPropsControl.ScrollBars = ScrollBars.None;
            NumberPropsControl.Size = new Size(287, 32);
            NumberPropsControl.TabIndex = 15;
            NumberPropsControl.TextBoxBottomMargin = 0;
            NumberPropsControl.TextBoxDisabledColor = Color.LightGray;
            NumberPropsControl.TextBoxEditableColor = Color.White;
            NumberPropsControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NumberPropsControl.TextBoxTopMargin = 0;
            NumberPropsControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // FileNameControl
            // 
            FileNameControl.BackColor = Color.Transparent;
            FileNameControl.BottomMargin = 0;
            FileNameControl.Editable = true;
            FileNameControl.Encrypted = false;
            FileNameControl.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FileNameControl.Inititialized = true;
            FileNameControl.LabelBottomMargin = 0;
            FileNameControl.LabelColor = Color.LemonChiffon;
            FileNameControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FileNameControl.LabelText = "File Name:";
            FileNameControl.LabelTopMargin = 0;
            FileNameControl.LabelWidth = 140;
            FileNameControl.Location = new Point(57, 566);
            FileNameControl.MultiLine = false;
            FileNameControl.Name = "FileNameControl";
            FileNameControl.OnTextChangedListener = null;
            FileNameControl.PasswordMode = false;
            FileNameControl.ScrollBars = ScrollBars.None;
            FileNameControl.Size = new Size(428, 32);
            FileNameControl.TabIndex = 14;
            FileNameControl.TextBoxBottomMargin = 0;
            FileNameControl.TextBoxDisabledColor = Color.LightGray;
            FileNameControl.TextBoxEditableColor = Color.White;
            FileNameControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FileNameControl.TextBoxTopMargin = 0;
            FileNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // OutputFolderControl
            // 
            OutputFolderControl.BackColor = Color.Transparent;
            OutputFolderControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            OutputFolderControl.ButtonColor = Color.LemonChiffon;
            OutputFolderControl.ButtonImage = (Image)resources.GetObject("OutputFolderControl.ButtonImage");
            OutputFolderControl.ButtonWidth = 48;
            OutputFolderControl.DarkMode = false;
            OutputFolderControl.DisabledLabelColor = Color.Empty;
            OutputFolderControl.Editable = true;
            OutputFolderControl.EnabledLabelColor = Color.Empty;
            OutputFolderControl.Filter = null;
            OutputFolderControl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OutputFolderControl.HideBrowseButton = false;
            OutputFolderControl.LabelBottomMargin = 0;
            OutputFolderControl.LabelColor = Color.LemonChiffon;
            OutputFolderControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            OutputFolderControl.LabelText = "Output Folder:";
            OutputFolderControl.LabelTopMargin = 0;
            OutputFolderControl.LabelWidth = 140;
            OutputFolderControl.Location = new Point(57, 507);
            OutputFolderControl.Name = "OutputFolderControl";
            OutputFolderControl.OnTextChangedListener = null;
            OutputFolderControl.OpenCallback = null;
            OutputFolderControl.ScrollBars = ScrollBars.None;
            OutputFolderControl.SelectedPath = null;
            OutputFolderControl.Size = new Size(1096, 32);
            OutputFolderControl.StartPath = null;
            OutputFolderControl.TabIndex = 13;
            OutputFolderControl.TextBoxBottomMargin = 0;
            OutputFolderControl.TextBoxDisabledColor = Color.Empty;
            OutputFolderControl.TextBoxEditableColor = Color.Empty;
            OutputFolderControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OutputFolderControl.TextBoxTopMargin = 0;
            OutputFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // CreateCubesButton
            // 
            CreateCubesButton.BackColor = Color.Transparent;
            CreateCubesButton.ButtonText = "Create Cubes";
            CreateCubesButton.FlatStyle = FlatStyle.Flat;
            CreateCubesButton.ForeColor = Color.LemonChiffon;
            CreateCubesButton.Location = new Point(577, 615);
            CreateCubesButton.Margin = new Padding(4);
            CreateCubesButton.Name = "CreateCubesButton";
            CreateCubesButton.Size = new Size(178, 44);
            CreateCubesButton.TabIndex = 16;
            CreateCubesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            CreateCubesButton.Click += CreateCubesButton_Click;
            // 
            // ScenesPanel
            // 
            ScenesPanel.BackColor = Color.Transparent;
            ScenesPanel.Controls.Add(SaveSceneButton);
            ScenesPanel.Controls.Add(SceneNameControl);
            ScenesPanel.Controls.Add(SceneSelector);
            ScenesPanel.Location = new Point(-2222, 120);
            ScenesPanel.Name = "ScenesPanel";
            ScenesPanel.Size = new Size(1148, 160);
            ScenesPanel.TabIndex = 21;
            // 
            // SaveSceneButton
            // 
            SaveSceneButton.BackColor = Color.Transparent;
            SaveSceneButton.ButtonText = "Save";
            SaveSceneButton.FlatStyle = FlatStyle.Flat;
            SaveSceneButton.ForeColor = Color.LemonChiffon;
            SaveSceneButton.Location = new Point(456, 78);
            SaveSceneButton.Margin = new Padding(3, 2, 3, 2);
            SaveSceneButton.Name = "SaveSceneButton";
            SaveSceneButton.Size = new Size(120, 44);
            SaveSceneButton.TabIndex = 5;
            SaveSceneButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SceneNameControl
            // 
            SceneNameControl.BackColor = Color.Transparent;
            SceneNameControl.BottomMargin = 0;
            SceneNameControl.Editable = true;
            SceneNameControl.Encrypted = false;
            SceneNameControl.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SceneNameControl.Inititialized = true;
            SceneNameControl.LabelBottomMargin = 0;
            SceneNameControl.LabelColor = Color.LemonChiffon;
            SceneNameControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SceneNameControl.LabelText = "Scene Name:";
            SceneNameControl.LabelTopMargin = 0;
            SceneNameControl.LabelWidth = 140;
            SceneNameControl.Location = new Point(0, 84);
            SceneNameControl.MultiLine = false;
            SceneNameControl.Name = "SceneNameControl";
            SceneNameControl.OnTextChangedListener = null;
            SceneNameControl.PasswordMode = false;
            SceneNameControl.ScrollBars = ScrollBars.None;
            SceneNameControl.Size = new Size(428, 32);
            SceneNameControl.TabIndex = 4;
            SceneNameControl.TextBoxBottomMargin = 0;
            SceneNameControl.TextBoxDisabledColor = Color.LightGray;
            SceneNameControl.TextBoxEditableColor = Color.White;
            SceneNameControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SceneNameControl.TextBoxTopMargin = 0;
            SceneNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SceneSelector
            // 
            SceneSelector.BackColor = Color.Transparent;
            SceneSelector.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            SceneSelector.ButtonColor = Color.LemonChiffon;
            SceneSelector.ButtonImage = (Image)resources.GetObject("SceneSelector.ButtonImage");
            SceneSelector.ButtonWidth = 48;
            SceneSelector.DarkMode = false;
            SceneSelector.DisabledLabelColor = Color.Empty;
            SceneSelector.Editable = true;
            SceneSelector.EnabledLabelColor = Color.Empty;
            SceneSelector.Filter = null;
            SceneSelector.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SceneSelector.HideBrowseButton = false;
            SceneSelector.LabelBottomMargin = 0;
            SceneSelector.LabelColor = Color.LemonChiffon;
            SceneSelector.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SceneSelector.LabelText = "Select Scene:";
            SceneSelector.LabelTopMargin = 0;
            SceneSelector.LabelWidth = 140;
            SceneSelector.Location = new Point(0, 24);
            SceneSelector.Name = "SceneSelector";
            SceneSelector.OnTextChangedListener = null;
            SceneSelector.OpenCallback = null;
            SceneSelector.ScrollBars = ScrollBars.None;
            SceneSelector.SelectedPath = null;
            SceneSelector.Size = new Size(1132, 32);
            SceneSelector.StartPath = null;
            SceneSelector.TabIndex = 3;
            SceneSelector.TextBoxBottomMargin = 0;
            SceneSelector.TextBoxDisabledColor = Color.Empty;
            SceneSelector.TextBoxEditableColor = Color.Empty;
            SceneSelector.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SceneSelector.TextBoxTopMargin = 0;
            SceneSelector.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // PropsPanel
            // 
            PropsPanel.BackColor = Color.Transparent;
            PropsPanel.Controls.Add(SavePropButton);
            PropsPanel.Controls.Add(PropNameControl);
            PropsPanel.Controls.Add(PropSelector);
            PropsPanel.Location = new Point(-2222, 120);
            PropsPanel.Name = "PropsPanel";
            PropsPanel.Size = new Size(1148, 160);
            PropsPanel.TabIndex = 22;
            PropsPanel.Visible = false;
            // 
            // SavePropButton
            // 
            SavePropButton.BackColor = Color.Transparent;
            SavePropButton.ButtonText = "Save";
            SavePropButton.FlatStyle = FlatStyle.Flat;
            SavePropButton.ForeColor = Color.LemonChiffon;
            SavePropButton.Location = new Point(456, 78);
            SavePropButton.Margin = new Padding(3, 2, 3, 2);
            SavePropButton.Name = "SavePropButton";
            SavePropButton.Size = new Size(120, 44);
            SavePropButton.TabIndex = 8;
            SavePropButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // PropNameControl
            // 
            PropNameControl.BackColor = Color.Transparent;
            PropNameControl.BottomMargin = 0;
            PropNameControl.Editable = true;
            PropNameControl.Encrypted = false;
            PropNameControl.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PropNameControl.Inititialized = true;
            PropNameControl.LabelBottomMargin = 0;
            PropNameControl.LabelColor = Color.LemonChiffon;
            PropNameControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PropNameControl.LabelText = "Prop Name:";
            PropNameControl.LabelTopMargin = 0;
            PropNameControl.LabelWidth = 140;
            PropNameControl.Location = new Point(0, 84);
            PropNameControl.MultiLine = false;
            PropNameControl.Name = "PropNameControl";
            PropNameControl.OnTextChangedListener = null;
            PropNameControl.PasswordMode = false;
            PropNameControl.ScrollBars = ScrollBars.None;
            PropNameControl.Size = new Size(428, 32);
            PropNameControl.TabIndex = 7;
            PropNameControl.TextBoxBottomMargin = 0;
            PropNameControl.TextBoxDisabledColor = Color.LightGray;
            PropNameControl.TextBoxEditableColor = Color.White;
            PropNameControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PropNameControl.TextBoxTopMargin = 0;
            PropNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // PropSelector
            // 
            PropSelector.BackColor = Color.Transparent;
            PropSelector.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            PropSelector.ButtonColor = Color.LemonChiffon;
            PropSelector.ButtonImage = (Image)resources.GetObject("PropSelector.ButtonImage");
            PropSelector.ButtonWidth = 48;
            PropSelector.DarkMode = false;
            PropSelector.DisabledLabelColor = Color.Empty;
            PropSelector.Editable = true;
            PropSelector.EnabledLabelColor = Color.Empty;
            PropSelector.Filter = null;
            PropSelector.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PropSelector.HideBrowseButton = false;
            PropSelector.LabelBottomMargin = 0;
            PropSelector.LabelColor = Color.LemonChiffon;
            PropSelector.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PropSelector.LabelText = "Select Prop:";
            PropSelector.LabelTopMargin = 0;
            PropSelector.LabelWidth = 140;
            PropSelector.Location = new Point(0, 24);
            PropSelector.Name = "PropSelector";
            PropSelector.OnTextChangedListener = null;
            PropSelector.OpenCallback = null;
            PropSelector.ScrollBars = ScrollBars.None;
            PropSelector.SelectedPath = null;
            PropSelector.Size = new Size(1131, 32);
            PropSelector.StartPath = null;
            PropSelector.TabIndex = 6;
            PropSelector.TextBoxBottomMargin = 0;
            PropSelector.TextBoxDisabledColor = Color.Empty;
            PropSelector.TextBoxEditableColor = Color.Empty;
            PropSelector.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PropSelector.TextBoxTopMargin = 0;
            PropSelector.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MaterialsPanel
            // 
            MaterialsPanel.BackColor = Color.Transparent;
            MaterialsPanel.Controls.Add(MaterialTypeComboBox);
            MaterialsPanel.Controls.Add(SaveMaterialsButton);
            MaterialsPanel.Controls.Add(MaterialSelector);
            MaterialsPanel.Location = new Point(-2222, 120);
            MaterialsPanel.Name = "MaterialsPanel";
            MaterialsPanel.Size = new Size(1148, 160);
            MaterialsPanel.TabIndex = 23;
            MaterialsPanel.Visible = false;
            // 
            // MaterialTypeComboBox
            // 
            MaterialTypeComboBox.BackColor = Color.Transparent;
            MaterialTypeComboBox.ComboBoxLeftMargin = 1;
            MaterialTypeComboBox.ComboBoxText = "";
            MaterialTypeComboBox.ComoboBoxFont = null;
            MaterialTypeComboBox.Editable = true;
            MaterialTypeComboBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaterialTypeComboBox.HideLabel = false;
            MaterialTypeComboBox.LabelBottomMargin = 0;
            MaterialTypeComboBox.LabelColor = Color.LemonChiffon;
            MaterialTypeComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MaterialTypeComboBox.LabelText = "Material Type:";
            MaterialTypeComboBox.LabelTopMargin = 0;
            MaterialTypeComboBox.LabelWidth = 140;
            MaterialTypeComboBox.List = null;
            MaterialTypeComboBox.Location = new Point(0, 84);
            MaterialTypeComboBox.Name = "MaterialTypeComboBox";
            MaterialTypeComboBox.SelectedIndex = -1;
            MaterialTypeComboBox.SelectedIndexListener = null;
            MaterialTypeComboBox.Size = new Size(428, 32);
            MaterialTypeComboBox.Sorted = true;
            MaterialTypeComboBox.Source = null;
            MaterialTypeComboBox.TabIndex = 11;
            MaterialTypeComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SaveMaterialsButton
            // 
            SaveMaterialsButton.BackColor = Color.Transparent;
            SaveMaterialsButton.ButtonText = "Save";
            SaveMaterialsButton.FlatStyle = FlatStyle.Flat;
            SaveMaterialsButton.ForeColor = Color.LemonChiffon;
            SaveMaterialsButton.Location = new Point(456, 78);
            SaveMaterialsButton.Margin = new Padding(3, 2, 3, 2);
            SaveMaterialsButton.Name = "SaveMaterialsButton";
            SaveMaterialsButton.Size = new Size(120, 44);
            SaveMaterialsButton.TabIndex = 10;
            SaveMaterialsButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MaterialSelector
            // 
            MaterialSelector.BackColor = Color.Transparent;
            MaterialSelector.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            MaterialSelector.ButtonColor = Color.LemonChiffon;
            MaterialSelector.ButtonImage = (Image)resources.GetObject("MaterialSelector.ButtonImage");
            MaterialSelector.ButtonWidth = 48;
            MaterialSelector.DarkMode = false;
            MaterialSelector.DisabledLabelColor = Color.Empty;
            MaterialSelector.Editable = true;
            MaterialSelector.EnabledLabelColor = Color.Empty;
            MaterialSelector.Filter = null;
            MaterialSelector.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaterialSelector.HideBrowseButton = false;
            MaterialSelector.LabelBottomMargin = 0;
            MaterialSelector.LabelColor = Color.LemonChiffon;
            MaterialSelector.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MaterialSelector.LabelText = "Select File:";
            MaterialSelector.LabelTopMargin = 0;
            MaterialSelector.LabelWidth = 140;
            MaterialSelector.Location = new Point(0, 24);
            MaterialSelector.Name = "MaterialSelector";
            MaterialSelector.OnTextChangedListener = null;
            MaterialSelector.OpenCallback = null;
            MaterialSelector.ScrollBars = ScrollBars.None;
            MaterialSelector.SelectedPath = null;
            MaterialSelector.Size = new Size(1131, 32);
            MaterialSelector.StartPath = null;
            MaterialSelector.TabIndex = 9;
            MaterialSelector.TextBoxBottomMargin = 0;
            MaterialSelector.TextBoxDisabledColor = Color.Empty;
            MaterialSelector.TextBoxEditableColor = Color.Empty;
            MaterialSelector.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaterialSelector.TextBoxTopMargin = 0;
            MaterialSelector.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TabHostControl
            // 
            TabHostControl.BackColor = Color.DimGray;
            TabHostControl.BackgroundImage = (Image)resources.GetObject("TabHostControl.BackgroundImage");
            TabHostControl.BackgroundImageLayout = ImageLayout.Stretch;
            TabHostControl.Dock = DockStyle.Top;
            TabHostControl.LeftMargin = 816;
            TabHostControl.Location = new Point(0, 0);
            TabHostControl.Margin = new Padding(4, 3, 4, 3);
            TabHostControl.Name = "TabHostControl";
            TabHostControl.Size = new Size(1231, 64);
            TabHostControl.TabHostParent = null;
            TabHostControl.TabIndex = 24;
            TabHostControl.TopMargin = 0;
            TabHostControl.Load += TabHostControl_Load;
            // 
            // CreateBubblesButton
            // 
            CreateBubblesButton.BackColor = Color.Transparent;
            CreateBubblesButton.ButtonText = "Create Button";
            CreateBubblesButton.FlatStyle = FlatStyle.Flat;
            CreateBubblesButton.ForeColor = Color.LemonChiffon;
            CreateBubblesButton.Location = new Point(777, 615);
            CreateBubblesButton.Margin = new Padding(4);
            CreateBubblesButton.Name = "CreateBubblesButton";
            CreateBubblesButton.Size = new Size(178, 44);
            CreateBubblesButton.TabIndex = 25;
            CreateBubblesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BlackImage;
            ClientSize = new Size(1231, 758);
            Controls.Add(CreateBubblesButton);
            Controls.Add(MaterialsPanel);
            Controls.Add(PropsPanel);
            Controls.Add(CreateCubesButton);
            Controls.Add(FileNameControl);
            Controls.Add(OutputFolderControl);
            Controls.Add(NumberPropsControl);
            Controls.Add(CreatePropsButton);
            Controls.Add(StatusLabel);
            Controls.Add(Graph);
            Controls.Add(TabHostControl);
            Controls.Add(ScenesPanel);
            DoubleBuffered = true;
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.LemonChiffon;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Random Data";
            ScenesPanel.ResumeLayout(false);
            PropsPanel.ResumeLayout(false);
            MaterialsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        #endregion
        private Label StatusLabel;
        private ProgressBar Graph;
        private DataJuggler.Win.Controls.Button CreatePropsButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl NumberPropsControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl FileNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl OutputFolderControl;
        private DataJuggler.Win.Controls.Button CreateCubesButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender ScenesPanel;
        private DataJuggler.Win.Controls.Button SaveSceneButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl SceneNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl SceneSelector;
        private DataJuggler.Win.Controls.Objects.PanelExtender PropsPanel;
        private DataJuggler.Win.Controls.Button SavePropButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl PropNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl PropSelector;
        private DataJuggler.Win.Controls.Objects.PanelExtender MaterialsPanel;
        private DataJuggler.Win.Controls.LabelComboBoxControl MaterialTypeComboBox;
        private DataJuggler.Win.Controls.Button SaveMaterialsButton;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl MaterialSelector;
        private DataJuggler.Win.Controls.TabHostControl TabHostControl;
        private DataJuggler.Win.Controls.Button CreateBubblesButton;
    }
    #endregion

}
