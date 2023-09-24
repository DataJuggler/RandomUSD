

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private MaterialController materialController;
        private PropController propController;
        private SceneController sceneController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.MaterialController = new MaterialController(this.ErrorProcessor, this.AppController);
                this.PropController = new PropController(this.ErrorProcessor, this.AppController);
                this.SceneController = new SceneController(this.ErrorProcessor, this.AppController);
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

            #region MaterialController
            public MaterialController MaterialController
            {
                get { return materialController; }
                set { materialController = value; }
            }
            #endregion

            #region PropController
            public PropController PropController
            {
                get { return propController; }
                set { propController = value; }
            }
            #endregion

            #region SceneController
            public SceneController SceneController
            {
                get { return sceneController; }
                set { sceneController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
