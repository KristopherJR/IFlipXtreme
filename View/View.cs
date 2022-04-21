//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// View:  Wrapper class for the application GUI Forms.
    /// </summary>
    public class View : IView
    {
        #region Fields
        // DECLARE an IGalleryView, call it "_gallery":
        private IGalleryView _gallery;

        // DECLARE an IImageView, call it "_editor":
        private IImageView _editor;

        // DECLARE an Action<ICommand>, call it "_executePointer":
        private Action<ICommand> _executePointer;
        #endregion Fields

        #region Properties

        // DECLARE a set Property that sets the ExecutePointers:
        public Action<ICommand> ExecutePointer
        {
            set
            {
                _executePointer = value;
                _gallery.ExecutePointer = value;
                _editor.ExecutePointer = value;
            }
        }

        // DECLARE a get Property for "_galleryView":
        public IGalleryView GalleryView
        {
            get { return _gallery; }
        }

        // DECLARE a get Property for "_editor":
        public IImageView ImageView
        {
            get { return _editor; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Constructor for class View.
        /// </summary>
        public View()
        {
            // INITIALISE fields:
            _gallery = new GalleryView();

            _editor = new ImageView();

            // Assign the ToggleFormPointers to "_gallery" and "_editor":
            _gallery.ToggleFormPointer = ToggleForms;

            _editor.ToggleFormPointer = ToggleForms;
        }

        /// <summary>
        /// StartApp: Starts the application by running the "_gallery".
        /// </summary>
        public void StartApp()
        {
            // RUN the "_gallery":
            Application.Run(_gallery as Form);
        }

        /// <summary>
        /// ToggleForms: Toggles the Visibility of the "_gallery" and "_editor":
        /// </summary>
        public void ToggleForms()
        {
            // INVERT the Visibility of "_gallery":
            (_gallery as Form).Visible = !(_gallery as Form).Visible;
            // INVERT the Visibility of "_editor":
            (_editor as Form).Visible = !(_editor as Form).Visible;
        }

        /// <summary>
        /// Update: Called the update the View from the Model.
        /// </summary>
        /// <param name="e">Event information provided from the Model to update the View.</param>
        public void Update(EventArgs e)
        {
            try
            {
                // TRY to Inject the thumbnails passed from the Model to the Views ImageList:
                _gallery.InjectThumbnails((e as UpdateViewEventArgs).ImageList);

                // SET the editors Image to the currently selected Image provided by Model:
                _editor.Image = ((e as UpdateViewEventArgs).Image);
            }
            catch (Exception ex)
            {
                // PRINT the error message:
                Console.WriteLine(ex.Message);
            }
        }

        #endregion Methods
    }
}