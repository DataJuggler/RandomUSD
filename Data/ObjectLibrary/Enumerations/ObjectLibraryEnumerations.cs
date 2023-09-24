

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum MaterialTypeEnum : int
    /// <summary>
    /// The category of Material
    /// </summary>
    public enum MaterialTypeEnum : int
    {
        Unknown = 0,
        Glass = 1,
        Masonry = 2,
        Metal = 3,
        Plastic = 4,
        Stone = 5,
        Textile = 6,
        Wood = 7
    }
    #endregion

    #region PropTypeEnum : int
    /// <summary>
    /// What type of Prop is this
    /// </summary>
    public enum PropTypeEnum : int
    {
        Unknown = 0,
        Cone = 1,
        Cube = 2,
        Cylinder = 3,
        Disk = 4,
        Plane = 5,
        Sphere = 6,
        Torus = 7
    }
    #endregion

    #region ScreenTypeEnum : int
    /// <summary>
    /// This enum is used to dermine which screen to show
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        Scenes = 0,
        Props = 1,
        Materials = 2
    }
    #endregion

}
