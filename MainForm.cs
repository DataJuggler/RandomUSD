

#region using statements

using DataGateway;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using ApplicationLogicComponent.Connection;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using DataJuggler.RandomShuffler;
using System.Text;
using System.Drawing.Text;

#endregion

namespace RandomUSD
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this app.
    /// </summary>
    public partial class MainForm : Form, ITextChanged, ITabHostControlParent
    {

        #region Private Variables
        private Gateway gateway;
        private int conesCount;
        private int cubesCount;
        private int cylindersCount;
        private int disksCount;
        private int planesCount;
        private int spheresCount;
        private int torusCount;
        private RandomShuffler rotateShuffler;
        private RandomShuffler scaleShuffler;
        private RandomShuffler translateShuffler;
        private ScreenTypeEnum screenType;
        private const string MaterialPathStart = "token outputs:mdl:displacement.connect = ";
        private const string MaterialReplacePath = "/Shader.outputs:out";
        private const string FourSpaces = "    ";
        private const string EightSpaces = "        ";
        private const string MaterialNameStart = "def Material";
        private const string InsertMaterials = "# Insert Materials Here";
        private const string InsertProps = "# Insert Props Here";
        private const int TranslateYStart = 50;
        private const string GroundPlaneMaterialPath = "[GroupPlaneMaterialPath]";
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region CreateCubesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'CreateCubesButton' is clicked.
        /// </summary>
        private void CreateCubesButton_Click(object sender, EventArgs e)
        {
            // Get the number props
            int propsToCreate = NumberPropsControl.IntValue;

            // for now use the first scene
            Scene scene = Gateway.LoadScenes().FirstOrDefault();

            // Now create the props
            List<Prop> props = new List<Prop>();
            List<Material> materials = new List<Material>();
            int index = -1;
            Prop prop = null;
            Material material = null;
            string materialsText = "";
            string propsText = "";
            string groundPlaneMaterialPath = "";

            // reusing the same selector for Scene
            if (NullHelper.Exists(scene))
            {
                // If the value for propsToCreate is greater than zero
                if (propsToCreate > 0)
                {
                    // Load all the materials
                    List<Material> allMaterials = Gateway.LoadMaterials();

                    // If the allProps collection and the allMaterials collection both exist and each have one or more items
                    if (ListHelper.HasOneOrMoreItems(allMaterials))
                    {
                        RandomShuffler materialsShuffler = new RandomShuffler(0, allMaterials.Count - 1, 8);

                        // Shuffle five times
                        materialsShuffler.Shuffle(5);

                        // Set the index
                        index = materialsShuffler.PullNextItem();

                        // Get a copy
                        Material groundPlaneMaterial = allMaterials[index];

                        // Set the groundPlaneMaterialsPath
                        groundPlaneMaterialPath = groundPlaneMaterial.Path;

                        // add this material
                        materials.Add(groundPlaneMaterial);

                        // create the nujmber of props requested
                        for (int x = 0; x < propsToCreate; x++)
                        {
                            // Set the prop
                            prop = Gateway.FindProp(6);

                            // Add this item
                            props.Add(prop);

                            // Shuffle 5 extra times
                            materialsShuffler.Shuffle(5);

                            // Pull the props
                            index = materialsShuffler.PullNextItem();

                            // Set the material
                            material = allMaterials[index];

                            // Set the material
                            prop.Material = material;

                            // is this material in list
                            bool isMaterialInList = materials.Contains(material);

                            // if the material is not already in the list
                            if (!isMaterialInList)
                            {
                                // Add this material
                                materials.Add(material);
                            }
                        }
                    }

                    // verify we have an OutputFolder
                    if ((Directory.Exists(OutputFolderControl.Text)) && (FileNameControl.HasText))
                    {
                        // itererate up t the number of props
                        for (int x = 0; x < props.Count; x++)
                        {
                            // Set the prop
                            prop = props[x];

                            // Add to the propText
                            propsText = AddToPropsText(propsText, prop, (x == 0), x);
                        }

                        for (int x = 0; x < materials.Count; x++)
                        {
                            // Get this material
                            material = materials[x];

                            // Add to the propText
                            materialsText = AddToMaterialsText(materialsText, material, (x == 0));
                        }
                    }

                    // Trim off any extra blank lines
                    propsText = propsText.Trim();
                    materialsText = materialsText.Trim();

                    // Get the filePath to write to
                    string filePath = Path.Combine(OutputFolderControl.Text, FileNameControl.Text);

                    // Add the props
                    string fileText = scene.Text.Replace(InsertProps, propsText);

                    // Add the materials
                    fileText = fileText.Replace(InsertMaterials, materialsText);

                    // Set the ground plane material
                    fileText = fileText.Replace(GroundPlaneMaterialPath, groundPlaneMaterialPath);

                    // Write out the text
                    File.WriteAllText(filePath, fileText);

                    // Set the text
                    StatusLabel.Text = "File " + filePath + " Created.";
                }
            }
        }
        #endregion

        #region CreatePropsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'CreatePropsButton' is clicked.
        /// </summary>
        private void CreatePropsButton_Click(object sender, EventArgs e)
        {
            // Get the number props
            int propsToCreate = NumberPropsControl.IntValue;

            // for now use the first scene
            Scene scene = Gateway.LoadScenes().FirstOrDefault();

            // Now create the props
            List<Prop> props = new List<Prop>();
            List<Material> materials = new List<Material>();
            int index = -1;
            Prop prop = null;
            Material material = null;
            string materialsText = "";
            string propsText = "";
            string groundPlaneMaterialPath = "";

            // reusing the same selector for Scene
            if (NullHelper.Exists(scene))
            {
                // If the value for propsToCreate is greater than zero
                if (propsToCreate > 0)
                {
                    // Load all the props
                    List<Prop> allProps = Gateway.LoadProps();

                    // Load all the materials
                    List<Material> allMaterials = Gateway.LoadMaterials();

                    // If the allProps collection and the allMaterials collection both exist and each have one or more items
                    if (ListHelper.HasOneOrMoreItems(allProps, allMaterials))
                    {
                        // Create the shufflers
                        RandomShuffler propsShuffler = new RandomShuffler(0, allProps.Count - 1, 8);
                        RandomShuffler materialsShuffler = new RandomShuffler(0, allMaterials.Count - 1, 8);

                        // Shuffle five times
                        materialsShuffler.Shuffle(5);

                        // Set the index
                        index = materialsShuffler.PullNextItem();

                        // Get a copy
                        Material groundPlaneMaterial = allMaterials[index];

                        // Set the groundPlaneMaterialsPath
                        groundPlaneMaterialPath = groundPlaneMaterial.Path;

                        // add this material
                        materials.Add(groundPlaneMaterial);

                        // create the nujmber of props requested
                        for (int x = 0; x < propsToCreate; x++)
                        {
                            // Pull the props
                            index = propsShuffler.PullNextItem();

                            // Set the prop
                            prop = allProps[index];

                            // Add this item
                            props.Add(prop);

                            // Shuffle 5 extra times
                            materialsShuffler.Shuffle(5);

                            // Pull the props
                            index = materialsShuffler.PullNextItem();

                            // Set the material
                            material = allMaterials[index];

                            // Set the material
                            prop.Material = material;

                            // is this material in list
                            bool isMaterialInList = materials.Contains(material);

                            // if the material is not already in the list
                            if (!isMaterialInList)
                            {
                                // Add this material
                                materials.Add(material);
                            }
                        }
                    }

                    // verify we have an OutputFolder
                    if ((Directory.Exists(OutputFolderControl.Text)) && (FileNameControl.HasText))
                    {
                        // itererate up t the number of props
                        for (int x = 0; x < props.Count; x++)
                        {
                            // Set the prop
                            prop = props[x];

                            // Add to the propText
                            propsText = AddToPropsText(propsText, prop, (x == 0), x);
                        }

                        for (int x = 0; x < materials.Count; x++)
                        {
                            // Get this material
                            material = materials[x];

                            // Add to the propText
                            materialsText = AddToMaterialsText(materialsText, material, (x == 0));
                        }
                    }

                    // Trim off any extra blank lines
                    propsText = propsText.Trim();
                    materialsText = materialsText.Trim();

                    // Get the filePath to write to
                    string filePath = Path.Combine(OutputFolderControl.Text, FileNameControl.Text);

                    // Add the props
                    string fileText = scene.Text.Replace(InsertProps, propsText);

                    // Add the materials
                    fileText = fileText.Replace(InsertMaterials, materialsText);

                    // Set the ground plane material
                    fileText = fileText.Replace(GroundPlaneMaterialPath, groundPlaneMaterialPath);

                    // Write out the text
                    File.WriteAllText(filePath, fileText);

                    // Set the text
                    StatusLabel.Text = "File " + filePath + " Created.";
                }
            }
        }
        #endregion

        #region MaterialsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'MaterialsButton' is clicked.
        /// </summary>
        private void MaterialsButton_Click(object sender, EventArgs e)
        {
            // Setup the Screen
            UIVisibility(ScreenTypeEnum.Materials);
        }
        #endregion

        #region OnTextChanged(Control sender, string text)
        /// <summary>
        /// event is fired when On Text Changed
        /// </summary>
        public void OnTextChanged(Control sender, string text)
        {
            // if a file was selected in the Scene Selector
            if (sender.Name == SceneSelector.Name)
            {
                // Determine the Scene Name from the file

                // Get the FileInfo
                FileInfo fileInfo = new FileInfo(text);

                // Set the Name
                SceneNameControl.Text = fileInfo.Name.Replace(fileInfo.Extension, "").Replace("Scene", " Scene");
            }
            else if (sender.Name == PropSelector.Name)
            {
                // Determine the Prop Name from the file

                // Get the FileInfo
                FileInfo fileInfo = new FileInfo(text);

                // Set the Name
                PropNameControl.Text = fileInfo.Name.Replace(fileInfo.Extension, "");
            }
        }
        #endregion

        #region PropsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'PropsButton' is clicked.
        /// </summary>
        private void PropsButton_Click(object sender, EventArgs e)
        {
            // AppDomainSetup for Props
            UIVisibility(ScreenTypeEnum.Props);
        }
        #endregion

        #region SaveMaterialsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SaveMaterialsButton' is clicked.
        /// </summary>
        private void SaveMaterialsButton_Click(object sender, EventArgs e)
        {
            // local
            int savedCount = 0;

            // if a File has been selected
            if (MaterialSelector.HasText)
            {
                string fileText = File.ReadAllText(MaterialSelector.Text);

                // Get the TextLine objects from the file text
                List<TextLine> lines = TextHelper.GetTextLines(fileText);

                // Create a list of TextLineGroups
                List<List<TextLine>> textLineGroups = new List<List<TextLine>>();

                // declare
                List<TextLine> textLineGroup = null;

                // If the value for the property MaterialSelector.HasText is true
                if (MaterialSelector.HasText)
                {
                    // Get the FileText
                    fileText = File.ReadAllText(MaterialSelector.Text);

                    // If the fileText string exists
                    if (TextHelper.Exists(fileText))
                    {
                        // If the fileText collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // divide the text lines up into groups, splitting on blank lines

                            // Iterate the collection of TextLine objects
                            foreach (TextLine line in lines)
                            {
                                // if this is a new material
                                if (line.Text.Trim().StartsWith(MaterialNameStart))
                                {
                                    // Create the group
                                    textLineGroup = new List<TextLine>();

                                    // Add this line
                                    textLineGroup.Add(line);

                                    // Add this group
                                    textLineGroups.Add(textLineGroup);
                                }
                                else if (!TextHelper.Exists(line.Text.Trim()))
                                {
                                    // do nothing
                                }
                                else
                                {
                                    // If the textLineGroup object exists
                                    if (NullHelper.Exists(textLineGroup))
                                    {
                                        // Add this line
                                        textLineGroup.Add(line);
                                    }
                                }
                            }
                        }

                        // If the textLineGroups collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(textLineGroups))
                        {
                            // iterate the groups                        
                            foreach (List<TextLine> group in textLineGroups)
                            {
                                // Now the textLineGroup must be parsed into a Material
                                Material material = ParseMaterial(group);

                                // If the material object exists
                                if (NullHelper.Exists(material))
                                {
                                    // save this material
                                    bool saved = Gateway.SaveMaterial(ref material);

                                    // if the value for saved is true
                                    if (saved)
                                    {
                                        // Increment the value for savedCount
                                        savedCount++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // If the value for savedCount is greater than zero
            if (savedCount > 0)
            {
                // Set to LemonChiffon
                StatusLabel.ForeColor = Color.LemonChiffon;

                // Set the Text
                StatusLabel.Text = "Saved " + savedCount + " " + MaterialTypeComboBox.ComboBoxText + " Materials";
            }
        }
        #endregion

        #region SavePropButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SavePropButton' is clicked.
        /// </summary>
        private void SavePropButton_Click(object sender, EventArgs e)
        {
            // local
            bool isValidProp = true;

            // if no file is selected
            if (!PropSelector.HasText)
            {
                // Show a meesage
                StatusLabel.ForeColor = Color.Firebrick;
                StatusLabel.Text = "You must select the file in usda format.";

                // not valid
                isValidProp = false;
            }
            else if (!PropNameControl.HasText)
            {
                StatusLabel.ForeColor = Color.Firebrick;
                StatusLabel.Text = "Prop Name is required.";

                // not valid
                isValidProp = false;
            }

            // if the value for isValidProp is true
            if (isValidProp)
            {
                // Create a new instance of a 'Prop' object.
                Prop prop = new Prop();

                // Set the values
                prop.Name = PropNameControl.Text;
                // prop.Text = File.ReadAllText(PropSelector.Text);

                // Save this Scene
                bool saved = Gateway.SaveProp(ref prop);

                // if saved
                if (saved)
                {
                    // set the color
                    StatusLabel.ForeColor = Color.LemonChiffon;

                    // Display a message
                    StatusLabel.Text = "Prop " + prop.Name + " Saved!";
                }
                else
                {
                    // set the color
                    StatusLabel.ForeColor = Color.Firebrick;

                    // Display a message
                    StatusLabel.Text = "Save " + prop.Name + " Failed!";
                }
            }
        }
        #endregion

        #region SaveSceneButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SaveSceneButton' is clicked.
        /// </summary>
        private void SaveSceneButton_Click(object sender, EventArgs e)
        {
            // local
            bool isValidScene = true;

            // if no file is selected
            if (!SceneSelector.HasText)
            {
                // Show a meesage
                StatusLabel.ForeColor = Color.Firebrick;
                StatusLabel.Text = "You must select the file in usda format.";

                // not valid
                isValidScene = false;
            }
            else if (!SceneNameControl.HasText)
            {
                StatusLabel.ForeColor = Color.Firebrick;
                StatusLabel.Text = "Scene Name is required.";

                // not valid
                isValidScene = false;
            }

            // if the value for isValidScene is true
            if (isValidScene)
            {
                // Create a new instance of a 'Scene' object.
                Scene scene = new Scene();

                // Set the values
                scene.Name = SceneNameControl.Text;
                scene.Text = File.ReadAllText(SceneSelector.Text);

                // Save this Scene
                bool saved = Gateway.SaveScene(ref scene);

                // if saved
                if (saved)
                {
                    // set the color
                    StatusLabel.ForeColor = Color.LemonChiffon;

                    // Display a message
                    StatusLabel.Text = "Scene Saved!";
                }
                else
                {
                    // set the color
                    StatusLabel.ForeColor = Color.Firebrick;

                    // Display a message
                    StatusLabel.Text = "Save Failed.";
                }
            }
        }
        #endregion

        #region SceneButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SceneButton' is clicked.
        /// </summary>
        private void SceneButton_Click(object sender, EventArgs e)
        {
            // Set this button
            UIVisibility(ScreenTypeEnum.Scenes);
        }
        #endregion

        #region TabHostControl_Load(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Tab Host Control _ Load
        /// </summary>
        private void TabHostControl_Load(object sender, EventArgs e)
        {
            // Setup the TabHostControl
            TabHostControl.AddTabButton(3, "Materials", 200, Color.Black, false);
            TabHostControl.AddTabButton(2, "Props", 200, Color.Black, false);
            TabHostControl.AddTabButton(1, "Scenes", 200, Color.Black, true);
            TabHostControl.TopMargin = 16;
            TabHostControl.LeftMargin = 8;

            // Setup the Parent
            TabHostControl.TabHostParent = this;
        }
        #endregion

        #endregion

        #region Methods

        #region AddToMaterialsText(string matertialsText, Material material, bool isFirstMaterial)
        /// <summary>
        /// Adds the current material to the Materials Text with a few replacemnets
        /// </summary>
        public string AddToMaterialsText(string materialsText, Material material, bool isFirstMaterial)
        {
            // Create a string builder
            StringBuilder sb = new StringBuilder(materialsText);

            // if the value for isFirstMaterial is true
            if (isFirstMaterial)
            {
                // Add as is
                sb.Append(material.Text);
            }
            else
            {
                // Add eight spaces
                sb.Append(EightSpaces);

                // Add as is
                sb.Append(material.Text);
            }

            // Add blank lines (last 1 gets trimmed off
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);

            // Set the return value
            materialsText = sb.ToString();

            // return value
            return materialsText;
        }
        #endregion

        #region AddToPropsText(string propsText, Prop prop, isFirstProp, int propNumber)
        /// <summary>
        /// Adds the current prop to the Props Text, with a few replacements
        /// </summary>
        public string AddToPropsText(string propsText, Prop prop, bool isFirstProp, int propNumber)
        {
            // Create a string builder
            StringBuilder sb = new StringBuilder(propsText);

            // locals
            string text = "";

            // it isn't known yet
            PropTypeEnum propType = PropTypeEnum.Unknown;

            // If the 'prop' object and the 'material' objects both exist.
            if (NullHelper.Exists(prop))
            {
                // set Prop Count
                propType = SetPropCount(prop);

                // if this is not the firstProp
                if (isFirstProp)
                {
                    // Set the text
                    //  text = prop.Text;
                }
                else
                {
                    // text = FourSpaces + prop.Text;
                }

                // change out the number
                text = ChangeName(text, propType);

                // change out the material path
                text = text.Replace("[MaterialPath]", prop.Material.Path);

                // Replace out the rotation, scale and translate values
                text = ReplaceRotationValues(text);
                text = ReplaceScaleValues(text, propType);
                text = ReplaceTranslateValues(text, propNumber);

                // Append the text
                sb.Append(text);

                // Add a blank line to the end (the last prop gets trimmed)
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // set the return value
                propsText = sb.ToString();
            }

            // return value
            return propsText;
        }
        #endregion

        #region ChangeName(string text, PropTypeEnum propType)
        /// <summary>
        /// returns the Name
        /// </summary>
        public string ChangeName(string text, PropTypeEnum propType)
        {
            switch (propType)
            {
                case PropTypeEnum.Cone:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", ConesCount.ToString());

                    // required
                    break;

                case PropTypeEnum.Cube:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", CubesCount.ToString());

                    // required
                    break;

                case PropTypeEnum.Cylinder:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", CylindersCount.ToString());

                    // required
                    break;

                case PropTypeEnum.Disk:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", DisksCount.ToString());

                    // required
                    break;

                case PropTypeEnum.Plane:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", PlanesCount.ToString());

                    // required
                    break;

                case PropTypeEnum.Sphere:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", SpheresCount.ToString());

                    // required
                    break;

                case PropTypeEnum.Torus:

                    // Replace out the Number with the number
                    text = text.Replace("[Number]", TorusCount.ToString());

                    // required
                    break;
            }

            // return value
            return text;
        }
        #endregion

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // Create a new instance of a 'Gateway' object.
            Gateway = new Gateway(Connection.Name);

            // Setup the Listeners
            SceneSelector.OnTextChangedListener = this;
            PropSelector.OnTextChangedListener = this;

            // Load the Material Type choices
            MaterialTypeComboBox.LoadItems(typeof(MaterialTypeEnum));

            // Create the Shufflers
            RotateShuffler = new RandomShuffler(1, 360, 10, 5);
            ScaleShuffler = new RandomShuffler(1, 200, 10, 5);
            TranslateShuffler = new RandomShuffler(1, 40, 10, 5);

            // Start off with Scenes
            UIVisibility(ScreenTypeEnum.Scenes);
        }
        #endregion

        #region ParseMaterial(List<TextLine> group)
        /// <summary>
        /// returns the Material
        /// </summary>
        public Material ParseMaterial(List<TextLine> group)
        {
            // initial value
            Material material = null;

            // If the group object exists
            if (NullHelper.Exists(group))
            {
                // Create a new instance of a 'Material' object.
                material = new Material();

                // Get the text of the group
                material.Text = TextHelper.ExportTextLines(group).Trim();

                // now find the name
                if (ListHelper.HasXOrMoreItems(group, 3))
                {
                    // Get the title
                    material.Title = group[0].Text.Replace(MaterialNameStart, "").Trim().Replace("\"", "");

                    // Set the Path
                    material.Path = group[2].Text.Replace(MaterialPathStart, "").Replace(MaterialReplacePath, "").Trim();
                }

                // Parse the Material Type
                material.MaterialType = ParseMaterialType(MaterialTypeComboBox.ComboBoxText);
            }

            // return value
            return material;
        }
        #endregion

        #region ParseMaterialType(string materialTypeText)
        /// <summary>
        /// returns the Material Type
        /// </summary>
        public MaterialTypeEnum ParseMaterialType(string materialTypeText)
        {
            // initial value
            MaterialTypeEnum materialType = MaterialTypeEnum.Unknown;

            // If the materialTypeText string exists
            if (TextHelper.Exists(materialTypeText))
            {
                switch (materialTypeText)
                {
                    case "Glass":

                        // Set to Gass
                        materialType = MaterialTypeEnum.Glass;

                        // required
                        break;

                    case "Masonry":

                        // Set to Masonry
                        materialType = MaterialTypeEnum.Masonry;

                        // required
                        break;

                    case "Metal":

                        // Set to Metal
                        materialType = MaterialTypeEnum.Metal;

                        // required
                        break;

                    case "Plastic":

                        // Set to Plastic
                        materialType = MaterialTypeEnum.Plastic;

                        // required
                        break;

                    case "Stone":

                        // Set to Stone
                        materialType = MaterialTypeEnum.Stone;

                        // required
                        break;

                    case "Textile":

                        // Set to Textile
                        materialType = MaterialTypeEnum.Textile;

                        // required
                        break;

                    case "Wood":

                        // Set to Wood
                        materialType = MaterialTypeEnum.Wood;

                        // required
                        break;
                }
            }

            // return value
            return materialType;
        }
        #endregion

        #region ReplaceRotationValues(string sourceText)
        /// <summary>
        /// returns the Rotation Values
        /// </summary>
        public string ReplaceRotationValues(string sourceText)
        {
            // get the 3 values
            int rotationX = RotateShuffler.PullNextItem();
            int rotationY = RotateShuffler.PullNextItem();
            int rotationZ = RotateShuffler.PullNextItem();

            // Replace out the values
            sourceText = sourceText.Replace("[RotateX]", rotationX.ToString());
            sourceText = sourceText.Replace("[RotateY]", rotationY.ToString());
            sourceText = sourceText.Replace("[RotateZ]", rotationZ.ToString());

            // return value
            return sourceText;
        }
        #endregion

        #region ReplaceScaleValues(string sourceText, PropTypeEnum propType)
        /// <summary>
        /// returns the Scale Values
        /// </summary>
        public string ReplaceScaleValues(string sourceText, PropTypeEnum propType)
        {
            // get the 3 values (.1 - 20.0)
            double scaleX = ScaleShuffler.PullNextItem() * .1 + 1;
            double scaleY = ScaleShuffler.PullNextItem() * .1 + 1;
            double scaleZ = ScaleShuffler.PullNextItem() * .1 + 1;

            // round to 1 decimal
            scaleX = Math.Round(scaleX, 1);

            if ((propType == PropTypeEnum.Sphere) || (propType == PropTypeEnum.Cone) || (propType == PropTypeEnum.Disk) || (propType == PropTypeEnum.Torus))
            {
                // All the same for Spheres, Disks and Toruses.
                scaleY = scaleX;
                scaleZ = scaleX;
            }
            else
            {
                scaleY = Math.Round(scaleY, 1);
                scaleZ = Math.Round(scaleZ, 1);
            }

            // Replace out the values
            sourceText = sourceText.Replace("[ScaleX]", scaleX.ToString());
            sourceText = sourceText.Replace("[ScaleY]", scaleY.ToString());
            sourceText = sourceText.Replace("[ScaleZ]", scaleZ.ToString());

            // return value
            return sourceText;
        }
        #endregion

        #region ReplaceTranslateValues(string sourceText)
        /// <summary>
        /// returns the Translate Values
        /// </summary>
        public string ReplaceTranslateValues(string sourceText, int propNumber)
        {
            // get the 3 values (.1 - 20.0)
            int translateX = TranslateShuffler.PullNextItem();
            int translateY = TranslateShuffler.PullNextItem() + TranslateYStart + (propNumber * 25);
            int translateZ = TranslateShuffler.PullNextItem();

            // Replace out the values
            sourceText = sourceText.Replace("[TranslateX]", translateX.ToString());
            sourceText = sourceText.Replace("[TranslateY]", translateY.ToString());
            sourceText = sourceText.Replace("[TranslateZ]", translateZ.ToString());

            // return value
            return sourceText;
        }
        #endregion

        #region SetPropCount(Prop prop)
        /// <summary>
        /// Set Prop Count
        /// </summary>
        public PropTypeEnum SetPropCount(Prop prop)
        {
            // initial value
            PropTypeEnum propType = PropTypeEnum.Unknown;

            // If the prop object exists
            if (NullHelper.Exists(prop))
            {
                switch (prop.Name)
                {
                    case "Cone":

                        // Increment the value for ConesCount
                        ConesCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Cone;

                        // required
                        break;

                    case "Cube":

                        // Increment the value for CubesCount
                        CubesCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Cube;

                        // required
                        break;

                    case "Cylinder":

                        // Increment the value for CylindersCount
                        CylindersCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Cylinder;

                        // required
                        break;

                    case "Disk":

                        // Increment the value for DisksCoun
                        DisksCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Disk;

                        // required
                        break;

                    case "Plane":

                        // Increment the value for PlanesCount
                        PlanesCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Plane;

                        // required
                        break;

                    case "Sphere":


                        // Increment the value for SpheresCount
                        SpheresCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Sphere;

                        // required
                        break;

                    case "Torus":

                        // Increment the value for TorusCount
                        TorusCount++;

                        // Set the PropType
                        propType = PropTypeEnum.Torus;

                        // required
                        break;
                }
            }

            // return value
            return propType;
        }
        #endregion

        #region TabSelected(TabButton selectedButton)
        /// <summary>
        /// method returns the Selected
        /// </summary>
        public void TabSelected(TabButton selectedButton)
        {
            // If the selectedButton object exists
            if (NullHelper.Exists(selectedButton))
            {
                switch (selectedButton.ButtonNumber)
                {
                    case 1:

                        // setup for Scenes
                        UIVisibility(ScreenTypeEnum.Scenes);

                        // required
                        break;

                    case 2:

                        // setup for Props
                        UIVisibility(ScreenTypeEnum.Props);

                        // required
                        break;

                    case 3:

                        // setup for Materials
                        UIVisibility(ScreenTypeEnum.Materials);

                        // required
                        break;
                }
            }
        }
        #endregion

        #region UIVisibility()
        /// <summary>
        /// UI Visibility
        /// </summary>
        public void UIVisibility(ScreenTypeEnum screenType)
        {
            // Set the ScreenType
            ScreenType = screenType;

            // Hide all at first
            ScenesPanel.Visible = false;
            PropsPanel.Visible = false;
            MaterialsPanel.Visible = false;

            // Move all out of screen for now
            ScenesPanel.Left = -2222;
            PropsPanel.Left = -2222;
            MaterialsPanel.Left = -2222;

            switch (ScreenType)
            {
                case ScreenTypeEnum.Scenes:

                    // Show
                    ScenesPanel.Visible = true;
                    ScenesPanel.Left = 22;

                    // required
                    break;

                case ScreenTypeEnum.Props:

                    // Show
                    PropsPanel.Visible = true;
                    PropsPanel.Left = 22;



                    // required
                    break;

                case ScreenTypeEnum.Materials:

                    // Show
                    MaterialsPanel.Visible = true;
                    MaterialsPanel.Left = 22;



                    // required
                    break;
            }
        }
        #endregion

        #endregion

        #region Properties

        #region ConesCount
        /// <summary>
        /// This property gets or sets the value for 'ConesCount'.
        /// </summary>
        public int ConesCount
        {
            get { return conesCount; }
            set { conesCount = value; }
        }
        #endregion

        #region CubesCount
        /// <summary>
        /// This property gets or sets the value for 'CubesCount'.
        /// </summary>
        public int CubesCount
        {
            get { return cubesCount; }
            set { cubesCount = value; }
        }
        #endregion

        #region CylindersCount
        /// <summary>
        /// This property gets or sets the value for 'CylindersCount'.
        /// </summary>
        public int CylindersCount
        {
            get { return cylindersCount; }
            set { cylindersCount = value; }
        }
        #endregion

        #region DisksCount
        /// <summary>
        /// This property gets or sets the value for 'DisksCount'.
        /// </summary>
        public int DisksCount
        {
            get { return disksCount; }
            set { disksCount = value; }
        }
        #endregion

        #region Gateway
        /// <summary>
        /// This property gets or sets the value for 'Gateway'.
        /// </summary>
        public Gateway Gateway
        {
            get { return gateway; }
            set { gateway = value; }
        }
        #endregion

        #region HasGateway
        /// <summary>
        /// This property returns true if this object has a 'Gateway'.
        /// </summary>
        public bool HasGateway
        {
            get
            {
                // initial value
                bool hasGateway = (this.Gateway != null);

                // return value
                return hasGateway;
            }
        }
        #endregion

        #region PlanesCount
        /// <summary>
        /// This property gets or sets the value for 'PlanesCount'.
        /// </summary>
        public int PlanesCount
        {
            get { return planesCount; }
            set { planesCount = value; }
        }
        #endregion

        #region RotateShuffler
        /// <summary>
        /// This property gets or sets the value for 'RotateShuffler'.
        /// </summary>
        public RandomShuffler RotateShuffler
        {
            get { return rotateShuffler; }
            set { rotateShuffler = value; }
        }
        #endregion

        #region ScaleShuffler
        /// <summary>
        /// This property gets or sets the value for 'ScaleShuffler'.
        /// </summary>
        public RandomShuffler ScaleShuffler
        {
            get { return scaleShuffler; }
            set { scaleShuffler = value; }
        }
        #endregion

        #region ScreenType
        /// <summary>
        /// This property gets or sets the value for 'ScreenType'.
        /// </summary>
        public ScreenTypeEnum ScreenType
        {
            get { return screenType; }
            set { screenType = value; }
        }
        #endregion

        #region SpheresCount
        /// <summary>
        /// This property gets or sets the value for 'SpheresCount'.
        /// </summary>
        public int SpheresCount
        {
            get { return spheresCount; }
            set { spheresCount = value; }
        }
        #endregion

        #region TorusCount
        /// <summary>
        /// This property gets or sets the value for 'TorusCount'.
        /// </summary>
        public int TorusCount
        {
            get { return torusCount; }
            set { torusCount = value; }
        }
        #endregion

        #region TranslateShuffler
        /// <summary>
        /// This property gets or sets the value for 'TranslateShuffler'.
        /// </summary>
        public RandomShuffler TranslateShuffler
        {
            get { return translateShuffler; }
            set { translateShuffler = value; }
        }

        public TabButton SelectedTab { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #endregion

    }
    #endregion

}
